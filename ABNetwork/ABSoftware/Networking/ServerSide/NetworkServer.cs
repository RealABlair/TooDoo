using ABSoftware.Networking.Packets;
using System;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;

namespace ABSoftware.Networking.ServerSide
{
    public class NetworkServer
    {
        public int Port { get; private set; }
        public bool Active { get; private set; }
        TcpListener listener;
        Thread networkThread;

        public NetworkServer(int Port)
        {
            this.Port = Port;
        }

        public void Start()
        {
            if (!Active)
            {
                Active = true;
                this.networkThread = new Thread(NetworkLoop);
                this.listener = new TcpListener(IPAddress.Any, Port);
                this.networkThread.Start();
            }
        }

        public void Stop()
        {
            if (Active)
            {
                Active = false;
                this.listener.Stop();
                this.networkThread = null;
            }
        }

        public void SendPacket(TcpClient client, IPacket packet)
        {
            PacketBuffer buffer = new PacketBuffer();
            buffer.Write(packet.GetPacketId());
            packet.WritePacket(buffer);
            buffer.Append(PacketManager.PacketEnding);

            byte[] data = buffer.ToArray();

            client.GetStream().Write(data, 0, data.Length);
        }

        public void SendPacket(TcpClient client, string UPID, IPacket packet)
        {
            PacketBuffer buffer = new PacketBuffer();
            buffer.WriteString(UPID);
            buffer.Write(packet.GetPacketId());
            packet.WritePacket(buffer);
            buffer.Append(PacketManager.PacketEnding);

            byte[] data = buffer.ToArray();

            client.GetStream().Write(data, 0, data.Length);
        }

        void NetworkLoop()
        {
            OnStart();
            try
            {
                this.listener.Start();
                while (Active)
                {
                    TcpClient client = listener.AcceptTcpClient();

                    new Thread(() =>
                    {
                        try
                        {
                            client.ReceiveTimeout = 5000;

                            using (NetworkStream stream = client.GetStream())
                            {
                                ByteBuilder builder = new ByteBuilder();

                                byte[] readBuffer = new byte[1024];

                                int readBytes;

                                while ((readBytes = stream.Read(readBuffer, 0, readBuffer.Length)) > 0)
                                {
                                    for (int i = 0; i < readBytes; i++)
                                        builder.Append(readBuffer[i]);

                                    if (builder.Contains(PacketManager.PacketEnding))
                                    {
                                        int endingIndex = -1;
                                        while ((endingIndex = builder.IndexOf(PacketManager.PacketEnding)) != -1)
                                        {
                                            IPacket receivedPacket = PacketManager.GetPacket(builder.GetRange(0, endingIndex), out string UPID);
                                            OnPacketIn(client, receivedPacket, UPID);
                                            builder.RemoveFirstElements(endingIndex + PacketManager.PacketEnding.Length);
                                        }
                                    }

                                    if (readBytes < readBuffer.Length)
                                        break;
                                }

                                client.Close();
                            }
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine($"[NetworkLoop.Thread.ERROR]: {ex.Message}");
                        }
                    }).Start();
                }
            }
            catch (Exception) { }
            OnStop();
        }

        public virtual void OnStart() { }
        public virtual void OnStop() { }
        public virtual void OnPacketIn(TcpClient client, IPacket packet, string UPID) { }
    }
}

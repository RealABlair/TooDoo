using System;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using ABSoftware.Networking.Packets;

namespace ABSoftware.Networking.ClientSide
{
    public class NetworkClient
    {
        public delegate void PacketHandler(IPacket response, PendingPacket request);
        public event PacketHandler PacketInHandler;

        public string IP { get; private set; }
        public int Port { get; private set; }

        public ArrayList<PendingPacket> pendingPackets = new ArrayList<PendingPacket>();

        ABRandom random = new ABRandom();

        public NetworkClient(string IP, int Port)
        {
            this.IP = IP;
            this.Port = Port;
        }

        public string GenerateUPID()
        {
            return $"{random.GetRandomUInt():X8}-{random.GetRandomUInt():X8}-{random.GetRandomUInt():X8}-{random.GetRandomUInt():X8}";
        }

        public void SendPacket(IPacket packet, Action<IPacket, PendingPacket> onReceivedAction = null)
        {
            new Thread(() =>
            {
                try
                {
                    using (TcpClient client = new TcpClient())
                    {
                        client.ReceiveTimeout = 5000;
                        client.Connect(IP, Port);

                        string sendUPID = GenerateUPID();
                        PacketBuffer buffer = new PacketBuffer();
                        buffer.WriteString(sendUPID);
                        buffer.Write(packet.GetPacketId());
                        packet.WritePacket(buffer);
                        buffer.Append(PacketManager.PacketEnding);

                        byte[] packetBytes = buffer.ToArray();

                        using (NetworkStream stream = client.GetStream())
                        {
                            stream.Write(packetBytes, 0, packetBytes.Length);

                            pendingPackets.Add(new PendingPacket(sendUPID, packet, onReceivedAction));

                            ByteBuilder builder = new ByteBuilder();

                            byte[] readBuffer = new byte[1024];

                            int readBytes;

                            while((readBytes = stream.Read(readBuffer, 0, readBuffer.Length)) > 0)
                            {
                                for (int i = 0; i < readBytes; i++)
                                    builder.Append(readBuffer[i]);

                                if(builder.Contains(PacketManager.PacketEnding))
                                {
                                    int endingIndex = -1;
                                    while ((endingIndex = builder.IndexOf(PacketManager.PacketEnding)) != -1)
                                    {
                                        IPacket receivedPacket = PacketManager.GetPacket(builder.GetRange(0, endingIndex), out string UPID);
                                        OnPacketIn(receivedPacket, UPID);
                                        builder.RemoveFirstElements(endingIndex + PacketManager.PacketEnding.Length);
                                    }
                                }
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"[SendPacket.ERROR]: {ex.Message} {ex.StackTrace}");
                }
            }).Start();
        }

        void OnPacketIn(IPacket responsePacket, string UPID)
        {
            for(int i = 0; i < pendingPackets.Size; i++)
            {
                if(pendingPackets[i].UPID == UPID)
                {
                    PacketInHandler?.Invoke(responsePacket, pendingPackets[i]);
                    pendingPackets.RemoveAt(i);
                    break;
                }
            }
        }
    }
}

using System;

namespace ABSoftware.Networking.Packets
{
    public class StatusResponsePacket : IPacket
    {
        public StatusResponsePacket()
        {

        }

        public Status status;
        public string data;

        public StatusResponsePacket(Status status, string data)
        {
            this.status = status;
            this.data = data;
        }

        public void WritePacket(PacketBuffer buffer)
        {
            buffer.Write((int)status);
            buffer.WriteString(data);
        }

        public void ReadPacket(PacketBuffer buffer)
        {
            status = (Status)buffer.Read<int>();
            data = buffer.ReadString();
        }

        public int GetPacketId() => 3;

        public enum Status
        {
            OK = 0,
            Error,
            Failed,
            Success
        }
    }
}

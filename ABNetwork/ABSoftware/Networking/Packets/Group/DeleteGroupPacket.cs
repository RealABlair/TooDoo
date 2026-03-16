using System;

namespace ABSoftware.Networking.Packets
{
    public class DeleteGroupPacket : IPacket
    {
        public DeleteGroupPacket()
        {

        }

        public string groupName;
        public string loginKey;

        public DeleteGroupPacket(string groupName, string loginKey)
        {
            this.groupName = groupName;
            this.loginKey = loginKey;
        }

        public void WritePacket(PacketBuffer buffer)
        {
            buffer.WriteString(groupName);
            buffer.WriteString(loginKey);
        }

        public void ReadPacket(PacketBuffer buffer)
        {
            groupName = buffer.ReadString();
            loginKey = buffer.ReadString();
        }

        public int GetPacketId() => 6;
    }
}

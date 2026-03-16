using System;

namespace ABSoftware.Networking.Packets
{
    public class DeleteTaskPacket : IPacket
    {
        public DeleteTaskPacket()
        {

        }

        public string groupName;
        public string taskName;
        public string loginKey;

        public DeleteTaskPacket(string groupName, string taskName, string loginKey)
        {
            this.groupName = groupName;
            this.taskName = taskName;
            this.loginKey = loginKey;
        }

        public void WritePacket(PacketBuffer buffer)
        {
            buffer.WriteString(groupName);
            buffer.WriteString(taskName);
            buffer.WriteString(loginKey);
        }

        public void ReadPacket(PacketBuffer buffer)
        {
            groupName = buffer.ReadString();
            taskName = buffer.ReadString();
            loginKey = buffer.ReadString();
        }

        public int GetPacketId() => 7;
    }
}

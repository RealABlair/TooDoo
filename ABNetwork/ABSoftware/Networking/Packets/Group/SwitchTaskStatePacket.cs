using System;

namespace ABSoftware.Networking.Packets
{
    public class SwitchTaskStatePacket : IPacket
    {
        public SwitchTaskStatePacket()
        {

        }

        public string groupName;
        public string taskName;
        public bool taskState;
        public string loginKey;

        public SwitchTaskStatePacket(string groupName, string taskName, bool taskState, string loginKey)
        {
            this.groupName = groupName;
            this.taskName = taskName;
            this.taskState = taskState;
            this.loginKey = loginKey;
        }

        public void WritePacket(PacketBuffer buffer)
        {
            buffer.WriteString(groupName);
            buffer.WriteString(taskName);
            buffer.Write(taskState ? (byte)1 : (byte)0);
            buffer.WriteString(loginKey);
        }

        public void ReadPacket(PacketBuffer buffer)
        {
            groupName = buffer.ReadString();
            taskName = buffer.ReadString();
            taskState = buffer.Read<byte>() != 0;
            loginKey = buffer.ReadString();
        }

        public int GetPacketId() => 8;
    }
}

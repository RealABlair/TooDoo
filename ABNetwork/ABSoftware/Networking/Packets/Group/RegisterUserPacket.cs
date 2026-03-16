using System;

namespace ABSoftware.Networking.Packets
{
    public class RegisterUserPacket : IPacket
    {
        public RegisterUserPacket()
        {

        }

        public string username;
        public string password;

        public RegisterUserPacket(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public void WritePacket(PacketBuffer buffer)
        {
            buffer.WriteString(username);
            buffer.WriteString(password);
        }

        public void ReadPacket(PacketBuffer buffer)
        {
            username = buffer.ReadString();
            password = buffer.ReadString();
        }

        public int GetPacketId() => 4;
    }
}

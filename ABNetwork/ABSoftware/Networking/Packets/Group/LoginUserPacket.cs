using System;

namespace ABSoftware.Networking.Packets
{
    public class LoginUserPacket : IPacket
    {
        public LoginUserPacket()
        {

        }

        public string username;
        public string password;

        public LoginUserPacket(string username, string password)
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

        public int GetPacketId() => 5;
    }
}

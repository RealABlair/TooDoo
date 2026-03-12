using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABSoftware.Networking.Packets
{
    public class TasksDataPacket : IPacket
    {
        public TasksDataPacket()
        {

        }

        public string data;

        public TasksDataPacket(string data)
        {
            this.data = data;
        }

        public void WritePacket(PacketBuffer buffer)
        {
            buffer.WriteString(data);
        }

        public void ReadPacket(PacketBuffer buffer)
        {
            data = buffer.ReadString();
        }

        public int GetPacketId() => 0;
    }
}

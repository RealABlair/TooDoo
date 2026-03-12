using System;
using ABSoftware;

namespace ABSoftware.Networking.Packets
{
    public interface IPacket
    {
        void WritePacket(PacketBuffer buffer);
        void ReadPacket(PacketBuffer buffer);
        int GetPacketId();
    }

    public class PendingPacket
    {
        public string UPID;
        public IPacket packet;
        public Action<IPacket, PendingPacket> onReceivedAction;

        public PendingPacket(string UPID, IPacket packet, Action<IPacket, PendingPacket> onReceivedAction)
        {
            this.UPID = UPID;
            this.packet = packet;
            this.onReceivedAction = onReceivedAction;
        }
    }
}

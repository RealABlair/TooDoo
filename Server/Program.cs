using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABSoftware.Networking.ServerSide;
using ABSoftware.Networking.Packets;
using ABSoftware.Networking;
using System.Net.Sockets;
using Microsoft.Data.Sqlite;

namespace Server
{
    public class Program : NetworkServer
    {
        public static Program instance;

        static void Main(string[] args)
        {
            instance = new Program();
            instance.Start();
        }

        public Program() : base(5050)
        {
            DatabaseController.InitializeDatabase();
        }

        public override void OnStart()
        {
            Console.WriteLine($"Server is online! (Port {this.Port})");
        }

        public override void OnStop()
        {
            Console.WriteLine("Server is offline!");
        }

        public override void OnPacketIn(TcpClient client, IPacket packet, string UPID)
        {
            Console.WriteLine();

            int packetId = packet.GetPacketId();
            switch (packetId)
            {
                case 0:
                    {
                        SendPacket(client, UPID, new TasksDataPacket("(\n\tgroups\n\t(\n\t\tGroup1\n\t\t(\n\t\t\tTask1=True\n\t\t)\n\t)\n)"));
                    }
                    break;
            }
        }
    }
}

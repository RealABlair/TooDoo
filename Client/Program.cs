using ABSoftware.Networking.ClientSide;
using ABSoftware.Networking.Packets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        public static LoginForm LoginForm;
        public static RegisterForm RegisterForm;
        public static MainForm MainForm;

        public static NetworkClient NetClient = new NetworkClient("127.0.0.1", 5050);

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Control.CheckForIllegalCrossThreadCalls = false;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            NetClient.PacketInHandler += Netclient_PacketInHandler;

            MainForm = new MainForm();
            LoginForm = new LoginForm();
            RegisterForm = new RegisterForm();
            Application.Run(LoginForm);
        }

        private static void Netclient_PacketInHandler(IPacket response, PendingPacket request)
        {
            request.onReceivedAction?.Invoke(response, request);
        }
    }
}

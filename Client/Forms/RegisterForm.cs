using System;
using System.Windows.Forms;
using ABSoftware.UI;
using ABSoftware.Networking.Packets;

namespace Client
{
    public partial class RegisterForm : DraggableForm
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.LoginForm.Show();
            this.Hide();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            if (UsernameTB.Text.Length < 4)
            {
                MessagePopupForm.ShowMessage("The username length can't be lower than 4.");
                return;
            }

            if (PasswordTB.Text.Length < 2)
            {
                MessagePopupForm.ShowMessage("The password length can't be lower than 2.");
                return;
            }

            Program.NetClient.SendPacket(new RegisterUserPacket(UsernameTB.Text, PasswordTB.Text), new Action<IPacket, PendingPacket>((responsePacket, pendingPacket) =>
            {
                StatusResponsePacket response = (StatusResponsePacket)responsePacket;

                switch(response.status)
                {
                    case StatusResponsePacket.Status.Success:
                        {
                            Program.NetClient.SendPacket(new LoginUserPacket(UsernameTB.Text, PasswordTB.Text), new Action<IPacket, PendingPacket>((responsePacketAuth, pendingPacketAuth) =>
                            {
                                StatusResponsePacket responseAuth = (StatusResponsePacket)responsePacketAuth;

                                switch (responseAuth.status)
                                {
                                    case StatusResponsePacket.Status.Success:
                                        {
                                            Program.MainForm.LoginKey = responseAuth.data;
                                            if (InvokeRequired)
                                            {
                                                Invoke(new Action(() =>
                                                {
                                                    Program.MainForm.Show();
                                                    this.Hide();
                                                }));
                                            }
                                            else
                                            {
                                                Program.MainForm.Show();
                                                this.Hide();
                                            }
                                        }
                                        break;
                                    case StatusResponsePacket.Status.Failed:
                                        {
                                            MessagePopupForm.ShowMessage($"Login failed. Reason: \"{responseAuth.data}\"");
                                        }
                                        break;
                                }
                            }));
                        }
                        break;
                    case StatusResponsePacket.Status.Failed:
                        {
                            MessagePopupForm.ShowMessage($"Registration failed. Reason: \"{response.data}\"");
                        }
                        break;
                }
            }));
        }
    }
}

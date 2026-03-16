using System;
using System.Windows.Forms;
using ABSoftware.UI;
using ABSoftware.Networking.Packets;

namespace Client
{
    public partial class LoginForm : DraggableForm
    {
        public LoginForm()
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

        private void ToRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.RegisterForm.Show();
            this.Hide();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            Program.NetClient.SendPacket(new LoginUserPacket(UsernameTB.Text, PasswordTB.Text), new Action<IPacket, PendingPacket>((responsePacket, pendingPacket) =>
            {
                StatusResponsePacket response = (StatusResponsePacket)responsePacket;

                switch (response.status)
                {
                    case StatusResponsePacket.Status.Success:
                        {
                            Program.MainForm.LoginKey = response.data;
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
                            MessagePopupForm.ShowMessage($"Login failed. Reason: \"{response.data}\"");
                        }
                        break;
                }
            }));
        }
    }
}

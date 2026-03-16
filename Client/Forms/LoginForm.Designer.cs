
namespace Client
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ControlBoxPanel = new ABSoftware.UI.DraggablePanel();
            this.AppLabel = new ABSoftware.UI.DraggableLabel();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.LoginLabel = new ABSoftware.UI.DraggableLabel();
            this.UsernameTB = new System.Windows.Forms.TextBox();
            this.draggableLabel1 = new ABSoftware.UI.DraggableLabel();
            this.draggableLabel2 = new ABSoftware.UI.DraggableLabel();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.LoginButton = new System.Windows.Forms.Button();
            this.draggableLabel3 = new ABSoftware.UI.DraggableLabel();
            this.ToRegister = new System.Windows.Forms.LinkLabel();
            this.ControlBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlBoxPanel
            // 
            this.ControlBoxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlBoxPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(65)))), ((int)(((byte)(119)))));
            this.ControlBoxPanel.Controls.Add(this.AppLabel);
            this.ControlBoxPanel.Controls.Add(this.MinimizeButton);
            this.ControlBoxPanel.Controls.Add(this.ExitButton);
            this.ControlBoxPanel.Location = new System.Drawing.Point(5, 5);
            this.ControlBoxPanel.Margin = new System.Windows.Forms.Padding(0);
            this.ControlBoxPanel.Name = "ControlBoxPanel";
            this.ControlBoxPanel.Padding = new System.Windows.Forms.Padding(5);
            this.ControlBoxPanel.Size = new System.Drawing.Size(410, 32);
            this.ControlBoxPanel.TabIndex = 1;
            // 
            // AppLabel
            // 
            this.AppLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AppLabel.ForeColor = System.Drawing.Color.White;
            this.AppLabel.Location = new System.Drawing.Point(8, 0);
            this.AppLabel.Name = "AppLabel";
            this.AppLabel.Size = new System.Drawing.Size(90, 32);
            this.AppLabel.TabIndex = 2;
            this.AppLabel.Text = "TooDoo!";
            this.AppLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MinimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MinimizeButton.ForeColor = System.Drawing.Color.White;
            this.MinimizeButton.Location = new System.Drawing.Point(348, 4);
            this.MinimizeButton.Margin = new System.Windows.Forms.Padding(4);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(24, 24);
            this.MinimizeButton.TabIndex = 1;
            this.MinimizeButton.Text = "_";
            this.MinimizeButton.UseVisualStyleBackColor = true;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(380, 4);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(24, 24);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // LoginLabel
            // 
            this.LoginLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.LoginLabel.ForeColor = System.Drawing.Color.White;
            this.LoginLabel.Location = new System.Drawing.Point(12, 74);
            this.LoginLabel.Name = "LoginLabel";
            this.LoginLabel.Size = new System.Drawing.Size(396, 49);
            this.LoginLabel.TabIndex = 2;
            this.LoginLabel.Text = "Login";
            this.LoginLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UsernameTB
            // 
            this.UsernameTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.UsernameTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UsernameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UsernameTB.ForeColor = System.Drawing.Color.White;
            this.UsernameTB.Location = new System.Drawing.Point(19, 193);
            this.UsernameTB.Name = "UsernameTB";
            this.UsernameTB.Size = new System.Drawing.Size(389, 24);
            this.UsernameTB.TabIndex = 3;
            // 
            // draggableLabel1
            // 
            this.draggableLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.draggableLabel1.ForeColor = System.Drawing.Color.White;
            this.draggableLabel1.Location = new System.Drawing.Point(19, 168);
            this.draggableLabel1.Name = "draggableLabel1";
            this.draggableLabel1.Size = new System.Drawing.Size(124, 22);
            this.draggableLabel1.TabIndex = 4;
            this.draggableLabel1.Text = "Username:";
            this.draggableLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // draggableLabel2
            // 
            this.draggableLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.draggableLabel2.ForeColor = System.Drawing.Color.White;
            this.draggableLabel2.Location = new System.Drawing.Point(19, 244);
            this.draggableLabel2.Name = "draggableLabel2";
            this.draggableLabel2.Size = new System.Drawing.Size(124, 22);
            this.draggableLabel2.TabIndex = 6;
            this.draggableLabel2.Text = "Password:";
            this.draggableLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PasswordTB
            // 
            this.PasswordTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.PasswordTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PasswordTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordTB.ForeColor = System.Drawing.Color.White;
            this.PasswordTB.Location = new System.Drawing.Point(19, 269);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.Size = new System.Drawing.Size(389, 24);
            this.PasswordTB.TabIndex = 5;
            this.PasswordTB.UseSystemPasswordChar = true;
            // 
            // LoginButton
            // 
            this.LoginButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(65)))), ((int)(((byte)(119)))));
            this.LoginButton.FlatAppearance.BorderSize = 0;
            this.LoginButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(105)))), ((int)(((byte)(159)))));
            this.LoginButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LoginButton.ForeColor = System.Drawing.Color.White;
            this.LoginButton.Location = new System.Drawing.Point(124, 360);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(172, 59);
            this.LoginButton.TabIndex = 7;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = false;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // draggableLabel3
            // 
            this.draggableLabel3.ForeColor = System.Drawing.Color.White;
            this.draggableLabel3.Location = new System.Drawing.Point(103, 422);
            this.draggableLabel3.Name = "draggableLabel3";
            this.draggableLabel3.Size = new System.Drawing.Size(122, 44);
            this.draggableLabel3.TabIndex = 8;
            this.draggableLabel3.Text = "Don\'t have an account?";
            this.draggableLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ToRegister
            // 
            this.ToRegister.ActiveLinkColor = System.Drawing.Color.Gray;
            this.ToRegister.LinkColor = System.Drawing.Color.White;
            this.ToRegister.Location = new System.Drawing.Point(231, 422);
            this.ToRegister.Name = "ToRegister";
            this.ToRegister.Size = new System.Drawing.Size(100, 44);
            this.ToRegister.TabIndex = 9;
            this.ToRegister.TabStop = true;
            this.ToRegister.Text = "Register";
            this.ToRegister.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ToRegister.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ToRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ToRegister_LinkClicked);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(420, 475);
            this.Controls.Add(this.ToRegister);
            this.Controls.Add(this.draggableLabel3);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.draggableLabel2);
            this.Controls.Add(this.PasswordTB);
            this.Controls.Add(this.draggableLabel1);
            this.Controls.Add(this.UsernameTB);
            this.Controls.Add(this.LoginLabel);
            this.Controls.Add(this.ControlBoxPanel);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.ControlBoxPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ABSoftware.UI.DraggablePanel ControlBoxPanel;
        private ABSoftware.UI.DraggableLabel AppLabel;
        private System.Windows.Forms.Button MinimizeButton;
        private System.Windows.Forms.Button ExitButton;
        private ABSoftware.UI.DraggableLabel LoginLabel;
        private System.Windows.Forms.TextBox UsernameTB;
        private ABSoftware.UI.DraggableLabel draggableLabel1;
        private ABSoftware.UI.DraggableLabel draggableLabel2;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Button LoginButton;
        private ABSoftware.UI.DraggableLabel draggableLabel3;
        private System.Windows.Forms.LinkLabel ToRegister;
    }
}
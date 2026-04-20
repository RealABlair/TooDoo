
namespace Client
{
    partial class MessagePopupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessagePopupForm));
            this.button1 = new System.Windows.Forms.Button();
            this.MessageText = new ABSoftware.UI.DraggableLabel();
            this.ControlBoxPanel = new ABSoftware.UI.DraggablePanel();
            this.AppLabel = new ABSoftware.UI.DraggableLabel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ControlBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(212, 171);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // MessageText
            // 
            this.MessageText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MessageText.ForeColor = System.Drawing.Color.White;
            this.MessageText.Location = new System.Drawing.Point(12, 42);
            this.MessageText.Name = "MessageText";
            this.MessageText.Size = new System.Drawing.Size(476, 116);
            this.MessageText.TabIndex = 5;
            this.MessageText.Text = "Text";
            this.MessageText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ControlBoxPanel
            // 
            this.ControlBoxPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ControlBoxPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(65)))), ((int)(((byte)(119)))));
            this.ControlBoxPanel.Controls.Add(this.AppLabel);
            this.ControlBoxPanel.Controls.Add(this.ExitButton);
            this.ControlBoxPanel.Location = new System.Drawing.Point(5, 5);
            this.ControlBoxPanel.Margin = new System.Windows.Forms.Padding(5);
            this.ControlBoxPanel.Name = "ControlBoxPanel";
            this.ControlBoxPanel.Padding = new System.Windows.Forms.Padding(5);
            this.ControlBoxPanel.Size = new System.Drawing.Size(490, 32);
            this.ControlBoxPanel.TabIndex = 4;
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
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(460, 4);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(24, 24);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // MessagePopupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(500, 225);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.MessageText);
            this.Controls.Add(this.ControlBoxPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MessagePopupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ControlBoxPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private ABSoftware.UI.DraggableLabel MessageText;
        private ABSoftware.UI.DraggablePanel ControlBoxPanel;
        private ABSoftware.UI.DraggableLabel AppLabel;
        private System.Windows.Forms.Button ExitButton;
    }
}
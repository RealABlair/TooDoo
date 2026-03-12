
namespace Client
{
    partial class NewTaskForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewTaskForm));
            this.ControlBoxPanel = new ABSoftware.UI.DraggablePanel();
            this.AppLabel = new ABSoftware.UI.DraggableLabel();
            this.ExitButton = new System.Windows.Forms.Button();
            this.NewTaskNameTB = new System.Windows.Forms.TextBox();
            this.draggableLabel1 = new ABSoftware.UI.DraggableLabel();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelActionButton = new System.Windows.Forms.Button();
            this.ControlBoxPanel.SuspendLayout();
            this.SuspendLayout();
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
            this.ControlBoxPanel.Size = new System.Drawing.Size(415, 32);
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
            // ExitButton
            // 
            this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ExitButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExitButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(385, 4);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(24, 24);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // NewTaskNameTB
            // 
            this.NewTaskNameTB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.NewTaskNameTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NewTaskNameTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NewTaskNameTB.ForeColor = System.Drawing.Color.White;
            this.NewTaskNameTB.Location = new System.Drawing.Point(16, 73);
            this.NewTaskNameTB.Name = "NewTaskNameTB";
            this.NewTaskNameTB.Size = new System.Drawing.Size(393, 21);
            this.NewTaskNameTB.TabIndex = 2;
            this.NewTaskNameTB.Text = "My Task";
            // 
            // draggableLabel1
            // 
            this.draggableLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.draggableLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.draggableLabel1.ForeColor = System.Drawing.Color.White;
            this.draggableLabel1.Location = new System.Drawing.Point(13, 42);
            this.draggableLabel1.Name = "draggableLabel1";
            this.draggableLabel1.Size = new System.Drawing.Size(396, 28);
            this.draggableLabel1.TabIndex = 3;
            this.draggableLabel1.Text = "New Task:";
            this.draggableLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OKButton
            // 
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OKButton.ForeColor = System.Drawing.Color.White;
            this.OKButton.Location = new System.Drawing.Point(130, 128);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelActionButton
            // 
            this.CancelActionButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelActionButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelActionButton.ForeColor = System.Drawing.Color.White;
            this.CancelActionButton.Location = new System.Drawing.Point(215, 128);
            this.CancelActionButton.Name = "CancelActionButton";
            this.CancelActionButton.Size = new System.Drawing.Size(75, 23);
            this.CancelActionButton.TabIndex = 5;
            this.CancelActionButton.Text = "Cancel";
            this.CancelActionButton.UseVisualStyleBackColor = true;
            // 
            // NewTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(425, 163);
            this.Controls.Add(this.CancelActionButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.draggableLabel1);
            this.Controls.Add(this.NewTaskNameTB);
            this.Controls.Add(this.ControlBoxPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewTaskForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Task";
            this.ControlBoxPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ABSoftware.UI.DraggablePanel ControlBoxPanel;
        private ABSoftware.UI.DraggableLabel AppLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.TextBox NewTaskNameTB;
        private ABSoftware.UI.DraggableLabel draggableLabel1;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelActionButton;
    }
}
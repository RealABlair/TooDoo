
namespace Client
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TasksList = new ABSoftware.UI.DraggablePanel();
            this.ToolsPanel = new ABSoftware.UI.DraggablePanel();
            this.RefreshDataButton = new System.Windows.Forms.Button();
            this.NewFolderButton = new System.Windows.Forms.Button();
            this.ControlBoxPanel = new ABSoftware.UI.DraggablePanel();
            this.AppLabel = new ABSoftware.UI.DraggableLabel();
            this.MinimizeButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ToolsPanel.SuspendLayout();
            this.ControlBoxPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TasksList
            // 
            this.TasksList.AutoScroll = true;
            this.TasksList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.TasksList.Location = new System.Drawing.Point(16, 45);
            this.TasksList.Name = "TasksList";
            this.TasksList.Size = new System.Drawing.Size(757, 393);
            this.TasksList.TabIndex = 2;
            // 
            // ToolsPanel
            // 
            this.ToolsPanel.Controls.Add(this.RefreshDataButton);
            this.ToolsPanel.Controls.Add(this.NewFolderButton);
            this.ToolsPanel.Location = new System.Drawing.Point(779, 45);
            this.ToolsPanel.Name = "ToolsPanel";
            this.ToolsPanel.Size = new System.Drawing.Size(62, 393);
            this.ToolsPanel.TabIndex = 1;
            // 
            // RefreshDataButton
            // 
            this.RefreshDataButton.BackgroundImage = global::Client.Properties.Resources.refresh;
            this.RefreshDataButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.RefreshDataButton.FlatAppearance.BorderSize = 0;
            this.RefreshDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RefreshDataButton.ForeColor = System.Drawing.Color.White;
            this.RefreshDataButton.Location = new System.Drawing.Point(32, 0);
            this.RefreshDataButton.Margin = new System.Windows.Forms.Padding(0);
            this.RefreshDataButton.Name = "RefreshDataButton";
            this.RefreshDataButton.Size = new System.Drawing.Size(30, 30);
            this.RefreshDataButton.TabIndex = 1;
            this.RefreshDataButton.UseVisualStyleBackColor = true;
            this.RefreshDataButton.Click += new System.EventHandler(this.RefreshDataButton_Click);
            // 
            // NewFolderButton
            // 
            this.NewFolderButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("NewFolderButton.BackgroundImage")));
            this.NewFolderButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NewFolderButton.FlatAppearance.BorderSize = 0;
            this.NewFolderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.NewFolderButton.ForeColor = System.Drawing.Color.White;
            this.NewFolderButton.Location = new System.Drawing.Point(0, 0);
            this.NewFolderButton.Margin = new System.Windows.Forms.Padding(0);
            this.NewFolderButton.Name = "NewFolderButton";
            this.NewFolderButton.Size = new System.Drawing.Size(30, 30);
            this.NewFolderButton.TabIndex = 0;
            this.NewFolderButton.UseVisualStyleBackColor = true;
            this.NewFolderButton.Click += new System.EventHandler(this.NewFolderButton_Click);
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
            this.ControlBoxPanel.Margin = new System.Windows.Forms.Padding(5);
            this.ControlBoxPanel.Name = "ControlBoxPanel";
            this.ControlBoxPanel.Padding = new System.Windows.Forms.Padding(5);
            this.ControlBoxPanel.Size = new System.Drawing.Size(836, 32);
            this.ControlBoxPanel.TabIndex = 0;
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
            this.MinimizeButton.Location = new System.Drawing.Point(774, 4);
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
            this.ExitButton.Location = new System.Drawing.Point(806, 4);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(24, 24);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(846, 450);
            this.Controls.Add(this.TasksList);
            this.Controls.Add(this.ToolsPanel);
            this.Controls.Add(this.ControlBoxPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "TooDoo!";
            this.ToolsPanel.ResumeLayout(false);
            this.ControlBoxPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ABSoftware.UI.DraggablePanel ControlBoxPanel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button MinimizeButton;
        private ABSoftware.UI.DraggableLabel AppLabel;
        private ABSoftware.UI.DraggablePanel ToolsPanel;
        private ABSoftware.UI.DraggablePanel TasksList;
        private System.Windows.Forms.Button NewFolderButton;
        private System.Windows.Forms.Button RefreshDataButton;
    }
}


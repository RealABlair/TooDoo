
namespace Client
{
    partial class FiltersForm
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
            this.ExitButton = new System.Windows.Forms.Button();
            this.SearchString = new System.Windows.Forms.TextBox();
            this.ShowCompletedCB = new System.Windows.Forms.CheckBox();
            this.ShowOutstandingCB = new System.Windows.Forms.CheckBox();
            this.MatchWordCB = new System.Windows.Forms.CheckBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ResetFiltersButton = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.draggableLabel1 = new ABSoftware.UI.DraggableLabel();
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
            this.ControlBoxPanel.Size = new System.Drawing.Size(471, 32);
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
            this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExitButton.ForeColor = System.Drawing.Color.White;
            this.ExitButton.Location = new System.Drawing.Point(441, 4);
            this.ExitButton.Margin = new System.Windows.Forms.Padding(4);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(24, 24);
            this.ExitButton.TabIndex = 0;
            this.ExitButton.Text = "X";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
            // 
            // SearchString
            // 
            this.SearchString.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.SearchString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SearchString.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchString.ForeColor = System.Drawing.Color.White;
            this.SearchString.Location = new System.Drawing.Point(75, 59);
            this.SearchString.Name = "SearchString";
            this.SearchString.Size = new System.Drawing.Size(394, 21);
            this.SearchString.TabIndex = 3;
            // 
            // ShowCompletedCB
            // 
            this.ShowCompletedCB.AutoSize = true;
            this.ShowCompletedCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowCompletedCB.ForeColor = System.Drawing.Color.White;
            this.ShowCompletedCB.Location = new System.Drawing.Point(12, 149);
            this.ShowCompletedCB.Name = "ShowCompletedCB";
            this.ShowCompletedCB.Size = new System.Drawing.Size(169, 19);
            this.ShowCompletedCB.TabIndex = 5;
            this.ShowCompletedCB.Text = "Show completed tasks";
            this.ShowCompletedCB.UseVisualStyleBackColor = true;
            // 
            // ShowOutstandingCB
            // 
            this.ShowOutstandingCB.AutoSize = true;
            this.ShowOutstandingCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowOutstandingCB.ForeColor = System.Drawing.Color.White;
            this.ShowOutstandingCB.Location = new System.Drawing.Point(12, 174);
            this.ShowOutstandingCB.Name = "ShowOutstandingCB";
            this.ShowOutstandingCB.Size = new System.Drawing.Size(177, 19);
            this.ShowOutstandingCB.TabIndex = 6;
            this.ShowOutstandingCB.Text = "Show outstanding tasks";
            this.ShowOutstandingCB.UseVisualStyleBackColor = true;
            // 
            // MatchWordCB
            // 
            this.MatchWordCB.AutoSize = true;
            this.MatchWordCB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MatchWordCB.ForeColor = System.Drawing.Color.White;
            this.MatchWordCB.Location = new System.Drawing.Point(12, 88);
            this.MatchWordCB.Name = "MatchWordCB";
            this.MatchWordCB.Size = new System.Drawing.Size(142, 19);
            this.MatchWordCB.TabIndex = 7;
            this.MatchWordCB.Text = "Match whole word";
            this.MatchWordCB.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CancelButton.ForeColor = System.Drawing.Color.White;
            this.CancelButton.Location = new System.Drawing.Point(389, 172);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(81, 23);
            this.CancelButton.TabIndex = 8;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // ResetFiltersButton
            // 
            this.ResetFiltersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResetFiltersButton.ForeColor = System.Drawing.Color.White;
            this.ResetFiltersButton.Location = new System.Drawing.Point(388, 86);
            this.ResetFiltersButton.Name = "ResetFiltersButton";
            this.ResetFiltersButton.Size = new System.Drawing.Size(81, 23);
            this.ResetFiltersButton.TabIndex = 9;
            this.ResetFiltersButton.Text = "Reset Filters";
            this.ResetFiltersButton.UseVisualStyleBackColor = true;
            this.ResetFiltersButton.Click += new System.EventHandler(this.ResetFiltersButton_Click);
            // 
            // ApplyButton
            // 
            this.ApplyButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ApplyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ApplyButton.ForeColor = System.Drawing.Color.White;
            this.ApplyButton.Location = new System.Drawing.Point(302, 172);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(81, 23);
            this.ApplyButton.TabIndex = 10;
            this.ApplyButton.Text = "Apply";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // draggableLabel1
            // 
            this.draggableLabel1.AutoSize = true;
            this.draggableLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.draggableLabel1.ForeColor = System.Drawing.Color.White;
            this.draggableLabel1.Location = new System.Drawing.Point(9, 61);
            this.draggableLabel1.Name = "draggableLabel1";
            this.draggableLabel1.Size = new System.Drawing.Size(60, 15);
            this.draggableLabel1.TabIndex = 11;
            this.draggableLabel1.Text = "Search: ";
            // 
            // FiltersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(52)))), ((int)(((byte)(52)))));
            this.ClientSize = new System.Drawing.Size(481, 211);
            this.Controls.Add(this.draggableLabel1);
            this.Controls.Add(this.ApplyButton);
            this.Controls.Add(this.ResetFiltersButton);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.MatchWordCB);
            this.Controls.Add(this.ShowOutstandingCB);
            this.Controls.Add(this.ShowCompletedCB);
            this.Controls.Add(this.SearchString);
            this.Controls.Add(this.ControlBoxPanel);
            this.Name = "FiltersForm";
            this.Text = "FiltersForm";
            this.ControlBoxPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ABSoftware.UI.DraggablePanel ControlBoxPanel;
        private ABSoftware.UI.DraggableLabel AppLabel;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.TextBox SearchString;
        private System.Windows.Forms.CheckBox ShowCompletedCB;
        private System.Windows.Forms.CheckBox ShowOutstandingCB;
        private System.Windows.Forms.CheckBox MatchWordCB;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ResetFiltersButton;
        private System.Windows.Forms.Button ApplyButton;
        private ABSoftware.UI.DraggableLabel draggableLabel1;
    }
}
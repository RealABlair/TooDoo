using System;
using System.Drawing;
using System.Windows.Forms;
using ABSoftware.UI;

namespace Client
{
    public class Task
    {
        public string TaskData { get; private set; }
        public bool Done;

        public DraggablePanel taskPanel;
        public Label taskLabel;

        public Task(string taskData, DraggablePanel taskPanel, Label taskLabel)
        {
            this.TaskData = taskData;
            this.taskPanel = taskPanel;
            this.taskLabel = taskLabel;
        }

        public void SwitchState()
        {
            this.Done = !Done;

            if(this.Done)
            {
                taskLabel.Font = new Font(taskLabel.Font.FontFamily, taskLabel.Font.Size, FontStyle.Bold | FontStyle.Strikeout);
                taskLabel.ForeColor = MainForm.COLOR_WHITE_DARKER;
            }
            else
            {
                taskLabel.Font = new Font(taskLabel.Font.FontFamily, taskLabel.Font.Size, FontStyle.Bold);
                taskLabel.ForeColor = MainForm.COLOR_WHITE;
            }
        }

        public void SwitchState(bool state)
        {
            this.Done = state;

            if (this.Done)
            {
                taskLabel.Font = new Font(taskLabel.Font.FontFamily, taskLabel.Font.Size, FontStyle.Bold | FontStyle.Strikeout);
                taskLabel.ForeColor = MainForm.COLOR_WHITE_DARKER;
            }
            else
            {
                taskLabel.Font = new Font(taskLabel.Font.FontFamily, taskLabel.Font.Size, FontStyle.Bold);
                taskLabel.ForeColor = MainForm.COLOR_WHITE;
            }
        }
    }
}

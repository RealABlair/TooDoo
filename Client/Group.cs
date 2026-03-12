using System;
using ABSoftware;
using ABSoftware.UI;

namespace Client
{
    public class Group
    {
        public string groupName { get; private set; }

        public DraggablePanel groupPanel;
        public DraggablePanel spacerPanel;
        public DraggablePanel tasksPanel;

        public ArrayList<Task> tasks = new ArrayList<Task>();

        public Group(string groupName, DraggablePanel groupPanel, DraggablePanel spacerPanel, DraggablePanel tasksPanel)
        {
            this.groupName = groupName;

            this.groupPanel = groupPanel;
            this.spacerPanel = spacerPanel;
            this.tasksPanel = tasksPanel;
        }

        public void AddTask(Task task)
        {
            int size = task.taskPanel.Height;
            if (tasks.Size == 0)
                size += 10;
            tasksPanel.Height += size;
            tasks.Add(task);
        }

        public void RemoveTask(Task task)
        {
            tasks.Remove(task);

            int size = task.taskPanel.Height;
            if (tasks.Size == 0)
                size += 10;
            tasksPanel.Height -= size;

            RecolorTaskBackgrounds();
        }

        public void SwapTasks(int prevTaskId, int newTaskId)
        {
            if (prevTaskId < 0 || newTaskId < 0 || prevTaskId >= tasks.Size || newTaskId >= tasks.Size)
                return;

            Task task = tasks[prevTaskId];

            tasks[prevTaskId] = tasks[newTaskId];
            tasks[newTaskId] = task;
        }

        public void RecolorTaskBackgrounds()
        {
            for(int i = 0; i < tasks.Size; i++)
            {
                tasks[i].taskPanel.BackColor = i % 2 == 0 ? MainForm.COLOR_BLUE_EX1 : MainForm.COLOR_BLUE_EX2;
            }
        }
    }
}

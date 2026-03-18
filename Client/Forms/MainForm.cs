using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ABSoftware;
using ABSoftware.UI;
using ABSoftware.Networking;
using ABSoftware.Networking.ClientSide;
using ABSoftware.Networking.Packets;
using ABSoftware.UI.Animations;

namespace Client
{
    public partial class MainForm : DraggableForm
    {
        public string LoginKey;

        public MainForm()
        {
            InitializeComponent();
        }

        public static Random rnd = new Random();

        public static Color COLOR_BLACK = Color.FromArgb(52, 52, 52);
        public static Color COLOR_BLACK_DARKER = Color.FromArgb(48, 48, 48);
        public static Color COLOR_WHITE = Color.FromArgb(255, 255, 255);
        public static Color COLOR_WHITE_DARKER = Color.FromArgb(200, 200, 200);
        public static Color COLOR_BLUE = Color.FromArgb(47, 48, 97);
        public static Color COLOR_BLUE_LIGHTER = Color.FromArgb(97, 94, 148);
        public static Color COLOR_BLUE_EX1 = Color.FromArgb(85, 83, 136);
        public static Color COLOR_BLUE_EX2 = Color.FromArgb(115, 113, 166);
        public static Color COLOR_PURPLE = Color.FromArgb(194, 87, 119);

        ArrayList<Group> groups = new ArrayList<Group>();

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        public Group AddGroup(string groupName)
        {
            DraggablePanel groupPanel = new DraggablePanel();
            groupPanel.Dock = DockStyle.Top;
            groupPanel.Size = new Size(0, 30);
            groupPanel.BackColor = COLOR_BLUE;
            groupPanel.Padding = new Padding(5, 5, 5, 5);

            Button expandCollapseGroupButton = new Button();
            expandCollapseGroupButton.Dock = DockStyle.Left;
            expandCollapseGroupButton.BackgroundImage = Properties.Resources.arrow_right;
            expandCollapseGroupButton.BackgroundImageLayout = ImageLayout.Zoom;
            expandCollapseGroupButton.FlatStyle = FlatStyle.Flat;
            expandCollapseGroupButton.FlatAppearance.BorderSize = 0;
            expandCollapseGroupButton.Size = new Size(20, 30);

            Button deleteGroupButton = new Button();
            deleteGroupButton.Dock = DockStyle.Right;
            deleteGroupButton.BackgroundImage = Properties.Resources.remove_folder;
            deleteGroupButton.BackgroundImageLayout = ImageLayout.Zoom;
            deleteGroupButton.FlatStyle = FlatStyle.Flat;
            deleteGroupButton.FlatAppearance.BorderSize = 0;
            deleteGroupButton.Size = new Size(20, 30);

            Button addTaskButton = new Button();
            addTaskButton.Dock = DockStyle.Right;
            addTaskButton.BackgroundImage = Properties.Resources.plus;
            addTaskButton.BackgroundImageLayout = ImageLayout.Zoom;
            addTaskButton.FlatStyle = FlatStyle.Flat;
            addTaskButton.FlatAppearance.BorderSize = 0;
            addTaskButton.Size = new Size(20, 30);

            DraggableLabel groupLabel = new DraggableLabel();
            groupLabel.AutoSize = false;
            groupLabel.Text = groupName;
            groupLabel.Dock = DockStyle.Left;
            groupLabel.ForeColor = COLOR_WHITE;
            groupLabel.Font = new Font(groupLabel.Font.FontFamily, 10f, FontStyle.Bold);
            groupLabel.TextAlign = ContentAlignment.MiddleLeft;
            groupLabel.Padding = new Padding(5, 0, 0, 0);

            DraggablePanel tasksPanel = new DraggablePanel();
            tasksPanel.Dock = DockStyle.Top;
            tasksPanel.Size = new Size(0, 0);
            tasksPanel.BackColor = COLOR_BLUE_LIGHTER;
            tasksPanel.Padding = new Padding(5, 5, 5, 5);
            tasksPanel.Visible = false;

            DraggablePanel spacerPanel = new DraggablePanel();
            spacerPanel.Dock = DockStyle.Top;
            spacerPanel.Size = new Size(0, 5);
            spacerPanel.BackColor = COLOR_BLACK_DARKER;

            Group group = new Group(groupName, groupPanel, spacerPanel, tasksPanel);

            expandCollapseGroupButton.Click += (sender, e) => 
            { 
                tasksPanel.Visible = !tasksPanel.Visible;
                expandCollapseGroupButton.BackgroundImage = tasksPanel.Visible ? Properties.Resources.arrow_down : Properties.Resources.arrow_right;
            };

            deleteGroupButton.Click += (sender, e) =>
            {
                /*groups.Remove(group);

                TasksList.Controls.Remove(groupPanel);
                TasksList.Controls.Remove(tasksPanel);
                TasksList.Controls.Remove(spacerPanel);*/

                Program.NetClient.SendPacket(new DeleteGroupPacket(groupName, LoginKey), new Action<IPacket, PendingPacket>((responsePacket, pendingPacket) =>
                {
                    StatusResponsePacket statusResponsePacket = (StatusResponsePacket)responsePacket;

                    if (statusResponsePacket.status == StatusResponsePacket.Status.Success)
                    {
                        if(InvokeRequired)
                        {
                            Invoke(new Action(() => 
                            {
                                groups.Remove(group);

                                TasksList.Controls.Remove(groupPanel);
                                TasksList.Controls.Remove(tasksPanel);
                                TasksList.Controls.Remove(spacerPanel);
                            }));
                        }
                        else
                        {
                            groups.Remove(group);

                            TasksList.Controls.Remove(groupPanel);
                            TasksList.Controls.Remove(tasksPanel);
                            TasksList.Controls.Remove(spacerPanel);
                        }
                    }
                    else
                        MessagePopupForm.ShowMessage(statusResponsePacket.data);
                }));
            };

            addTaskButton.Click += (sender, e) =>
            {
                NewTaskForm newTaskForm = new NewTaskForm();
                DialogResult result = newTaskForm.ShowDialog();

                if (result != DialogResult.OK)
                    return;

                string taskData = newTaskForm.TaskName;

                if(group.tasks.FirstOrDefault(t => t.TaskData == taskData) != null)
                {
                    MessagePopupForm.ShowMessage("Task with this name already exists.");
                    return;
                }

                //AddTask(group, taskData, false);

                Program.NetClient.SendPacket(new CreateTaskPacket(groupName, taskData, LoginKey), new Action<IPacket, PendingPacket>((responsePacket, pendingPacket) =>
                {
                    StatusResponsePacket statusResponsePacket = (StatusResponsePacket)responsePacket;

                    if (statusResponsePacket.status == StatusResponsePacket.Status.Success)
                    {
                        if (InvokeRequired)
                        {
                            Invoke(new Action(() =>
                            {
                                AddTask(group, taskData, false);
                            }));
                        }
                        else
                        {
                            AddTask(group, taskData, false);
                        }
                    }
                    else
                        MessagePopupForm.ShowMessage(statusResponsePacket.data);
                }));
            };

            groupPanel.Controls.Add(groupLabel);
            groupPanel.Controls.Add(expandCollapseGroupButton);
            groupPanel.Controls.Add(addTaskButton);
            groupPanel.Controls.Add(deleteGroupButton);

            if(TasksList.InvokeRequired)
            {
                TasksList.Invoke(new Action(() => 
                {
                    TasksList.Controls.Add(groupPanel);
                    TasksList.Controls.Add(tasksPanel);
                    TasksList.Controls.Add(spacerPanel);
                    TasksList.Controls.SetChildIndex(groupPanel, 0);
                    TasksList.Controls.SetChildIndex(tasksPanel, 0);
                    TasksList.Controls.SetChildIndex(spacerPanel, 0);
                }));
            }
            else
            {
                TasksList.Controls.Add(groupPanel);
                TasksList.Controls.Add(tasksPanel);
                TasksList.Controls.Add(spacerPanel);
                TasksList.Controls.SetChildIndex(groupPanel, 0);
                TasksList.Controls.SetChildIndex(tasksPanel, 0);
                TasksList.Controls.SetChildIndex(spacerPanel, 0);
            }

            groups.Add(group);

            tasksPanel.Width = groupPanel.Width;

            return group;
        }

        public void RemoveGroup(string groupName)
        {
            Group group = groups.FirstOrDefault(g => g.groupName == groupName);

            if(group != null)
            {
                TasksList.Controls.Remove(group.groupPanel);
                TasksList.Controls.Remove(group.tasksPanel);
                TasksList.Controls.Remove(group.spacerPanel);

                groups.Remove(group);
            }
        }

        public Task AddTask(Group group, string taskData, bool done)
        {
            DraggablePanel taskPanel = new DraggablePanel();
            taskPanel.Dock = DockStyle.Top;
            taskPanel.Size = new Size(0, 30);
            taskPanel.BackColor = group.tasks.Size % 2 == 0 ? COLOR_BLUE_EX1 : COLOR_BLUE_EX2;
            taskPanel.Padding = new Padding(5, 5, 5, 5);

            Label taskLabel = new Label();
            taskLabel.AutoSize = false;
            taskLabel.Text = taskData;
            taskLabel.Dock = DockStyle.Fill;
            taskLabel.ForeColor = COLOR_WHITE;
            taskLabel.Font = new Font(group.groupPanel.Font.FontFamily, 8f, FontStyle.Bold);
            taskLabel.TextAlign = ContentAlignment.MiddleLeft;
            taskLabel.Padding = new Padding(5, 0, 0, 0);

            Button removeTaskButton = new Button();
            removeTaskButton.Dock = DockStyle.Right;
            removeTaskButton.BackgroundImage = Properties.Resources.cross;
            removeTaskButton.BackgroundImageLayout = ImageLayout.Zoom;
            removeTaskButton.FlatStyle = FlatStyle.Flat;
            removeTaskButton.FlatAppearance.BorderSize = 0;
            removeTaskButton.Size = new Size(20, 30);

            Button ascendTaskButton = new Button();
            ascendTaskButton.Dock = DockStyle.Right;
            ascendTaskButton.BackgroundImage = Properties.Resources.arrow_up;
            ascendTaskButton.BackgroundImageLayout = ImageLayout.Zoom;
            ascendTaskButton.FlatStyle = FlatStyle.Flat;
            ascendTaskButton.FlatAppearance.BorderSize = 0;
            ascendTaskButton.Size = new Size(20, 30);

            Button descendTaskButton = new Button();
            descendTaskButton.Dock = DockStyle.Right;
            descendTaskButton.BackgroundImage = Properties.Resources.arrow_down;
            descendTaskButton.BackgroundImageLayout = ImageLayout.Zoom;
            descendTaskButton.FlatStyle = FlatStyle.Flat;
            descendTaskButton.FlatAppearance.BorderSize = 0;
            descendTaskButton.Size = new Size(20, 30);

            Task task = new Task(taskData, taskPanel, taskLabel);

            task.SwitchState(done);

            taskLabel.MouseDown += (tlSender, tlE) =>
            {
                //task.SwitchState();
                Program.NetClient.SendPacket(new SwitchTaskStatePacket(group.groupName, taskData, !task.Done, LoginKey), new Action<IPacket, PendingPacket>((responsePacket, pendingPacket) =>
                {
                    StatusResponsePacket statusResponsePacket = (StatusResponsePacket)responsePacket;

                    if (statusResponsePacket.status == StatusResponsePacket.Status.Success)
                    {
                        if(InvokeRequired)
                        {
                            Invoke(new Action(() =>
                            {
                                task.SwitchState();
                            }));
                        }
                        else
                        {
                            task.SwitchState();
                        }
                    }
                    else
                        MessagePopupForm.ShowMessage(statusResponsePacket.data);
                }));
            };

            removeTaskButton.Click += (rtSender, rtE) =>
            {
                /*group.tasksPanel.Controls.Remove(taskPanel);

                group.RemoveTask(task);*/

                Program.NetClient.SendPacket(new DeleteTaskPacket(group.groupName, taskData, LoginKey), new Action<IPacket, PendingPacket>((responsePacket, pendingPacket) =>
                {
                    StatusResponsePacket statusResponsePacket = (StatusResponsePacket)responsePacket;

                    if (statusResponsePacket.status == StatusResponsePacket.Status.Success)
                    {
                        if (InvokeRequired)
                        {
                            Invoke(new Action(() =>
                            {
                                group.tasksPanel.Controls.Remove(taskPanel);

                                group.RemoveTask(task);
                            }));
                        }
                        else
                        {
                            group.tasksPanel.Controls.Remove(taskPanel);

                            group.RemoveTask(task);
                        }
                    }
                    else
                        MessagePopupForm.ShowMessage(statusResponsePacket.data);
                }));
            };

            ascendTaskButton.Click += (atSender, atE) =>
            {
                int index = group.tasksPanel.Controls.GetChildIndex(taskPanel);

                group.tasksPanel.Controls.SetChildIndex(taskPanel, index + 1);
                group.SwapTasks(index, index + 1);
                group.RecolorTaskBackgrounds();
            };

            descendTaskButton.Click += (dtSender, dtE) =>
            {
                int index = group.tasksPanel.Controls.GetChildIndex(taskPanel);
                if (index - 1 < 0) return;

                group.tasksPanel.Controls.SetChildIndex(taskPanel, index - 1);
                group.SwapTasks(index, index - 1);
                group.RecolorTaskBackgrounds();
            };

            taskPanel.Controls.Add(taskLabel);
            taskPanel.Controls.Add(ascendTaskButton);
            taskPanel.Controls.Add(descendTaskButton);
            taskPanel.Controls.Add(removeTaskButton);

            group.tasksPanel.Controls.Add(taskPanel);

            taskLabel.MaximumSize = new Size(taskLabel.Width, 0);
            taskPanel.Height = Math.Max(taskPanel.Height, taskLabel.PreferredHeight + taskLabel.Padding.Vertical + 10);

            group.AddTask(task);

            return task;
        }

        private void NewFolderButton_Click(object sender, EventArgs e)
        {
            NewFolderForm newFolderForm = new NewFolderForm();
            DialogResult result = newFolderForm.ShowDialog();

            if(result == DialogResult.OK)
            {
                if (groups.FirstOrDefault(g => g.groupName == newFolderForm.GroupName) != null)
                {
                    MessagePopupForm.ShowMessage("Group with this name already exists.");
                    return; 
                }

                //AddGroup(newFolderForm.GroupName);
                Program.NetClient.SendPacket(new CreateGroupPacket(newFolderForm.GroupName, LoginKey), new Action<IPacket, PendingPacket>((responsePacket, pendingPacket) =>
                {
                    StatusResponsePacket statusResponsePacket = (StatusResponsePacket)responsePacket;

                    if (statusResponsePacket.status == StatusResponsePacket.Status.Success)
                    {
                        if(InvokeRequired)
                        {
                            Invoke(new Action(() =>
                            {
                                AddGroup(newFolderForm.GroupName);
                            }));
                        }
                        else
                        {
                            AddGroup(newFolderForm.GroupName);
                        }
                    }
                    else
                        MessagePopupForm.ShowMessage(statusResponsePacket.data);
                }));
            }
        }

        void UpdateGroupsAndTasks()
        {
            groups.Clear();
            TasksList.Controls.Clear();

            Program.NetClient.SendPacket(new TasksDataPacket(LoginKey), new Action<IPacket, PendingPacket>((packet, pendingPacket) =>
            {
                StatusResponsePacket responsePacket = (StatusResponsePacket)packet;
                if (responsePacket.status == StatusResponsePacket.Status.OK)
                {
                    if (InvokeRequired)
                    {
                        Invoke(new Action(() =>
                        {
                            HandleNetTasksData(responsePacket.data);
                        }));
                    }
                    else
                    {
                        HandleNetTasksData(responsePacket.data);
                    }
                }
                else
                    MessagePopupForm.ShowMessage($"An error has occured while trying to request data. Error information: {responsePacket.data}");
            }));
        }

        private void RefreshDataButton_Click(object sender, EventArgs e)
        {
            UpdateGroupsAndTasks();
        }

        void HandleNetTasksData(string data)
        {
            KLIN klin = new KLIN(data);

            KLINToken[] groups = klin["groups"].Children;
            int groupsCount = klin["groups"].ChildrenCount;
            for (int i = 0; i < groupsCount; i++)
            {
                Group group = AddGroup(groups[i].PropertyName);

                KLINToken[] tasks = groups[i].Children;
                int tasksCount = groups[i].ChildrenCount;
                for(int j = 0; j < tasksCount; j++)
                {
                    AddTask(group, tasks[j].PropertyName, bool.Parse(tasks[j].PropertyObject.ToString()));
                }
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //RefreshDataButton_Click(sender, e);
            UpdateGroupsAndTasks();
        }
    }
}

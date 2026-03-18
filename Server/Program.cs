using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABSoftware;
using ABSoftware.Networking.ServerSide;
using ABSoftware.Networking.Packets;
using ABSoftware.Networking;
using System.Net.Sockets;
using Microsoft.Data.Sqlite;

namespace Server
{
    public class Program : NetworkServer
    {
        public static Program instance;

        static void Main(string[] args)
        {
            instance = new Program();
            instance.Start();
        }

        public Program() : base(5050)
        {
            Console.WriteLine("Initializing database...");
            DatabaseController.InitializeDatabase();
            Console.WriteLine("Database initialized!");
        }

        public override void OnStart()
        {
            Console.WriteLine($"Server is online! (Port {this.Port})");
        }

        public override void OnStop()
        {
            Console.WriteLine("Server is offline!");
        }

        public override void OnPacketIn(TcpClient client, IPacket packet, string UPID)
        {
            int packetId = packet.GetPacketId();
            switch (packetId)
            {
                case 0:
                    {
                        TasksDataPacket tasksDataPacket = (TasksDataPacket)packet;
                        int userId = DatabaseController.GetLoggedInUserID(tasksDataPacket.loginKey);
                        if (userId == -1)
                            return;
                        ArrayList<(string, string, bool)> groupsAndTasks = DatabaseController.FetchUserGroupsAndTasks(userId);
                        KLIN klin = new KLIN();
                        klin["groups"].PropertyObject = null;

                        for(int i = 0; i < groupsAndTasks.Size; i++)
                        {
                            klin["groups"][groupsAndTasks[i].Item1][groupsAndTasks[i].Item2].PropertyObject = groupsAndTasks[i].Item3;
                        }

                        SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.OK, klin.ToString()));
                    }
                    break;
                case 1:
                    {
                        CreateGroupPacket createGroupPacket = (CreateGroupPacket)packet;
                        int userId = DatabaseController.GetLoggedInUserID(createGroupPacket.loginKey);
                        if(userId == -1)
                            return;

                        if(DatabaseController.GetGroup(createGroupPacket.groupName, userId).Item1 == -1)
                        {
                            DatabaseController.AddGroup(createGroupPacket.groupName, userId);
                            SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Success, string.Empty));
                        }
                        else
                        {
                            SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Failed, "Group with this name already exists."));
                        }
                    }
                    break;
                case 2:
                    {
                        CreateTaskPacket createTaskPacket = (CreateTaskPacket)packet;
                        int userId = DatabaseController.GetLoggedInUserID(createTaskPacket.loginKey);
                        if (userId == -1)
                            return;
                        (int, string, int) group = DatabaseController.GetGroup(createTaskPacket.groupName, userId);

                        if(group.Item1 == -1)
                        {
                            SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Failed, "Group doesn't exist."));
                            return;
                        }

                        if (DatabaseController.GetTask(group.Item1, createTaskPacket.taskName).Item1 == -1)
                        {
                            DatabaseController.AddTask(createTaskPacket.taskName, group.Item1, false);
                            SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Success, string.Empty));
                        }
                        else
                        {
                            SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Failed, "Task with this name already exists."));
                        }
                    }
                    break;
                case 4:
                    {
                        RegisterUserPacket registerUserPacket = (RegisterUserPacket)packet;

                        if(registerUserPacket.username.Length < 4)
                        {
                            SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Failed, "The username length can't be lower than 4."));
                            return;
                        }

                        if (registerUserPacket.password.Length < 2)
                        {
                            SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Failed, "The password length can't be lower than 2."));
                            return;
                        }

                        if (DatabaseController.GetUser(registerUserPacket.username).Item1 == -1)
                        {
                            DatabaseController.AddUser(registerUserPacket.username, ABHA256.Hash(Encoding.UTF8.GetBytes(registerUserPacket.password)), "none");
                            SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Success, string.Empty));
                        }
                        else
                        {
                            SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Failed, "An account with this username already exists."));
                        }
                    }
                    break;
                case 5:
                    {
                        LoginUserPacket loginUserPacket = (LoginUserPacket)packet;
                        (int, string, string) user = DatabaseController.GetUser(loginUserPacket.username);
                        if (user.Item1 == -1)
                        {
                            SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Failed, "An account with this username doesn't exist."));
                        }
                        else
                        {
                            if (user.Item3 == ABHA256.Hash(Encoding.UTF8.GetBytes(loginUserPacket.password)))
                            {
                                string newLoginHash = ABHA256.Hash(Encoding.UTF8.GetBytes($"{user.Item2}{user.Item3}{DateTime.Now.Ticks}"));
                                DatabaseController.UpdateUserLoginHash(user.Item1, newLoginHash);
                                SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Success, newLoginHash));
                            }
                            else
                            {
                                SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Failed, "The password is wrong"));
                            }
                        }
                    }
                    break;
                case 6:
                    {
                        DeleteGroupPacket deleteGroupPacket = (DeleteGroupPacket)packet;
                        int userId = DatabaseController.GetLoggedInUserID(deleteGroupPacket.loginKey);
                        if (userId == -1)
                            return;

                        (int, string, int) group = DatabaseController.GetGroup(deleteGroupPacket.groupName, userId);
                        if(group.Item1 != -1)
                        {
                            DatabaseController.DeleteGroupAndTasks(group.Item1);
                            SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Success, string.Empty));
                        }
                        else
                        {
                            SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Failed, "Group doesn't exist."));
                        }
                    }
                    break;
                case 7:
                    {
                        DeleteTaskPacket deleteTaskPacket = (DeleteTaskPacket)packet;
                        int userId = DatabaseController.GetLoggedInUserID(deleteTaskPacket.loginKey);
                        if (userId == -1)
                            return;

                        (int, string, int) group = DatabaseController.GetGroup(deleteTaskPacket.groupName, userId);
                        if (group.Item1 == -1)
                        {
                            SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Failed, "Group doesn't exist."));
                            return;
                        }
                        
                        (int, string, int, bool) task = DatabaseController.GetTask(group.Item1, deleteTaskPacket.taskName);
                        if (task.Item1 != -1)
                        {
                            DatabaseController.DeleteTask(group.Item1, deleteTaskPacket.taskName);
                            SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Success, string.Empty));
                        }
                        else
                        {
                            SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Failed, "Task doesn't exist."));
                        }
                    }
                    break;
                case 8:
                    {
                        SwitchTaskStatePacket switchTaskStatePacket = (SwitchTaskStatePacket)packet;
                        int userId = DatabaseController.GetLoggedInUserID(switchTaskStatePacket.loginKey);
                        if (userId == -1)
                            return;

                        (int, string, int) group = DatabaseController.GetGroup(switchTaskStatePacket.groupName, userId);
                        if (group.Item1 == -1)
                        {
                            SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Failed, "Group doesn't exist."));
                            return;
                        }

                        (int, string, int, bool) task = DatabaseController.GetTask(group.Item1, switchTaskStatePacket.taskName);
                        if (task.Item1 == -1)
                        {
                            SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Failed, "Task doesn't exist."));
                            return;
                        }

                        DatabaseController.UpdateTaskState(task.Item1, switchTaskStatePacket.taskState);
                        SendPacket(client, UPID, new StatusResponsePacket(StatusResponsePacket.Status.Success, string.Empty));
                    }
                    break;
            }
        }
    }
}

using Microsoft.AspNet.SignalR;
using MvcClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcClient
{
    public class ChatHub : Hub
    {
        static string[] colors = new string[] { "#ff4f4f", "#ff9b4f", "#ffca4f",  "#d3ff4f",  "#4fffa1", "#4fffed", "#4fcdff", "#4fa1ff", "#4f69ff", "#904fff", "#cd4fff", "#ff4ff9", "#ff4fb3" };
        static List<User> Users = new List<User>();
        static Random rnd = new Random();
        readonly ServiceChat.Service1Client client = new ServiceChat.Service1Client();

        // Отправка сообщений
        public void Send(string name, string message, string color)
        {
            if(message != "")
            {
                DateTime time = DateTime.Now;
                client.SendMsg(name, message, time);
                Clients.All.addMessage(name, $"{time:HH:mm}", message, color);
            }
        }

        // Подключение нового пользователя
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;
            var color = colors[rnd.Next(0, 12)];
            client.Connect(userName, color);
            if (!Users.Any(x => x.ConnectionId == id))
            {
                foreach (var item in client.GetChats())
                {
                    Clients.Caller.addMessage(item.User.Name, $"{item.SendTime:HH:mm}", item.Content, item.User.ColorOfName);
                }
                Users.Add(new User { ConnectionId = id, Name = userName }); ;

                // Посылаем сообщение текущему пользователю
                Clients.Caller.onConnected(id, Users, color);

                // Посылаем сообщение всем пользователям, кроме текущего
                Clients.AllExcept(id).onNewUserConnected(id, userName, Users);
            }
        }

        // Отключение пользователя
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                var id = Context.ConnectionId;
                var name = Users.FirstOrDefault(x => x.ConnectionId == id).Name;
                Users.Remove(item);
                Clients.All.onUserDisconnected(id, name);
            }

            return base.OnDisconnected(stopCalled);
        }
    }
}
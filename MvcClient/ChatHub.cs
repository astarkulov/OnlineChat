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
        static List<User> Users = new List<User>();
        ServiceChat.Service1Client client = new ServiceChat.Service1Client();

        // Отправка сообщений
        public void Send(string name, string message)
        {
            DateTime time = DateTime.Now;
            client.SendMsg(name, message, time);
            Clients.All.addMessage($"{name} {time:HH:mm:ss}", message);
        }

        // Подключение нового пользователя
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;
            client.Connect(userName);
            if (!Users.Any(x => x.ConnectionId == id))
            {
                var list = client.GetUsers();
                foreach (var item in client.GetChats())
                {
                    var user = list.FirstOrDefault(u => u.Id == item.SenderId);
                    Clients.Caller.addMessage($"{user.Name} {item.SendTime:HH:mm:ss}", item.Content);
                }
                Users.Add(new User { ConnectionId = id, Name = userName });

                // Посылаем сообщение текущему пользователю
                Clients.Caller.onConnected(id, userName, Users);

                // Посылаем сообщение всем пользователям, кроме текущего
                Clients.AllExcept(id).onNewUserConnected(id, userName);
            }
        }

        // Отключение пользователя
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                Users.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.Name);
            }

            return base.OnDisconnected(stopCalled);
        }
    }
}
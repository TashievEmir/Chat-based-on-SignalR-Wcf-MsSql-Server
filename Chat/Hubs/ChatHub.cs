using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Chat.ServiceReferenceWcf;
namespace Chat.Hubs
{ 
    public class ChatHub : Hub
    {
        Service1Client client =new Service1Client();
        static List<User> Users = new List<User>();
        // Отправка сообщений
        public void Send(int id, string name, string color, string message)
        {
            GroupMessage groupMessage = new GroupMessage()
            {
                GroupMessageSenderId = id,
                GroupMessageName=message,
                GroupMessageColor=color
            };
            client.AddGroupMessage(groupMessage);
            Clients.All.addMessage(name, message,color);
        }
        public void SendPrivate(int chatId, int senderid, string name, string color, string message)
        {
            PrivateMessage privateMessage = new PrivateMessage()
            {
                PrivateMessageChatId = chatId,
                PrivateMessageSenderId =senderid, 
                PrivateMessageName=message,
                PrivateMessageColor=color,
            };
            client.AddPrivateMessage(privateMessage);
            Clients.All.addMessagePrivate(chatId,name, message, color);
        }
        // Подключение нового пользователя
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;

            if (!Users.Any(x => x.ConnectionId == id))
            {
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
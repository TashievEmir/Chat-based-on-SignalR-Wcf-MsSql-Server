using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatTask
{
    public class PrivateMessageRepository : IRepository<PrivateMessage>
    {
        ChatDBEntities context;
        public PrivateMessageRepository(ChatDBEntities context)
        {
            this.context = context;
        }
        public void Create(PrivateMessage item)
        {
            context.PrivateMessage.Add(item);
            Save();
        }
        public PrivateMessage Get(int id)
        {
            return context.PrivateMessage.FirstOrDefault(u => u.PrivateMessageSenderId == id);
        }
        public IEnumerable<PrivateMessage> GetList()
        {
            return context.PrivateMessage.ToList();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
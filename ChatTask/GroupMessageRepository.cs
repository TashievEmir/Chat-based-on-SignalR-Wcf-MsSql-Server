using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatTask
{
    public class GroupMessageRepository : IRepository<GroupMessage>
    {
        Chat_DbEntities context;
        public GroupMessageRepository(Chat_DbEntities context)
        {
            this.context = context;
        }
        public void Create(GroupMessage item)
        {
            context.GroupMessage.Add(item);
            Save();
        }
        public GroupMessage Get(int id)
        {
            return context.GroupMessage.FirstOrDefault(u => u.GroupMessageSenderId == id);
        }
        public IEnumerable<GroupMessage> GetList()
        {
            return context.GroupMessage.ToList();
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
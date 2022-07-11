using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatTask
{
    public class GroupMessageRepository : IRepository<GroupMessage>
    {
        ChatDBEntities context;
        public GroupMessageRepository(ChatDBEntities context)
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
            return context.GroupMessage.FirstOrDefault(u => u.GroupMessageId == id);
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
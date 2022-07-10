using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChatTask
{
    public class UsersRepository : IRepository<Users>
    {
        Chat_DbEntities context;
        public UsersRepository(Chat_DbEntities context)
        {
            this.context = context;
        }
        public void Create(Users item)
        {
            context.Users.Add(item);
            Save();
            
        }

        public Users Get(int id)
        {
            return  context.Users.FirstOrDefault(u => u.UserId == id);         
        }

        public IEnumerable<Users> GetList()
        {
            return context.Users.ToList();
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
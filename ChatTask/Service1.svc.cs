using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ChatTask
{
    
    public class Service1 : IService1
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public void AddGroupMessage(GroupMessage groupMessage)
        {
            
            unitOfWork.GroupMessage.Create(groupMessage);
        }

        public void AddPrivateMessage(PrivateMessage privateMessage)
        {
            unitOfWork.PrivateMessage.Create(privateMessage);
        }

        public void AddUser(string username, string password)
        {
            string color = Colors.generateColor();
            Users user = new Users { UserName = username, 
                                     UserPassword = password,   
                                     UserColor =color};
            unitOfWork.Users.Create(user);
        }

        public bool CheckUser(string username, string password)
        {
            var user = unitOfWork.Users.GetList();
            var check = user.FirstOrDefault(u => u.UserName == username && u.UserPassword == password);
            if (check != null) return true;
            else return false;
        }

        public List<GroupMessage> GetGroupMessages()
        {
            return unitOfWork.GroupMessage.GetList().ToList();
        }

        public List<PrivateMessage> GetPrivateMessages()
        {
            return unitOfWork.PrivateMessage.GetList().ToList();
        }

        public Users GetUserByName(string name)
        {
            var user=unitOfWork.Users.GetList();
            var check = user.FirstOrDefault(u => u.UserName == name);
            if(check!=null) return check;
            else return null;
        }
        public List<Users> GetUsersWithoutThisId(int id)
        {
            var users=unitOfWork.Users.GetList();
            var check = users.Where(u => u.UserId != id).ToList();
            return check;
        }
    }
}

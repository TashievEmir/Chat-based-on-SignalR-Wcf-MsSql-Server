using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ChatTask
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        void AddUser(string username, string password);

        [OperationContract]
        void AddPrivateMessage(PrivateMessage privateMessage);

        [OperationContract]
        void AddGroupMessage(GroupMessage groupMessage);

        [OperationContract]
        bool CheckUser(string username, string password);

        [OperationContract]
        Users GetUserByName(string name);

        [OperationContract]
        List<Users> GetUsersWithoutThisId(int id);

        [OperationContract]
        List<GroupMessage> GetGroupMessages();

        [OperationContract]
        List<PrivateMessage> GetPrivateMessages();
    }


    // Используйте контракт данных, как показано в примере ниже, чтобы добавить составные типы к операциям служб.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}

using OnlineChat.DomainModel.Common;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IChatService
    {

        [OperationContract]
        List<User> GetUsers();
        [OperationContract]
        Chat[] GetChats();
        [OperationContract]
        void Connect(string Name, string color);
        [OperationContract]
        void SaveMsg(string SenderName, string Content, DateTime SendTime);
        [OperationContract]
        void ClearTheHistory();

    }
}

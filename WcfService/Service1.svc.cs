using OnlineChat.DataAccessLayer.Common;
using OnlineChat.DataAccessLayer.GeneralBook;
using OnlineChat.DomainModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы Service1.svc или Service1.svc.cs в обозревателе решений и начните отладку.
    public class Service1 : IService1
    {
        public void Connect(string Name)
        {
            var uow = new GeneralBookUnitOfWork(new EntityContextFactory());
            try
            {
                uow.GetCommonRepository<User>().FindBy(x => x.Name == Name).First();
            }
            catch
            {
                User user = new User()
                {
                    Name = Name
                };
                uow.GetCommonRepository<User>().Add(user);
                uow.GetCommonRepository<User>().Save();
                return;
            }
        }
        public void SendMsg(string SenderName, string Content, DateTime SendTime)
        {
            var uow = new GeneralBookUnitOfWork(new EntityContextFactory());

            var user = uow.GetCommonRepository<User>().GetAll().FirstOrDefault(u => u.Name == SenderName);
            uow.GetCommonRepository<Chat>().Add(new Chat() { SenderId = user.Id, Content = Content, SendTime = SendTime });
            uow.GetCommonRepository<Chat>().Save();
        }
        public List<Chat> GetChats()
        {
            var uow = new GeneralBookUnitOfWork(new EntityContextFactory());
            return uow.GetCommonRepository<Chat>().GetAll().ToList();
        }

        public List<User> GetUsers()
        {
            var uow = new GeneralBookUnitOfWork(new EntityContextFactory());
            return uow.GetCommonRepository<User>().GetAll().ToList();
        }
    }
}

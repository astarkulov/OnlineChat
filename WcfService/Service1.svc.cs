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
    public class Service1 : IService1
    {
        private readonly GeneralBookUnitOfWork uow = new GeneralBookUnitOfWork(new EntityContextFactory());
        public bool Connect(string Name, string color)
       {
            try
            {
                uow.GetCommonRepository<User>().FindBy(x => x.Name == Name).First();
            }
            catch
            {
                User user = new User()
                {
                    Name = Name,
                    ColorOfName = color
                };
                uow.GetCommonRepository<User>().Add(user);
                uow.GetCommonRepository<User>().Save();
            }
            return true;
        }
        public void SendMsg(string SenderName, string Content, DateTime SendTime)
        {
            var user = uow.GetCommonRepository<User>().GetAll().FirstOrDefault(u => u.Name == SenderName);
            uow.GetCommonRepository<Chat>().Add(new Chat() { SenderId = user.Id, Content = Content, SendTime = SendTime });
            uow.GetCommonRepository<Chat>().Save();
        }
        public Chat[] GetChats()
        {
            return uow.GetCommonRepository<Chat>().Context.Set<Chat>().Include("User").ToArray();
        }

        public List<User> GetUsers()
        {
            return uow.GetCommonRepository<User>().GetAll().ToList();
        }
    }
}

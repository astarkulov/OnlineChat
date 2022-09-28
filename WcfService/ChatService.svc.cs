using OnlineChat.DataAccessLayer.Common;
using OnlineChat.DataAccessLayer.GeneralBook;
using OnlineChat.DomainModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WcfService
{
    public class Service1 : IChatService
    {
        public void Connect(string Name, string color)
        {
            using (GeneralBookUnitOfWork uow = new GeneralBookUnitOfWork(new EntityContextFactory()))
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
            }
        }
        public void SaveMsg(string SenderName, string Content, DateTime SendTime)
        {
            using (GeneralBookUnitOfWork uow = new GeneralBookUnitOfWork(new EntityContextFactory()))
            {
                var user = uow.GetCommonRepository<User>().GetAll().FirstOrDefault(u => u.Name == SenderName);
                uow.GetCommonRepository<Chat>().Add(new Chat() { SenderId = user.Id, Content = Content, SendTime = SendTime });
                uow.GetCommonRepository<Chat>().Save();
            }
        }
        public Chat[] GetChats()
        {
            using (GeneralBookUnitOfWork uow = new GeneralBookUnitOfWork(new EntityContextFactory()))
            {
                return uow.GetCommonRepository<Chat>().Context.Set<Chat>().Include("User").ToArray();
            }
        }

        public List<User> GetUsers()
        {
            using (GeneralBookUnitOfWork uow = new GeneralBookUnitOfWork(new EntityContextFactory()))
            {
                return uow.GetCommonRepository<User>().GetAll().ToList();
            }
        }
        public void ClearTheHistory()
        {
            using (GeneralBookUnitOfWork uow = new GeneralBookUnitOfWork(new EntityContextFactory()))
            {
                uow.GetCommonRepository<Chat>().DeleteRange(uow.GetCommonRepository<Chat>().GetAll().ToArray());
                uow.GetCommonRepository<Chat>().Save();
            }
        }
    }
}

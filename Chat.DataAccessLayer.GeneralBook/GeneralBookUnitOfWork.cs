using OnlineChat.DataAccessLayer.Common;
using OnlineChat.DataAccessLayer.GeneralBook;

namespace OnlineChat.DataAccessLayer.GeneralBook
{
    public class GeneralBookUnitOfWork : UnitOfWork<GeneralBookEntityContext>
    {
        public GeneralBookUnitOfWork(IEntityContextFactory factory) : base(factory)
        {
        }


    }
}

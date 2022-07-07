using OnlineChat.DomainModel.Common;
using System.Data.Common;
using System.Data.Entity;

namespace OnlineChat.DataAccessLayer.Common
{
    public class CommonEntityContext : DbContext
    {
        public CommonEntityContext(string connectionString) : base(connectionString)
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
    }
}
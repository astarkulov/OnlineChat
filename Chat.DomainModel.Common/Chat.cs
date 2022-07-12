using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OnlineChat.DomainModel.Common
{
    [Table("Chats", Schema = "dbo")]
    public class Chat
    {
        [Key]
        public int SenderId { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime SendTime { get; set; }
        [ForeignKey("SenderId")]
        public User User { get; set; }
    }
}
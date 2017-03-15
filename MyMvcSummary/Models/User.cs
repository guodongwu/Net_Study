using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace MyMvcSummary.Models
{
    public class User
    {
        [Key]
        //用户名
        public string UserName { get; set; }
        //用户的连接
        public virtual DbSet<Connection> Connections { get; set; }
        //用户房间集合
        public virtual DbSet<ConversationRoom> Rooms { get; set; }
        public User()
        {

        }
    }
}

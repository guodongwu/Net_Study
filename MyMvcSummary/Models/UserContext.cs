using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyMvcSummary.Models
{
    public class UserContext : DbContext
    {

        public UserContext()
            : base("name=UserContext")
        {

        }
        //用户集合
        public DbSet<User> Users { get; set; }
        //连接集合
        public DbSet<Connection> Connections { get; set; }
        //房间集合
        public DbSet<ConversationRoom> Rooms { get; set; }
    }
}
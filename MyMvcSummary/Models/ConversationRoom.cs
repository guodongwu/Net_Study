using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace MyMvcSummary.Models
{
    public class ConversationRoom
    {
        //房间名称
        [Key]
        public string RoomName { get; set; }
        //用户集合
        public virtual DbSet<User> Users { get; set; }
        public ConversationRoom()
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Final.Models;

namespace Final.DataBase
{
    public class Entity : DbContext
    {
        public Entity() : base(Addonet.Get())
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Tasks> Task { get; set; }
        public DbSet<Items> Items { get; set; }
    }
}
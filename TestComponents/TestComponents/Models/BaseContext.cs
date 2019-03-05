using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestComponents.Models;

namespace TestComponents.Models
{
    public class BaseContext : DbContext
    {
        public DbSet<ScheduleModel>Event { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcMasterDetail.Models
{
    public class FacultyContext : DbContext
    {
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
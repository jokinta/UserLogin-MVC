﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin1;

namespace StudentInfoSystem1
{
    class StudentInfoContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentInfoContext() : base(Properties.Settings.Default.DbConnect)
        {

        }
        
       

    }
}

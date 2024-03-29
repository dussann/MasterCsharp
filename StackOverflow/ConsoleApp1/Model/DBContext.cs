﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StackOverflow.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model
{
    public class DBContext: DbContext
    {
        
        public DbSet<User> User { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Answer> Answer { get; set; }
        public DbSet<Badge> Badge { get; set; }
        /*public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
            
        }*/
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 23));
            optionsBuilder.UseMySql("server=localhost;user=root;database=soentity;password=root;port=3306", serverVersion);            
            // optionsBuilder.UseMySql("server=localhost;user=root;database=soentity;password=root;port=3306", serverVersion).LogTo(Console.WriteLine, LogLevel.Information);
            //optionsBuilder.UseMySql(@"server=localhost;user=root;database=soentity;password=root;port=3306", serverVersion, o=>o.MaxBatchSize(100).MinBatchSize(1));
            
        }
       
    }
}

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;
using ConsoleApp1.Model;
using Microsoft.EntityFrameworkCore;
using StackOverflow.Data;
using StackOverflow.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace ConsoleApp1
{
   
    public class Program
    {
        static void Main(string[] args)
        {                 
            Program.InsertUsers(500000);
            // Program.ReadUser();
            //Program.DeleteUser();
            // Program.UpdateUser();

        }
        public static void InsertUsers(int n)
        {
            Stopwatch stopwatch = new Stopwatch();
            using (var context = new DBContext())
            {
                try
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    context.ChangeTracker.AutoDetectChangesEnabled = false;
                    for (int i = 0; i < n; i++)
                    {
                        context.User.Add(new User() { FirstName = "John" + i, Country = "USA", JobTitle = ".NET developer", Password = "123", UserName = "c# User" });
                    }
                }
                finally
                {
                    Console.WriteLine("Finally");
                    context.ChangeTracker.AutoDetectChangesEnabled = true;
                }
                stopwatch.Start();
                context.SaveChanges();
                stopwatch.Stop();
                Console.WriteLine("Insert {1} users - Elapsed Time is {0} ms============", stopwatch.ElapsedMilliseconds,n);
            }
        }       
       
        public static void ReadUser()
        {
            // context.User.AsNoTracking().
            using (var context = new DBContext())
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                User user = context.User.FirstOrDefault();
                stopwatch.Stop();
                Console.WriteLine("Read user - Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);               
            }

        }

        public static void DeleteUser()
        {

            using (var context = new DBContext())
            {
                         
                
                //entities.Database.ExecuteSqlCommand("TRUNCATE TABLE [Customers]");
                /*context.User.RemoveRange(context.User);                
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                //var a = context.User.FirstOrDefault();
                context.SaveChanges();
                stopwatch.Stop();
                Console.WriteLine("Delete all users - Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);*/
            }

        }
        public static void UpdateUser()
        {
            Stopwatch stopwatch = new Stopwatch();            
            using (DBContext context = new DBContext())
            {
                stopwatch.Start();
                User user = context.User.FirstOrDefault();
                user.UserName = "New username from console";
                context.SaveChanges();
                stopwatch.Stop();
                Console.WriteLine("Update user - Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            }
        }



        public static void ReadUsers1000()
                {
                    using (var context = new DBContext())
                    {
                        var list=context.User.ToList();                        
                    }
                }
        /*

                [Benchmark]
                public void UpdateUser()
                {
                    using (DBContext context = new DBContext())
                    {
                        User user = context.User.FirstOrDefault();
                        user.UserName = "New username from console";
                        context.SaveChanges();
                    }
                }

                          [Benchmark]
                          public void UpdateUsers1000()
                          {
                              using (DBContext context = new DBContext())
                              {               
                                  foreach (User user in context.User.Take(1000))
                                  {
                                      user.FirstName = "aaaaaaaaa";
                                  }
                                  context.SaveChanges();
                              }
                          }*/

        /* [Benchmark]
          public void DeleteUser()
          {
              using DBContext context = new DBContext();
              User user = context.User.FirstOrDefault();
              context.User.Remove(user);
              context.SaveChanges();
          }*/
    }
}

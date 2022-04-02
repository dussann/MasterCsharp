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
            
            // Program.InsertUser();
            Program.ReadUser();
        }
        public static void InsertUser()
        {
            Stopwatch stopwatch = new Stopwatch();
            using var context = new DBContext();             
            context.User.Add(new User() { FirstName="a",Country="USA",JobTitle=".NET developer",Password="123",UserName="c# User"});

            Console.WriteLine("************************");
            stopwatch.Start();
            context.SaveChanges();
            stopwatch.Stop();
            Console.WriteLine("************************");
            Console.WriteLine("Elapsed Time is {0} ms==================", stopwatch.ElapsedMilliseconds);
        }
        

       
        public static void ReadUser()
        {
            using (var context = new DBContext())
            {
                Stopwatch stopwatch = new Stopwatch();

                stopwatch.Start();
                context.User.FirstOrDefault();
                stopwatch.Stop();
                Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
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

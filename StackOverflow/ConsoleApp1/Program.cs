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
            try
            {
                Program.InsertUsers1();
                //Program.ReadUser();
                //Program.UpdateUser();
                //Program.DeleteUser();

                /*with one referece(aka eager loading)*/
                //Program.InsertUsersWithRef(500000);
                //Program.ReadUserRef();
                //Program.UpdateUserRef();
                //Program.DeleteUserRef();
                /*using (var context = new DBContext())
                {
                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();
                    User u1 = new User { UserName = "U1",JobTitle="aaaa",Password="123" };
                    
                    context.User.Add(u1);
                    
                    context.SaveChanges();                    
                    Console.Beep();
                }*/

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        public static void InsertUsers1()
        {

            using (var context = new DBContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                List<Badge> badges = new List<Badge>() {
                    new Badge() { Name="aaa",Description="aaa"},
                    new Badge() { Name="eee",Description="eee"},
                    new Badge() { Name="sss",Description="sss"}};

                context.User.Add(new User() { FirstName = "John", Country = "USA", JobTitle = ".NET developer", Password = "123", UserName = "c# User",Badges=badges });
                User u1 = new User() { FirstName = "John1", Country = "USA", JobTitle = ".NET developer", Password = "123", UserName = "c# User"};
                User u2 = new User() { FirstName = "John2", Country = "USA", JobTitle = ".NET developer", Password = "123", UserName = "c# User" };

                context.Badge.Add(new Badge() { Name = "aaa", Description = "aaa",Users=new List<User>() {u1,u2 } });
                
                context.SaveChanges();
                Console.Beep();
            }
        }
        public static void InsertUsersWithRef(int n)
        {
            Stopwatch stopwatch = new Stopwatch();
            using (var context = new DBContext())
            {                
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.ChangeTracker.AutoDetectChangesEnabled = false;                
                stopwatch.Start();
                for (int i = 0; i < n; i++)
                {
                    User user = new User { FirstName = "John", UserName = "JohnDoe", Password="123",Country="Canada",JobTitle="Senior Software Developer" };
                    user.Questions = new List<Question>() { new Question() { Content = "content", Header = "header" } };
                    context.User.Add(user);
                }
                context.ChangeTracker.AutoDetectChangesEnabled = true;
                context.ChangeTracker.DetectChanges();
                context.SaveChanges();
                stopwatch.Stop();
                Console.WriteLine("Insert {1} users - Elapsed Time is {0} ms============", stopwatch.ElapsedMilliseconds, context.User.ToArray().Length);
                Console.Beep();
            }
        }
        public static void InsertUsers(int n)
        {
            Stopwatch stopwatch = new Stopwatch();
            using (var context = new DBContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.ChangeTracker.AutoDetectChangesEnabled = false;
                
                stopwatch.Start();
                for (int i = 0; i < n; i++)
                {                    
                    context.User.Add(new User() { FirstName = "John", Country = "USA", JobTitle = ".NET developer", Password = "123", UserName = "c# User" });
                }
                context.ChangeTracker.DetectChanges();
                context.SaveChanges();
                stopwatch.Stop();
                Console.WriteLine("Insert {1} users - Elapsed Time is {0} ms============", stopwatch.ElapsedMilliseconds, n);
                Console.Beep();
            }
        }
       
        public static void ReadUserRef()
        {
            Stopwatch stopwatch = new Stopwatch();
            using (var context = new DBContext())
            {
                stopwatch.Start();
                var users = context.User.Include(u => u.Questions).ToArray();               
                stopwatch.Stop();
                Console.WriteLine("Read user - Elapsed Time is {0} ms records {1}", stopwatch.ElapsedMilliseconds,users.Length);
            }
            Console.Beep();
        }
        public static void ReadUser()
        {
            Stopwatch stopwatch = new Stopwatch();
            using (var context = new DBContext())
            {
                stopwatch.Start();
                var users = context.User.ToArray();               
                stopwatch.Stop();
                Console.WriteLine("Read user - Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            }
            Console.Beep();

        }
        public static void DeleteUser()
        {
            using (var context = new DBContext())
            {                
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                context.User.RemoveRange(context.User);
                context.SaveChanges();
                stopwatch.Stop();
                Console.WriteLine("Delete all users - Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            }
        }

        public static void DeleteUserRef()
        {
            using (var context = new DBContext())
            {                
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                context.User.RemoveRange(context.User);
                context.SaveChanges();
                stopwatch.Stop();
                Console.WriteLine("Delete all users - Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);
            }
        }
        public static void UpdateUser()
        {
            Stopwatch stopwatch = new Stopwatch();
            using (DBContext context = new DBContext())
            {
                stopwatch.Start();
                context.User.UpdateRange(context.User);                
                foreach (var user in context.User)
                {
                    user.UserName = "Update user name@";
                }
                context.SaveChanges();
                stopwatch.Stop();
                Console.WriteLine("Update user - Elapsed Time is {0} ms {1} rows", stopwatch.ElapsedMilliseconds, context.User.ToArray().Length);
            }
        }

        public static void UpdateUserRef()
        {
            Stopwatch stopwatch = new Stopwatch();
            using (DBContext context = new DBContext())
            {
                
                stopwatch.Start();
                // Eager loading
                context.User.UpdateRange(context.User.Include(user=>user.Questions));
                foreach (var user in context.User)
                {
                    user.UserName = "Update user name 2";
                    user.Questions.FirstOrDefault().Content = "Update content 2";
                }
                context.SaveChanges();
                stopwatch.Stop();
                var numberOfQuestions = context.Question.ToArray().Length;
                var numberOfUsers = context.User.ToArray().Length;  
                Console.WriteLine("Update user - Elapsed Time is {0} ms user {1} rows users {2} rows questions", stopwatch.ElapsedMilliseconds, numberOfUsers,numberOfQuestions);
            }
        }
    }
}

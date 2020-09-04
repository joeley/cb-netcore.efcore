using System;
using Asp.NetCore.DBFactory;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            string sqlStr = "server=joe;database=EFCore;uid=sa;pwd=root";
            using (var db = new DBContextFactory(sqlStr))
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }
            Console.WriteLine("Hello World!");
        }
    }
}

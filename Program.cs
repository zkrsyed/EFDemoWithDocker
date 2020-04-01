using System;
using dbdemo.Models;

namespace dbdemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var ninja = new Ninjas
            {
                Name = "SampsonSan",
                ServedInOniwaban = false,
                ClanId = 1

            };
            using (var context = new EFDemoContext())
            {
               // context.Database.Log = Console.WriteLine;
                context.Ninjas.Add(ninja);
                context.SaveChanges();
            }
            
            Console.WriteLine("Hello World!");
        }
    }
}

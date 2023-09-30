
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBug_Entities.Seeders
{
    public static class UserSeeder
    {
        public static void SeedUser(this DataContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            context.CreateUser("AAA", "New A");
            context.CreateUser("BBB", "New B");
            context.CreateUser("CCC", "New C");
            context.CreateUser("DDD", "New D");
            context.CreateUser("EEE", "New E");
        }

        private static void CreateUser(this DataContext context, string name, string surname)
        {
            context.Users.Add(new User()
            {
                
                Name = name,
                Surname = surname,
            });
            context.SaveChanges();
        }
    }
}

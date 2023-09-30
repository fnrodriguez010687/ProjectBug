
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBug_Entities.Seeders
{
    public static class ProjectSeeder
    {
        public static void SeedProject(this DataContext context)
        {
            if (context.Projects.Any())
            {
                return;
            }

            context.CreateProject("11111 1 11 11 1 11 11 1 1", "Project1");
            context.CreateProject("22222 2 22 22 2 22 22 2 2", "Project2");
            context.CreateProject("33333 3 33 33 3 33 33 3 3", "Project3");
            context.CreateProject("44444 4 44 44 4 44 44 4 4", "Project4");
            context.CreateProject("55555 5 55 55 5 55 55 5 5", "Project5");
        }

        private static void CreateProject(this DataContext context, string description, string name)
        {
            context.Projects.Add(new Project()
            {
               Description = description,
               Name = name,
            });
            context.SaveChanges();
        }
    }
}

using EFConsoleTutorial.Services;
using System;
using Models;
using EFConsoleTutorial.Domain;
using System.Linq;
using System.Data.Entity;

namespace EFConsoleTutorial
{
    class Program
    {
        static async void Main(string[] args)
        {
            Console.WriteLine("Hello World");

            TodoItem todoItem = new TodoItem()
            {
                IsComplete = false,
                Name = "Test 2"
            };

            Courses courses = new Courses()
            {
                Name = "Computer Science",
                Students = new List<Students>()
                {
                    new Students()
                    {
                        Name = "Chris"

                    }
                }
            };

            DataContext dataContext = new DataContext();
            var students = await dataContext.courses.Include(x => x.Students).ToListAsync();
            
            var todoItemEntityService = new EntityService<TodoItem>();

            var todolistitems = todoItemEntityService.GetAllOrN();

            var getitemById = todolistitems.SingleOrDefault(x => x.Id == 0);    

            var coursesEntityService = new EntityService<Courses>();


            Console.ReadLine();
        }
    }

}
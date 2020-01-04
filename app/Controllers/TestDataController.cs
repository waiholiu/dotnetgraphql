using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomNameGeneratorLibrary;

namespace app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestDataController : ControllerBase
    {

        ApplicationDbContext db;

        public TestDataController(ApplicationDbContext dbContext)
        {
            db = dbContext;
        }

        [HttpGet]
        public String Get()
        {

            db.Books.RemoveRange(db.Books);
            db.Authors.RemoveRange(db.Authors);
            db.SaveChanges();

            for (var i = 0; i < 100; i++)
            {

                var personGenerator = new PersonNameGenerator();
                var name = personGenerator.GenerateRandomFirstAndLastName();

                Author newAuthor = new Author()
                {
                    Name = name,
                    DateOfBirth = DateTime.Now.AddYears(-20),
                    Books = new List<Book>()
                };

                for (var j = 0; j < 4; j++)
                {
                    Book newBook = new Book()
                    {
                        DateOfPublication = DateTime.Now.AddMonths(-1),
                        Title = "The bibliography of " + personGenerator.GenerateRandomFirstAndLastName(),

                    };

                    newAuthor.Books.Add(newBook);

                }

                db.Authors.Add(newAuthor);


            }
            db.SaveChanges();

            return "all worked";
        }


    }
}

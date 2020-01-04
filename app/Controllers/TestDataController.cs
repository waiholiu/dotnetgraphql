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

            db.SalesInvoices.RemoveRange(db.SalesInvoices);
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
                        SalesInvoices = new List<SalesInvoice>()


                    };

                    for (var k = 0; k < 3; k++)
                    {
                        SalesInvoice newSale = new SalesInvoice();
                        newSale.CustomerName = personGenerator.GenerateRandomFirstAndLastName();
                        newSale.DateOfSale = DateTime.Now;
                        newSale.Price = 100;
                        newBook.SalesInvoices.Add(newSale);
                    }

                    newAuthor.Books.Add(newBook);

                }

                db.Authors.Add(newAuthor);


            }

            db.SaveChanges();

            return "all worked";
        }


    }
}

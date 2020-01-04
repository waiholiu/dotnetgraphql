
using System;
using System.Linq;

using GraphQL.Types;
using Microsoft.AspNetCore.Identity;



namespace app
{
    public class BookType : ObjectGraphType<Book>
    {

        public BookType(ApplicationDbContext db)
        {


            Field(x => x.Id);
            Field(x => x.Title);
            Field(x => x.DateOfPublication);
                        
        }
    }
}


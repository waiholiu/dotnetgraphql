
using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.AspNetCore.Identity;



namespace app
{
    public class BookType : ObjectGraphType<Book>
    {

        public BookType(ApplicationDbContext db, IDataLoaderContextAccessor accessor, IGetDataService dataService)
        {


            Field(x => x.Id);
            Field(x => x.Title);
            Field(x => x.DateOfPublication);


            // this is an example of when you want to load many records for the current record (many sales invoices for the single book)
            // this will get the bookIds of all the books you want to load and then load all the sales invoices for them in one call
            Field<ListGraphType<SalesInvoiceType>, IEnumerable<SalesInvoice>>()
                .Name("SalesInvoices")
                .ResolveAsync(ctx =>
                {
                    var loader = accessor.Context.GetOrAddCollectionBatchLoader<int, SalesInvoice>("GetSaleInvoicesByBookId",
                        dataService.GetSalesInvoicesAsync);

                    return loader.LoadAsync(ctx.Source.Id);
                });

            // this is an example of when you want to load a single record corresonding to the current record (the author record for the current book)
            // this will get the bookIds of all the books you want to load and then load all the authors for them in one call
            Field<AuthorType, Author>()
                .Name("Author")
                .ResolveAsync(ctx =>
                {
                    var loader = accessor.Context.GetOrAddBatchLoader<int, Author>("GetAuthorsById",
                    dataService.GetAuthorsByIdAsync);

                    return loader.LoadAsync(ctx.Source.AuthorId);
                });
            
            // this is an example of when you want to load a variable of a single record corresonding to the current record (the author name for the current book)
            // this will get the bookIds of all the books you want to load and then load all the authors for them in one call and then extracts the author's name
             Field<StringGraphType, String>()
                .Name("AuthorsName")
                .ResolveAsync(ctx =>
                {
                    var loader = accessor.Context.GetOrAddBatchLoader<int, String>("GetAuthorsName",
                    dataService.GetAuthorsNameAsync);

                    return loader.LoadAsync(ctx.Source.AuthorId);
                });
        }
    }
}


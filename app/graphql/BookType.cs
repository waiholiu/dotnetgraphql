
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
            Field<ListGraphType<SalesInvoiceType>, IEnumerable<SalesInvoice>>()
                .Name("SalesInvoices")
                .ResolveAsync(ctx =>
                {
                    var loader = accessor.Context.GetOrAddCollectionBatchLoader<int, SalesInvoice>("GetSaleInvoicesByBookId",
                        dataService.GetSalesInvoicesAsync);

                    return loader.LoadAsync(ctx.Source.Id);
                });

            Field<AuthorType, Author>()
                .Name("Author")
                .ResolveAsync(ctx =>
                {
                    var loader = accessor.Context.GetOrAddBatchLoader<int, Author>("GetAuthorsById",
                    dataService.GetAuthorsByIdAsync);

                    return loader.LoadAsync(ctx.Source.AuthorId);
                });
            
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


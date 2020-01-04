
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
        }
    }
}


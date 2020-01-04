
using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.AspNetCore.Identity;



namespace app
{
    public class SalesInvoiceType : ObjectGraphType<SalesInvoice>
    {

        public SalesInvoiceType(ApplicationDbContext db, IDataLoaderContextAccessor accessor, IGetDataService dataService)
        {


            Field(x => x.Id);
            Field(x => x.CustomerName);
            Field(x => x.DateOfSale);
            Field(x => x.Price);

            //     Field<IntGraphType>(
            //    "noOfFacts",
            //    resolve: context =>
            //    {
            //        return context.Source.Links.Count();
            //        // data.GetFriends(context.Source)
            //    });

            // Field<ListGraphType<BookType>>()
            // .Name("Books")
            // .ResolveAsync(
            //                 async context =>
            //                 {

            //                     // Get or add a batch loader with the key "GetUsersById"
            //                     //The loader will call GetUsersByIdAsync for each batch of keys
            //                     var loader = accessor.Context.GetOrAddBatchLoader<int, Book>("GetBooksByAuthorId", dataService.GetBooksAsync);

            //                     // Add this UserId to the pending keys to fetch
            //                     // The task will complete once the GetUsersByIdAsync() returns with the batched results
            //                     return await loader.LoadAsync(context.Source.Id);

            //                 });

            // Field<ListGraphType<BookType>, IEnumerable<Book>>()
            //     .Name("Books")
            //     .ResolveAsync(ctx =>
            //     {
            //         var loader = accessor.Context.GetOrAddCollectionBatchLoader<int, Book>("GetBooksByAuthorId",
            //             dataService.GetBooksAsync);

            //         return loader.LoadAsync(ctx.Source.Id);
            //     });
        

            //     }
            //     , description: "primary facts");

            // Field<ListGraphType<FactType>>("nonPrimaryFacts",
            //     // arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
            //     resolve: context =>
            //     {

            //         return context.Source.Links.Where(l => !l.IsPrimaryTopic)
            //             .Select(f => f.Fact).OrderByDescending(f =>
            //             f.Votes.Where(v => v.VoteChoice == VoteChoice.Upvote).Count() -
            //             f.Votes.Where(v => v.VoteChoice == VoteChoice.Downvote).Count());



            //     }
            //     , description: "primary facts");


            // ApplicationUserType>(
            //     "creator",
            //     resolve: context =>
            //     {
            //         Console.WriteLine("hello");
            //         return userManager.FindByIdAsync(context.Source.ApplicationUserId).Result;
            //     },true            );

            // Field<ListGraphType<ApplicationUserType>>("applicationUserType",
            //     arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
            //     resolve: context =>
            //     {
            //         var user = userManager.FindByIdAsync(context.Source.ApplicationUserId).Result;
            //         return user;

            //     }
            //     , description: "Pineapple creator");

        }
    }
}


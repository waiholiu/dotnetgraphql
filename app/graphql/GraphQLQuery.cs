using System;
using System.Net.Mime;

using System.Linq;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using GraphQL.DataLoader;

namespace app
{
    public class GraphQLQuery : ObjectGraphType
    {



        public GraphQLQuery(ApplicationDbContext db, IDataLoaderContextAccessor accessor, IGetDataService dataService)
        {


            Field<IntGraphType>().Name("helloworld").Description("getTopics3desc")
            .Argument<IntGraphType>("newArg", "newDesc")
            .Resolve(
                context =>
                {

                    int i = context.GetArgument<int>("newArg");
                    return 100000000 + i;

                    // // Get or add a batch loader with the key "GetUsersById"
                    // // The loader will call GetUsersByIdAsync for each batch of keys
                    // var loader = accessor.Context.GetOrAddBatchLoader<int, User>("GetBooks", users.GetUsersByIdAsync);

                    // // Add this UserId to the pending keys to fetch
                    // // The task will complete once the GetUsersByIdAsync() returns with the batched results
                    // return loader.LoadAsync(context.Source.UserId);

                });

            Field<ListGraphType<AuthorType>>().Name("GetAuthors").Description("Get all Authors")
                        .ResolveAsync(
                            async context =>
                            {
                                return await db.Authors.ToListAsync();
                                // Get or add a batch loader with the key "GetUsersById"
                                // The loader will call GetUsersByIdAsync for each batch of keys
                                // var loader = accessor.Context.GetOrAddBatchLoader<int, Author>("GetAuthors", dataService.GetAuthors);

                                // // Add this UserId to the pending keys to fetch
                                // // The task will complete once the GetUsersByIdAsync() returns with the batched results
                                // return loader.LoadAsync(context..);

                            });

        }
    }


}



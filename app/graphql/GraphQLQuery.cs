using System;
using System.Net.Mime;

using System.Linq;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;



namespace app
{
    public class GraphQLQuery : ObjectGraphType
    {

        

        public GraphQLQuery(ApplicationDbContext db)
        {


            Field<IntGraphType>(
                "getTopics2",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "first" }),
                resolve: context =>
                {
                    return 100000000 + DateTime.Now.Millisecond;

                });
            
        }
    }


}



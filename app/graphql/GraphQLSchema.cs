
using System;
using GraphQL;
using GraphQL.Types;
using GraphQL.Utilities;

namespace app
{
    public class GraphQLSchema : Schema
    {
        public GraphQLSchema(IServiceProvider provider): base(provider)
        {
            Query = provider.GetRequiredService<GraphQLQuery>();
            
        }
    }
}


 
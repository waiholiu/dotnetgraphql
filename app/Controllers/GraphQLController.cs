

using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Http;
using GraphQL.Instrumentation;
using GraphQL.Types;
using GraphQL.Validation.Complexity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace app
{
    [Route("[controller]")]
    // [Authorize]
    public class GraphQLController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        private readonly ISchema _schema;

        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BaseGraphQLQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }
            var inputs = query.Variables.ToInputs();

            var result = await _documentExecuter.ExecuteAsync(_ =>
                                {
                                    _.Schema = _schema;
                                    _.Query = query.Query;
                                    _.OperationName = query.OperationName;
                                    _.Inputs = inputs;

                                    _.ComplexityConfiguration = new ComplexityConfiguration { MaxDepth = 15 };
                                    _.FieldMiddleware.Use<InstrumentFieldsMiddleware>();

                                }).ConfigureAwait(false);
            
            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }

}

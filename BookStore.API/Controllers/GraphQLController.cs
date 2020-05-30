using BookStore.API.GraphQL;
using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.Controllers
{
    [Route("[controller]")]
    public class GraphQLController : Controller
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecuter;

        public GraphQLController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            if (query == null)
            {
                throw new Exception(nameof(query));
            }

            var inputs = query.Variables?.ToInputs();
            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = inputs
            };
            var result = await _documentExecuter
                .ExecuteAsync(executionOptions);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result.Data);
        }
    }
}

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.API.GraphQL
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; } //Name of the query
        public string NamedQuery { get; set; }
        public string Query { get; set; } //Body of the request
        public JObject Variables { get; set; } // Specify the property for variables passed by the user
    }
}

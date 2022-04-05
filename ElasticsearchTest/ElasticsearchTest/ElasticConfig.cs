using Elasticsearch.Net;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElasticsearchTest
{
    internal static class ElasticConfig
    {
        private static IElasticClient _client;
        static ElasticConfig()
        {
            var node1 = new Uri("http://localhost:9200/");
            var node2 = new Uri("http://localhost:9300/");
            var nodes = new Uri[]
            {
                node1
               //,node2
            };
            var connectionPool = new SniffingConnectionPool(nodes);
            var connectionSettings = new ConnectionSettings(connectionPool)
                                .SniffOnConnectionFault(false)
                                .SniffOnStartup(false)
                                .SniffLifeSpan(TimeSpan.FromMinutes(1));
            _client = new ElasticClient(connectionSettings);
        }
        public static IElasticClient GetClient()
        {
            return _client;
        }
    }
}

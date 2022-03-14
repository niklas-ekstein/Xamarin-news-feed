using System;
namespace NewsFeed.Core
{
    public class APIKeys
    {
        public APIKeys()
        {
        }

//#error Enter the URL of your Azure Cosmos DB endpoint here
        public static readonly string CosmosEndpointUrl = "https://findbackpackers.documents.azure.com:443/";

//#error Enter the read/write authentication key of your Azure Cosmos DB endpoint here
        public static readonly string CosmosAuthKey = "5xwKHsI11OEDxLdHgKzR1tv4xLLCmJzruKBs2U136UCTNcSaPk5ZvWmCi2sXqdfvciXisERbvf1wgO7HiKXh4Q==";
    }
}

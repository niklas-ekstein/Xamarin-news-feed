using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using System;
using System.Data;
using System.Diagnostics;
using Microsoft.Azure.Documents.Linq;
using Xamarin.Forms;

namespace NewsFeed.Core
{
    public class CosmosDBService
    {
        static DocumentClient docClient = null;

        static readonly string databaseName = "Tasks";
        static readonly string collectionName = "Items";

        static async Task<bool> Initialize()
        {
            if (docClient != null)
                return true;

            try
            {
                docClient = new DocumentClient(new Uri(APIKeys.CosmosEndpointUrl), APIKeys.CosmosAuthKey);

                // Create the database - this can also be done through the portal
                await docClient.CreateDatabaseIfNotExistsAsync(new Database { Id = databaseName });

                // Create the collection - make sure to specify the RUs - has pricing implications
                // This can also be done through the portal

                await docClient.CreateDocumentCollectionIfNotExistsAsync(
                    UriFactory.CreateDatabaseUri(databaseName),
                    new DocumentCollection { Id = collectionName },
                    new RequestOptions { OfferThroughput = 400 }
                );

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);

                docClient = null;

                return false;
            }

            return true;
        }

        // <GetToDoItems>        
        /// <summary> 
        /// </summary>
        /// <returns></returns>
        public async static Task<List<Post1>> GetToDoItems()
        {
            var todos = new List<Post1>();

            if (!await Initialize())
                return todos;

            var todoQuery = docClient.CreateDocumentQuery<Post1>(
                UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
                new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
                //.Where(todo => todo.Completed == false) //Kommenterat ut eftersom complete inte finns.
                .AsDocumentQuery();

            while (todoQuery.HasMoreResults)
            {
                var queryResults = await todoQuery.ExecuteNextAsync<Post1>();

                todos.AddRange(queryResults);
            }

            return todos;
        }
        // </GetToDoItems>

        
        // <GetCompletedToDoItems>        
        /// <summary> 
        /// </summary>
        /// <returns></returns>
        /// 
        //public async static Task<List<Post1>> GetCompletedToDoItems()
        //{
        //    var todos = new List<Post1>();

        //    if (!await Initialize())
        //        return todos;

        //    var completedToDoQuery = docClient.CreateDocumentQuery<Post1>(
        //        UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
        //        new FeedOptions { MaxItemCount = -1, EnableCrossPartitionQuery = true })
        //        .Where(todo => todo.Completed == true)
        //        .AsDocumentQuery();

        //    while (completedToDoQuery.HasMoreResults)
        //    {
        //        var queryResults = await completedToDoQuery.ExecuteNextAsync<Post1>();

        //        todos.AddRange(queryResults);
        //    }

        //    return todos;
        //}

        // </GetCompletedToDoItems>

        
        // <CompleteToDoItem>        
        /// <summary> 
        /// </summary>
        /// <returns></returns>
        
        //public async static Task CompleteToDoItem(Post1 item)
        //{
        //    item.Completed = true;

        //    await UpdateToDoItem(item);
        //}

        // </CompleteToDoItem>

        
        // <InsertToDoItem>        
        /// <summary> 
        /// </summary>
        /// <returns></returns>
        public async static Task InsertToDoItem(Post1 item)
        {
            if (!await Initialize())
                return;

            await docClient.CreateDocumentAsync(
                UriFactory.CreateDocumentCollectionUri(databaseName, collectionName),
                item);
        }
        // </InsertToDoItem>  

        // <DeleteToDoItem>        
        /// <summary> 
        /// </summary>
        /// <returns></returns>
        public async static Task DeleteToDoItem(Post1 item)
        {
            if (!await Initialize())
                return;

            var docUri = UriFactory.CreateDocumentUri(databaseName, collectionName, item.Id);
            await docClient.DeleteDocumentAsync(docUri);
        }
        // </DeleteToDoItem>  

         // <UpdateToDoItem>        
        /// <summary> 
        /// </summary>
        /// <returns></returns>
        public async static Task UpdateToDoItem(Post1 item)
        {
            if (!await Initialize())
                return;

            var docUri = UriFactory.CreateDocumentUri(databaseName, collectionName, item.Id);
            await docClient.ReplaceDocumentAsync(docUri, item);
        }
        // </UpdateToDoItem>  
    }
}

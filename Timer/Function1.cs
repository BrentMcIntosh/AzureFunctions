using System;
using System.Collections.Generic;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Timer
{

    public class ToDoItem
    {
        [JsonProperty("id")]
        public string id { get; set; }

        [JsonProperty("partitionKey")]
        public string partitionKey { get; set; }

        [JsonProperty("LastName")]
        public string LastName { get; set; }
    }

    public class Player
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("nickName")]
        public string NickName { get; set; }

        [JsonProperty("playerId")]
        public int PlayerId { get; set; }

        [JsonProperty("region")]
        public string Region { get; set; }
    }
    public class Function1
    {
        [FunctionName("Function1")]
        public void Run
        (
            [TimerTrigger("0 */5 * * * *")] TimerInfo myTimer,

            [CosmosDB(
                databaseName: "ToDoList",
                containerName: "Items",
                Connection = "CosmosDBConnection", 
                Id = "Wakefield.7", 
                PartitionKey = "Wakefield")] ToDoItem input,

            [CosmosDB(
                databaseName: "Players",
                containerName: "player",
                Connection = "CosmosDBConnection")] out Player playerDocument,
            ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");


            log.LogInformation(input.LastName);


            playerDocument = new Player
            {
                Id = "qqqqq",
                NickName = $"{DateTime.Now.ToLongDateString()} courtesy of slackmo",
                PlayerId = 333333,
                Region = "eeeeeeeeeeee"
            };
        }
    }
}

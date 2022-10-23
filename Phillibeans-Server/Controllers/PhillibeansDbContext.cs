using System;
using System.Linq;
using System.Reflection;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using System.Collections.Generic;
using System.Text.Json;
using System.Reflection.Metadata;
using Phillibeans_Server.Models;

namespace Phillibeans_Server
{
    public class PhillibeansDbContext
    {

        MongoClient dbClient = new MongoClient(
            "mongodb+srv://vincentmejorada:DSOeKZqlqLreqELZ@cluster0.nwuby.mongodb.net/?retryWrites=true&w=majority" // justin's database
            );
        private IMongoDatabase database;
        private IMongoCollection<BsonDocument> collection;


        public PhillibeansDbContext()
        {
            database = dbClient.GetDatabase("phillibeans");
        }

        public IMongoCollection<BsonDocument> getCollection()
        {
            return collection;
        }
        public void setCollection(string str)
        {
            collection = database.GetCollection<BsonDocument>("User");
        }

        public int Add(BsonDocument doc)
        {
            collection.InsertOne(doc);
            var item = collection.Find(doc);
            return item != null ? 1 : 0;
}

        public List<BsonDocument> findAll()
        {
        List<BsonDocument> documents = collection.Find(new BsonDocument()).ToList();
        foreach (BsonDocument doc in documents)
        {
                var item = BsonSerializer.Deserialize<User>(doc);
                Console.WriteLine(item);
                Console.WriteLine(doc);
            }
            return documents;
        }

     /*   public BsonDocument findOne(BsonDocument doc)
        {

            PropertyInfo[] props = obj.GetType().GetProperties();
            string key = props.ElementAt(0).Name;
            string value = props.ElementAt(0).GetValue(obj).ToString();
            var filter = Builders<BsonDocument>.Filter.Eq("_id", "634db279226878db2238bc09");
            var results = collection.Find(filter).FirstOrDefault();
            var collValue = collection.CollectionNamespace.CollectionName + ".Value";
            ar filter = Builders<BsonDocument>.Filter.Eq(collValue, value);
            var results = collection.Find(new BsonDocument()).Project("{_id: 0}");
            //var results = collection.Find(filter);
            if (results != null)
            {
                return results;
            }
            return results;
        }*/

        public void updateOne(object obj)
        {
            PropertyInfo[] props = obj.GetType().GetProperties();
            var oldValue = props.ElementAt(0).GetValue(obj);
            var newValue = props.ElementAt(1).GetValue(obj).ToString();
            string[] newValueItems = newValue.Split(' ');


            PropertyInfo[] oldProps = oldValue.GetType().GetProperties();
            List<string> keys = new List<string>()
            {
                oldProps.ElementAt(1).Name.ToString(),
                oldProps.ElementAt(2).Name.ToString(),
                oldProps.ElementAt(3).Name.ToString(),
                oldProps.ElementAt(4).Name.ToString(),
            };
            string[] oldValueItems = oldValue.ToString().Split(' ');
            var resultString = "";
            for (int i = 0; i < keys.Count; i++)
            {
                var filter = Builders<BsonDocument>.Filter.Eq(keys[i], oldValueItems[i]);
                var update = Builders<BsonDocument>.Update.Set(keys[i], newValueItems[i]).CurrentDate("lastModified");
                var results = collection.UpdateOne(filter, update);
                resultString = results.IsAcknowledged ? "Success" : "Update Failed";
                if (resultString == "Update Failed") break;

            }
            Console.WriteLine(resultString);
        }

        public void deleteOne(BsonDocument doc)
        {
            //PropertyInfo[] props = obj.GetType().GetProperties();
            //var Key = props.ElementAt(0).Name;
            //var Value = props.ElementAt(0).GetValue(obj).ToString();

            //var collValue = collection.CollectionNamespace.CollectionName + ".Value";
            //var filter = Builders<BsonDocument>.Filter.Eq(collValue, Value);
            //var results = collection.Find(new BsonDocument()).Project("{_id: 0}").ToList();
            //var filter = Builders<BsonDocument>.Filter.Eq(Key, Value);
            var result = collection.DeleteMany(doc);
            var resultString = result.IsAcknowledged ? "Success" : "Delete Failed";
            //return resultString;
        }

        public void deleteCollection()
        {
            var filter = Builders<BsonDocument>.Filter.Empty;
            var result = collection.DeleteMany(filter);
            Console.WriteLine(result.IsAcknowledged ?
                "Success, All Data Deleted" :
                "Delete Failed");
        }


    }
}

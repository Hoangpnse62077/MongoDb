using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Configuration;
using System.Security.Authentication;
using MyTaskListApp.Models;
using System.Threading.Tasks;

namespace NotificationListApp
{
    public class Dal : IDisposable
    {
        //private MongoServer mongoServer = null;
        private bool disposed = false;

        // To do: update the connection string with the DNS name
        // or IP address of your server. 
        //For example, "mongodb://testlinux.cloudapp.net
        private string userName = "FILLME";
        private string host = "FILLME";
        private string password = "FILLME";

        // This sample uses a database named "Tasks" and a 
        //collection named "TasksList".  The database and collection 
        //will be automatically created if they don't already exist.
        private string dbName = "tscapplication";
        private string collectionName = "Notification";
        private string  connectionString =
  @"mongodb://tscapplication:aDSQRMhcJAqRHTuMm8tFDHJEAKyOjkSxDRKAAgmQKxyYpP7iqf2OS8jJJNHWuiptmSpdDBAGg80xnFVP722qsQ==@tscapplication.documents.azure.com:10255/?ssl=true&replicaSet=globaldb";
       

        // Default constructor.        
        public Dal()
        {
        }

        // Gets all Task items from the MongoDB server.        
        public async Task<List<NotificationPagingModel>> GetAllTasks(long count, int pageSize)
        {
            try
            {
                var collection = GetTasksCollection();
                count = collection.Count(a => true);
                var listData = new List<NotificationPagingModel>();
                var data =  collection.Aggregate()
                    .Se(x => x.NotificationUsers.Any(z => z.UserId == 274))
                                  .Sel
                                 .Skip(0)
                                 .Limit(pageSize)
                                 .ToList();
                listData = data.Select(x => new NotificationPagingModel()
                {
                    Id = x.Id.ToString(),
                    Object = x.Object,
                    Action = x.Action,
                    Property = x.Property,
                    OrderId = x.OrderId,
                    CustomerPoId = x.CustomerPoId,
                    FulfillmentType = x.FulfillmentType,
                    CreditApprovedStatus = x.CreditApprovedStatus,
                    CancelledDateOnUtc = x.CancelledDateOnUtc,
                    OrderDetailId = x.OrderDetailId,
                    A2000StyleId = x.A2000StyleId,
                    Size = x.Size,
                    A2000Color = x.A2000Color,
                    TotalFinishedQty = x.TotalFinishedQty,
                    TrimId = x.TrimId,
                    TrimName = x.TrimName,
                    SchedulerId = x.SchedulerId,
                    ScheduledDateOnUtc = x.ScheduledDateOnUtc,
                    IsDone = x.NotificationUsers.FirstOrDefault(y => y.UserId == 274).IsDone,
                    IsReaded = x.NotificationUsers.FirstOrDefault(y => y.UserId == 274).IsReaded,
                    CreatedOnUtc = x.CreatedOnUtc
                }).ToList();
                return listData;


            }
            catch (MongoConnectionException)
            {
                return new List<NotificationPagingModel>();
            }
        }

        // Creates a Task and inserts it into the collection in MongoDB.
        public void CreateTask(Notification task)
        {
            var collection = GetTasksCollection();
            try
            {
                collection.InsertOne(task);
            }
            catch (MongoCommandException ex)
            {
                string msg = ex.Message;
            }
        }

        public void CreateMany(List<Notification> notifications)
        {
            var collection = GetTasksCollection();
            try
            {
                collection.InsertMany(notifications);
            }
            catch (MongoCommandException ex)
            {
                string msg = ex.Message;
            }
        }
        private IMongoCollection<Notification> GetTasksCollection()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(
             new MongoUrl(connectionString)
           );
            settings.UseSsl = true;
            settings.SslSettings = new SslSettings();
            settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;

            ////MongoIdentity identity = new MongoInternalIdentity(dbName, userName);
            ////MongoIdentityEvidence evidence = new PasswordEvidence(password);
            //////settings.Credentials
            //settings.Credentials = new List<MongoCredential>
            //{
            //    new MongoCredential("SCRAM-SHA-1", identity, evidence)
            //};

            MongoClient client = new MongoClient(settings);
            var database = client.GetDatabase(dbName);
            var todoTaskCollection = database.GetCollection<Notification>(collectionName);
            return todoTaskCollection;
        }

        private IMongoCollection<Notification> GetTasksCollectionForEdit()
        {
            MongoClientSettings settings = MongoClientSettings.FromUrl(
            new MongoUrl(connectionString)
          );
            settings.UseSsl = true;
            settings.SslSettings = new SslSettings();
            settings.SslSettings.EnabledSslProtocols = SslProtocols.Tls12;

            MongoClient client = new MongoClient(settings);
            var database = client.GetDatabase(dbName);
            var todoTaskCollection = database.GetCollection<Notification>(collectionName);
            return todoTaskCollection;
        }

        # region IDisposable

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                }
            }

            this.disposed = true;
        }

        # endregion
    }
}

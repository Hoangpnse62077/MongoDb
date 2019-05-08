using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson;

namespace MyTaskListApp.Models
{
    public class MyTask
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        [BsonElement("id")]
        public Guid Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("Date")]
        public DateTime Date { get; set; }

        [BsonElement("CreatedDate")]
        public DateTime CreatedDate { get; set; }

    }
    public class Notification
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        [BsonElement("id")]
        public Guid Id { get; set; }

        [BsonElement("text")]
        public string Text { get; set; }

        [BsonElement("object")]
        public int Object { get; set; }

        [BsonElement("action")]
        public int Action { get; set; }

        [BsonElement("property")]
        public int Property { get; set; }

        [BsonElement("orderId")]
        public int OrderId { get; set; }

        [BsonElement("customerPoId")]
        public string CustomerPoId { get; set; }

        [BsonElement("fulfillmentType")]
        public int FulfillmentType { get; set; }

        [BsonElement("creditApprovedStatus")]
        public int CreditApprovedStatus { get; set; }

        [BsonElement("cancelledDateOnUtc")]
        public DateTime? CancelledDateOnUtc { get; set; }

        [BsonElement("orderDetailId")]
        public int? OrderDetailId { get; set; }

        [BsonElement("a2000StyleId")]
        public string A2000StyleId { get; set; }

        [BsonElement("size")]
        public string Size { get; set; }

        [BsonElement("a2000Color")]
        public string A2000Color { get; set; }

        [BsonElement("totalFinishedQty")]
        public int? TotalFinishedQty { get; set; }

        [BsonElement("schedulerId")]
        public int? SchedulerId { get; set; }

        [BsonElement("scheduledDateOnUtc")]
        public DateTime? ScheduledDateOnUtc { get; set; }

        [BsonElement("trimId")]
        public int? TrimId { get; set; }

        [BsonElement("trimName")]
        public string TrimName { get; set; }


        [BsonElement("createdOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

        [BsonElement("updatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }

        [BsonElement("notificationUsers")]
        public List<NotificationUser> NotificationUsers { get; set; }

        public Notification()
        {
            CreatedOnUtc = DateTime.UtcNow;
            UpdatedOnUtc = DateTime.UtcNow;
        }
    }
    public class NotificationUser
    {
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        [BsonElement("id")]
        public Guid Id { get; set; }

        //[Newtonsoft.Json.JsonProperty(PropertyName = "notificationId")]
        //public string NotificationId { get; set; }

       [BsonElement("userId")]
        public int UserId { get; set; }

       [BsonElement("isReaded")]
        public bool IsReaded { get; set; }

       [BsonElement("isDone")]
        public bool IsDone { get; set; }

       [BsonElement("isToDo")]
        public bool IsToDo { get; set; } = true;

       [BsonElement("isNew")]
        public bool IsNew { get; set; } = true;
     

       [BsonElement("createdOnUtc")]
        public DateTime CreatedOnUtc { get; set; }

       [BsonElement("updatedOnUtc")]
        public DateTime UpdatedOnUtc { get; set; }


        public NotificationUser()
        {
            Id = Guid.NewGuid();          
        }
    }
    public class NotificationPagingModel
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public int Object { get; set; }
        public int Action { get; set; }
        public int? Property { get; set; }
        public int OrderId { get; set; }
        public string CustomerPoId { get; set; }
        public int? FulfillmentType { get; set; }
        public int? CreditApprovedStatus { get; set; }
        public DateTime? CancelledDateOnUtc { get; set; }
        public int? OrderDetailId { get; set; }
        public string A2000StyleId { get; set; }
        public string Size { get; set; }
        public string A2000Color { get; set; }
        public int? TotalFinishedQty { get; set; }
        public int? SchedulerId { get; set; }
        public DateTime? ScheduledDateOnUtc { get; set; }
        public int? TrimId { get; set; }
        public string TrimName { get; set; }
        public bool IsReaded { get; set; }
        public bool IsDone { get; set; }
        public bool IsToDo { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
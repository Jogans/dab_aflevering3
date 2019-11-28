using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAB3.Models
{
    public class Users
    {
       [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Name")]
        public string UserName { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public List<string> MyCirclesId { get; set; }
        public List<string> BlackListedUserId { get; set; }
       
        // HVORFOR HAR USER EN LISTE AF POSTID?
        public List<string> PostsId { get; set; }

        public List<string> SubscribedTo { get; set; }
    }
}

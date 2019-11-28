using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAB3.Models;
using MongoDB.Driver;

namespace DAB3.Services
{
    public class CirclesService
    {
        private readonly IMongoCollection<Circle> _circles;

        public CirclesService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DAB3Db");

            _circles = database.GetCollection<Circle>("Circles");
        }

        public List<Circle> Get() =>
            _circles.Find(circle => true).ToList();

        public Circle Get(string id) =>
            _circles.Find<Circle>(post => post.Id == id).FirstOrDefault();

        public Circle Create(Circle circle)
        {
            _circles.InsertOne(circle);
            return circle;
        }

        public void Update(string id, Circle circleIn) =>
            _circles.ReplaceOne(circle => circle.Id == id, circleIn);

        public void Remove(Posts circleIn) =>
            _circles.DeleteOne(circle => circle.Id == circleIn.Id);

        public void Remove(string id) =>
            _circles.DeleteOne(circle => circle.Id == id);
        public void RemoveAll() => _circles.DeleteMany(FilterDefinition<Circle>.Empty);
    }
}

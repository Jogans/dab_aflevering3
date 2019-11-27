﻿using System;
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

        public CirclesService(IDab3DatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _circles = database.GetCollection<Circle>(settings.CircleCollectionName);
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
    }
}
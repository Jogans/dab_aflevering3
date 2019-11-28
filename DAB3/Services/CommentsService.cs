﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAB3.Models;
using MongoDB.Driver;

namespace DAB3.Services
{
    public class CommentsService
    {
        private readonly IMongoCollection<Comments> _comments;

        public CommentsService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DAB3Db");

            _comments = database.GetCollection<Comments>("Comments");
        }

        public List<Comments> Get() =>
            _comments.Find(comment => true).ToList();

        public Comments Get(string id) =>
            _comments.Find<Comments>(comment => comment.Id == id).FirstOrDefault();

        public Comments Create(Comments comment)
        {
            _comments.InsertOne(comment);
            return comment;
        }

        public void Update(string id, Comments commentIn) =>
            _comments.ReplaceOne(comment => comment.Id == id, commentIn);

        public void Remove(Comments commentIn) =>
            _comments.DeleteOne(comment => comment.Id == commentIn.Id);

        public void Remove(string id) =>
            _comments.DeleteOne(comment => comment.Id == id);
        public void RemoveAll() => _comments.DeleteMany(FilterDefinition<Comments>.Empty);
    }
}

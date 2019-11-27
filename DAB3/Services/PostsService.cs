﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAB3.Models;
using MongoDB.Driver;

namespace DAB3.Services
{
    public class PostsService
    {
        private readonly IMongoCollection<Posts> _posts;

        public PostsService(IDab3DatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _posts = database.GetCollection<Posts>(settings.PostsCollectionName);
        }

        public List<Posts> Get() =>
            _posts.Find(post => true).ToList();

        public Posts Get(string id) =>
            _posts.Find<Posts>(post => post.Id == id).FirstOrDefault();

        public Posts Create(Posts post)
        {
            _posts.InsertOne(post);
            return post;
        }

        public void Update(string id, Posts postIn) =>
            _posts.ReplaceOne(post => post.Id == id, postIn);

        public void Remove(Posts postIn) =>
            _posts.DeleteOne(post => post.Id == postIn.Id);

        public void Remove(string id) =>
            _posts.DeleteOne(post => post.Id == id);
    }
}
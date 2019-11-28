using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAB3.Models;
using MongoDB.Driver;

namespace DAB3.Services
{
    public class UsersService
    {
        

        private readonly IMongoCollection<Users> _users;


        public UsersService()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("DAB3Db");

            _users = database.GetCollection<Users>("Users");
        }

        public List<Users> Get() =>
            _users.Find(user => true).ToList();

        public Users Get(string id) =>
            _users.Find<Users>(user => user.Id == id).FirstOrDefault();

        public Users Create(Users user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, Users userIn) =>
            _users.ReplaceOne(user => user.Id == id, userIn);

        public void Remove(Users userIn) =>
            _users.DeleteOne(user => user.Id == userIn.Id);

        public void Remove(string id) =>
            _users.DeleteOne(user => user.Id == id);

        public void RemoveAll() => _users.DeleteMany(FilterDefinition<Users>.Empty);
    }
}


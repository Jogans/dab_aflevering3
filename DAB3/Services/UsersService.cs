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

        

        public UsersService(IDab3DatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _users = database.GetCollection<Users>(settings.UsersCollectionName);
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
    }
}


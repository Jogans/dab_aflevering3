using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAB3.Models;
using DAB3.Services;

namespace DAB3.DAL
{
    public class AddData
    {
        public void DoTheThing()
        {
            CirclesService _circlesService = new CirclesService();
            CommentsService _commentsService = new CommentsService();
            PostsService _postsService = new PostsService();
            UsersService _usersService = new UsersService();
            
            Users user1 = new Users
            {
                Age = 14,
                Gender = "Male",
                UserName = "Ove Larsen",
                MyCirclesId = new List<string>(),
                BlackListedUserId = new List<string>(),
                PostsId = new List<string>(),
                SubscriberId = new List<string>()
            };
            Users user2 = new Users
            {
                Age = 27,
                Gender = "Female",
                UserName = "Gertrud Larsen",
                MyCirclesId = new List<string>(),
                BlackListedUserId = new List<string>(),
                PostsId = new List<string>(),
                SubscriberId = new List<string>()
            };
            Users user3 = new Users
            {
                Age = 25,
                Gender = "Male",
                UserName = "Gunnar Larsen",
                MyCirclesId = new List<string>(),
                BlackListedUserId = new List<string>(),
                PostsId = new List<string>(),
                SubscriberId = new List<string>()
            };
            Users user4 = new Users
            {
                Age = 81,
                Gender = "Female",
                UserName = "Brunnhilde Jørgensen",
                MyCirclesId = new List<string>(),
                BlackListedUserId = new List<string>(),
                PostsId = new List<string>(),
                SubscriberId = new List<string>()
            };
            Users user5 = new Users
            {
                Age = 35,
                Gender = "Female",
                UserName = "Sofie Lassen",
                MyCirclesId = new List<string>(),
                BlackListedUserId = new List<string>(),
                PostsId = new List<string>(),
                SubscriberId = new List<string>()
            };
            Users user6 = new Users
            {
                Age = 19,
                Gender = "Male",
                UserName = "Nicolai Østergaard",
                MyCirclesId = new List<string>(),
                BlackListedUserId = new List<string>(),
                PostsId = new List<string>(),
                SubscriberId = new List<string>()
            };
            _usersService.Create(user4);
            _usersService.Create(user5);
            _usersService.Create(user6);

            List<string> users = new List<string>();
            users.Add(user1.Id);
            users.Add(user2.Id);
            Circle circle1 = new Circle
            {
                UserIds = users
            };
            List<string> users2 = new List<string>();
            users2.Add(user2.Id);
            users2.Add(user3.Id);
            Circle circle2 = new Circle
            {
                UserIds = users2
            };
            _circlesService.Create(circle1);
            _circlesService.Create(circle2);
            var bruger1 = _usersService.Get(user1.Id);
            bruger1.MyCirclesId.Add(_circlesService.Get(circle1.Id).Id);
            _usersService.Update(user1.Id, bruger1);
            var bruger2 = _usersService.Get(user2.Id);
            bruger2.MyCirclesId.Add(circle1.Id);
            bruger2.MyCirclesId.Add(circle2.Id);
            _usersService.Update(user2.Id, bruger2);
            var bruger3 = _usersService.Get(user3.Id);
            bruger3.MyCirclesId.Add(circle2.Id);
            _usersService.Update(user3.Id, bruger3);
        }
    }
}

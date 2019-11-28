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
            _usersService.Create(user1);
            _usersService.Create(user2);
            _usersService.Create(user3);
            _usersService.Create(user4);
            _usersService.Create(user5);
            _usersService.Create(user6);

            List<string> users = new List<string>();
            users.Add(user1.Id);
            users.Add(user2.Id);
            users.Add(user3.Id);
            Circle family = new Circle
            {
                UserIds = users
            };

            List<string> users2 = new List<string>();
            users2.Add(user1.Id);
            users2.Add(user4.Id);
            users2.Add(user5.Id);
            users2.Add(user6.Id);
            Circle friends = new Circle
            {
                UserIds = users2
            };

            List<string> users3 = new List<string>();
            users2.Add(user1.Id);
            users2.Add(user6.Id);
            Circle closeFriends = new Circle
            {
                UserIds = users2
            };
            _circlesService.Create(family);
            _circlesService.Create(friends);
            _circlesService.Create(closeFriends);

            var bruger1 = _usersService.Get(user1.Id);
            bruger1.MyCirclesId.Add(_circlesService.Get(family.Id).Id);
            bruger1.MyCirclesId.Add(_circlesService.Get(friends.Id).Id);
            bruger1.MyCirclesId.Add(_circlesService.Get(closeFriends.Id).Id);
            _usersService.Update(user1.Id, bruger1);

            var bruger2 = _usersService.Get(user2.Id);
            bruger2.MyCirclesId.Add(family.Id);
            _usersService.Update(user2.Id, bruger2);

            var bruger3 = _usersService.Get(user3.Id);
            bruger3.MyCirclesId.Add(family.Id);
            _usersService.Update(user3.Id, bruger3);

            var bruger4 = _usersService.Get(user4.Id);
            bruger3.MyCirclesId.Add(friends.Id);
            _usersService.Update(user3.Id, bruger3);

            var bruger5 = _usersService.Get(user5.Id);
            bruger3.MyCirclesId.Add(friends.Id);
            _usersService.Update(user3.Id, bruger3);

            var bruger6 = _usersService.Get(user6.Id);
            bruger3.MyCirclesId.Add(friends.Id);
            bruger3.MyCirclesId.Add(closeFriends.Id);
            _usersService.Update(user3.Id, bruger3);

            Posts post1 = new Posts
            {
                CirclesId = new List<string>(),
                CommentsId = new List<string>(),
                Time = DateTime.Now,
                Text = "Farmand er hjemme",
                UserId = user3.Id
            };
            Posts post2 = new Posts
            {
                CirclesId = new List<string>(),
                CommentsId = new List<string>(),
                Time = DateTime.Now,
                Text = "Mine forældre er så tarvelige!",
                UserId = user1.Id
            };
            Posts post3 = new Posts
            {
                CirclesId = new List<string>(),
                CommentsId = new List<string>(),
                Time = DateTime.Now,
                Text = "Nu er Ove ude på ballade igen!",
                UserId = user2.Id
            };
            Posts post4 = new Posts
            {
                CirclesId = new List<string>(),
                CommentsId = new List<string>(),
                Time = DateTime.Now,
                Text = "Ove er en meget sød dreng",
                UserId = user4.Id
            };
            Posts post5 = new Posts
            {
                CirclesId = new List<string>(),
                CommentsId = new List<string>(),
                Time = DateTime.Now,
                Text = "Brunnhilde laver dejlig kage",
                UserId = user1.Id
            };

        }
    }
}

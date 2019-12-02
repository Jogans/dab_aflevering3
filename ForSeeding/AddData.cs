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
            //CommentsService _commentsService = new CommentsService();
            UsersService _usersService = new UsersService();
            
            Users user1 = new Users
            {
                Age = 14,
                Gender = "Male",
                UserName = "Ove Larsen",
                MyCirclesId = new List<string>(),
                BlackListedUserId = new List<string>(),
                SubscribedTo = new List<string>()
            };
            Users user2 = new Users
            {
                Age = 27,
                Gender = "Female",
                UserName = "Gertrud Larsen",
                MyCirclesId = new List<string>(),
                BlackListedUserId = new List<string>(),
                SubscribedTo = new List<string>()
            };
            Users user3 = new Users
            {
                Age = 25,
                Gender = "Male",
                UserName = "Gunnar Larsen",
                MyCirclesId = new List<string>(),
                BlackListedUserId = new List<string>(),
                SubscribedTo = new List<string>()
            };
            Users user4 = new Users
            {
                Age = 81,
                Gender = "Female",
                UserName = "Brunnhilde Jørgensen",
                MyCirclesId = new List<string>(),
                BlackListedUserId = new List<string>(),
                SubscribedTo = new List<string>()
            };
            Users user5 = new Users
            {
                Age = 35,
                Gender = "Female",
                UserName = "Sofie Lassen",
                MyCirclesId = new List<string>(),
                BlackListedUserId = new List<string>(),
                SubscribedTo = new List<string>()
            };
            Users user6 = new Users
            {
                Age = 19,
                Gender = "Male",
                UserName = "Nicolai Østergaard",
                MyCirclesId = new List<string>(),
                BlackListedUserId = new List<string>(),
                SubscribedTo = new List<string>()
            };

            Circle c1 = new Circle  {CircleName = "Public", UserIds = new List<string>(), Posts = new List<Posts>() };
            Circle c2 = new Circle { CircleName = "Public", UserIds = new List<string>(), Posts = new List<Posts>() };
            Circle c3 = new Circle { CircleName = "Public", UserIds = new List<string>(), Posts = new List<Posts>() };
            Circle c4 = new Circle { CircleName = "Public", UserIds = new List<string>(), Posts = new List<Posts>() };
            Circle c5 = new Circle { CircleName = "Public", UserIds = new List<string>(), Posts = new List<Posts>() };
            Circle c6 = new Circle { CircleName = "Public", UserIds = new List<string>(), Posts = new List<Posts>() };


            _circlesService.Create(c1);
            _circlesService.Create(c2);
            _circlesService.Create(c3);
            _circlesService.Create(c4);
            _circlesService.Create(c5);
            _circlesService.Create(c6);

            user1.MyCirclesId.Add(c1.Id);
            user2.MyCirclesId.Add(c2.Id);
            user3.MyCirclesId.Add(c3.Id);
            user4.MyCirclesId.Add(c4.Id);
            user5.MyCirclesId.Add(c5.Id);
            user6.MyCirclesId.Add(c6.Id);

            _usersService.Create(user1);
            _usersService.Create(user2);
            _usersService.Create(user3);
            _usersService.Create(user4);
            _usersService.Create(user5);
            _usersService.Create(user6);

            c1.UserIds.Add(user1.Id);
            c2.UserIds.Add(user2.Id);
            c3.UserIds.Add(user3.Id);
            c4.UserIds.Add(user4.Id);
            c5.UserIds.Add(user5.Id);
            c6.UserIds.Add(user6.Id);

            c1.CircleOwner = user1.Id;
            c2.CircleOwner = user2.Id;
            c3.CircleOwner = user3.Id;
            c4.CircleOwner = user4.Id;
            c5.CircleOwner = user5.Id;
            c6.CircleOwner = user6.Id;


            _circlesService.Update(c1.Id, c1);
            _circlesService.Update(c2.Id, c2);
            _circlesService.Update(c3.Id, c3);
            _circlesService.Update(c4.Id, c4);
            _circlesService.Update(c5.Id, c5);
            _circlesService.Update(c6.Id, c6);

            //List<string> publicList = new List<string>();
            //publicList.Add(user1.Id);
            //publicList.Add(user2.Id);
            //publicList.Add(user3.Id);
            //publicList.Add(user4.Id);
            //publicList.Add(user5.Id);
            //publicList.Add(user6.Id);
            //Circle publicCircle = new Circle
            //{
            //    UserIds = publicList,
            //    Name = "Public"
            //};

            List<string> users = new List<string>
            {
                user1.Id,
                user2.Id,
                user3.Id
            };
            Circle family = new Circle
            {
                UserIds = users,
                CircleName = "Family",
                CircleOwner = users[0]

            };

            List<string> users2 = new List<string>();
            users2.Add(user1.Id);
            users2.Add(user4.Id);
            users2.Add(user5.Id);
            users2.Add(user6.Id);
            Circle friends = new Circle
            {
                UserIds = users2,
                CircleName = "Friends",
                CircleOwner = users2[0]
            };

            List<string> users3 = new List<string>();
            users3.Add(user1.Id);
            users3.Add(user6.Id);
            Circle closeFriends = new Circle
            {
                UserIds = users2,
                CircleName = "Close friends",
                CircleOwner = users3[0]
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
                Comments = new List<Comments>(),
                Time = DateTime.Now.AddDays(-122),
                Text = "Farmand er hjemme",
                UserId = user3.Id
            };
            Posts post2 = new Posts
            {
                Comments = new List<Comments>(),
                Time = DateTime.Now.AddDays(-30),
                Text = "Mine forældre er så tarvelige!",
                UserId = user1.Id
            };
            Posts post3 = new Posts
            {
                Comments = new List<Comments>(),
                Time = DateTime.Now.AddHours(-300),
                Text = "Nu er Ove ude på ballade igen!",
                UserId = user2.Id,
                img = "https://images.squarespace-cdn.com/content/5ac35d2ada02bcfea4174e7a/1523007397516-40LEMUSIIIKFNFNMQX5G/Logo_u_tagline.png?content-type=image%2Fpng"
            };
            Posts post4 = new Posts
            {
                Comments = new List<Comments>(),
                Time = DateTime.Now.AddHours(-1000),
                Text = "Ove er en meget sød dreng",
                UserId = user4.Id,
                img = "https://pbs.twimg.com/profile_images/949787136030539782/LnRrYf6e.jpg"
            };
            Posts post5 = new Posts
            {
                Comments = new List<Comments>(),
                Time = DateTime.Now.AddMinutes(-10),
                Text = "Brunnhilde laver dejlig kage",
                UserId = user1.Id,
                img = "https://images.arla.com/recordid/c6c1f18f6dca46d4806da6e400fad604/drommekage-fra-brovst.jpg?crop=(0,340,0,-435)&w=1680&h=750&scale=both&ak=6826258c&hm=e96bc43a"
            };

         


            Comments[] comments = new Comments[]
            {
                new Comments
                {
                    Time = DateTime.Now.AddDays(-5),
                    Text = "Hold dig væk fra mit værelse!",
                    UserId = user1.Id
                },
                new Comments
                {
                    Time = DateTime.Now.AddHours(-20),
                    Text = "Du får altså ikke slik på en hverdag",
                    UserId = user3.Id
                },
                new Comments
                {
                    Time = DateTime.Now.AddMonths(2),
                    Text = "Det var hunden, der spiste kagen!",
                    UserId = user1.Id
                },
                new Comments
                {
                    Time = DateTime.Now.AddHours(-1),
                    Text = "Til tider",
                    UserId = user5.Id
                },
                new Comments
                {
                    Time = DateTime.Now.AddMinutes(-15),
                    Text = "Det var godt kh Brunnnhilllddeee",
                    UserId = user6.Id
                },
            };

            post1.Comments.Add(comments[0]);
            post2.Comments.Add(comments[1]);
            post3.Comments.Add(comments[2]);
            post4.Comments.Add(comments[3]);
            post5.Comments.Add(comments[4]);
            
            family.Posts.Add(post1);
            c1.Posts.Add(post1);
            c2.Posts.Add(post2);
            c1.Posts.Add(post3);
            c1.Posts.Add(post4);
            c1.Posts.Add(post5);

            _circlesService.Update(family.Id, family);
            _circlesService.Update(c1.Id, c1);
            _circlesService.Update(c2.Id, c2);
            _circlesService.Update(c3.Id, c3);
            _circlesService.Update(c4.Id, c4);
            _circlesService.Update(c5.Id, c5);

        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using DAB3.Models;
using DAB3.Services;
using MongoDB.Driver;

namespace DAB3.DAL
{
    public class UserFunctions
    {
        UsersService _usersService;
        private CirclesService _circlesService;
        private PostsService _postsService;

        UserFunctions()
        {
            _usersService = new UsersService();
            _circlesService = new CirclesService();
            _postsService = new PostsService();
        }

        public void MethodCreatePost(string id, string content, List<string> postCircles)
        {
            var user1 = _usersService.Get(id);
            string users = user1.Id;
            Posts post1 = new Posts
            {
                UserId = users, 
                Text = content, 
                Time = DateTime.Now,
                Comments = new List<Comments>()
            };

            var Post = _postsService.Create(post1);
            user1.PostsId.Add(_postsService.Get(post1.Id).Id);
            _usersService.Update(user1.Id, user1);

            foreach (string circleid in postCircles)
            {
                var circle1 = _circlesService.Get(circleid);
                circle1.UserIds.Add(post1.Id);
                _circlesService.Update(circle1.Id, circle1);
            }
            

        }

        public void MethodCreateComment(string postid, string comment, string userid)
        {
            var post1 = _postsService.Get(postid); 
            Comments comment1 = new Comments();
            comment1.Time = DateTime.Now;
            comment1.Text = comment;
            comment1.UserId = userid;
            post1.Comments.Add(comment1);
            _postsService.Update(postid, post1);
        }


        public void MethodAddUserToBanList(string id, string id2)
        {
            var user = _usersService.Get(id);
            user.BlackListedUserId.Add(id2);
            _usersService.Update(id, user);
        }


        public void MethodRemoveUserFromBanList(string id, string id2)
        {
            var user = _usersService.Get(id);
            user.BlackListedUserId.Remove(id2);
            _usersService.Update(id, user);
        }

        public void MethodSubcribeToUser(string subscriberId, string subsribedToId)
        {
            var user = _usersService.Get(subsribedToId);
            List<Circle> subsribeCircle = _circlesService.FindCircleFromName("Public");
            subsribeCircle[0].UserIds.Add(subscriberId);
            _circlesService.Update(subsribedToId, subsribeCircle[0]);
        }

        public void MethodUnsubcribeToUser(string subscriberId, string subsribedToId)
        {
            var user = _usersService.Get(subsribedToId);
            List<Circle> subsribeCircle = _circlesService.FindCircleFromName("Public");
            subsribeCircle[0].UserIds.Remove(subscriberId);
            _circlesService.Update(subsribedToId, subsribeCircle[0]);
        }

        public void MethodCreateCircle(string id)
        {
            var user1 = _usersService.Get(id);
            List<string> users = new List<string>();
            users.Add(user1.Id);
            Circle circle1 = new Circle
            {
                UserIds = users
            };

            var circle = _circlesService.Create(circle1);
            user1.MyCirclesId.Add(_circlesService.Get(circle1.Id).Id);
            _usersService.Update(user1.Id, user1);
        }

        public void MethodAddUserToCircle(string id1, string id2, string circleId)
        {
            var user1 = _usersService.Get(id1);
            var user2 = _usersService.Get(id2);
            var circle1 = _circlesService.Get(circleId);

            circle1.UserIds.Add(id2);
            _circlesService.Update(circleId, circle1);

            user2.MyCirclesId.Add(circleId);
            _usersService.Update(user2.Id, user2);
        }


        public void MethodRemoveUserToCircle(string id1, string id2, string circleId)
        {
            var user1 = _usersService.Get(id1);
            var user2 = _usersService.Get(id2);
            var circle1 = _circlesService.Get(circleId);

            circle1.UserIds.Remove(id2);
            _circlesService.Update(circleId, circle1);

            user2.MyCirclesId.Remove(circleId);
            _usersService.Update(user2.Id, user2);
        }

    }


}

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

        public void MethodAddPostToCircle(string id)
        {
            
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

        public void MethodSubcribeToUser(string id, string id2)
        {
            var user = _usersService.Get(id2);
            user.SubscriberId.Add(id);
            _usersService.Update(id2, user);
        }

        public void MethodUnsubcribeToUser(string id, string id2)
        {
            var user = _usersService.Get(id2);
            user.SubscriberId.Remove(id);
            _usersService.Update(id2, user);
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

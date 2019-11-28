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
            Dab3DatabaseSettings settings = new Dab3DatabaseSettings();
            CirclesService _circlesService = new CirclesService(settings);
            CommentsService _commentsService = new CommentsService(settings);
            PostsService _postsService = new PostsService(settings);
            UsersService _usersService = new UsersService(settings);
            
            Users user1 = new Users
            {
                Age = 14,
                Gender = "Male",
                UserName = "Ove Larsen"
            };
            Users user2 = new Users
            {
                Age = 27,
                Gender = "Female",
                UserName = "Gertrud Larsen"
            };
            Users user3 = new Users
            {
                Age = 25,
                Gender = "Male",
                UserName = "Gunnar Larsen"
            };
            _usersService.Create(user1);
            _usersService.Create(user2);
            _usersService.Create(user3);

            
        }
    }
}

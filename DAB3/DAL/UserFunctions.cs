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

        public UserFunctions()
        {
            _usersService = new UsersService();
            _circlesService = new CirclesService();
            _postsService = new PostsService();
        }

        public void CreatePost(string Myuserid, string content, List<string> postCircles)
        {
            var user1 = _usersService.Get(Myuserid);
            Posts post1 = new Posts
            {
                UserId = Myuserid, 
                Text = content, 
                Time = DateTime.Now,
                Comments = new List<Comments>()
            };

            var Post = _postsService.Create(post1);
            _usersService.Update(user1.Id, user1);

            foreach (string circleId in postCircles)
            {
                var circle1 = _circlesService.Get(circleId);
                circle1.UserIds.Add(Myuserid);
                _circlesService.Update(circle1.Id, circle1);
            }
        }




        public void CreateComment(string postid, string comment, string userid)
        {
            Comments comment1 = new Comments();
            comment1.Time = DateTime.Now;
            comment1.Text = comment;
            comment1.UserId = userid;

            var post1 = _postsService.Get(postid);
            post1.Comments.Add(comment1);
            _postsService.Update(postid, post1);
        }


        public void AddUserToBanList(string id, string id2)
        {
            var user = _usersService.Get(id);
            user.BlackListedUserId.Add(id2);
            _usersService.Update(id, user);
        }


        public void RemoveUserFromBanList(string id, string id2)
        {
            var user = _usersService.Get(id);
            user.BlackListedUserId.Remove(id2);
            _usersService.Update(id, user);
        }

        public void SubcribeToUser(string subscriberId, string subscribedToId)
        {
            var user = _usersService.Get(subscribedToId);
            List<Circle> subsribeCircle = _circlesService.FindCircleFromName("Public", subscriberId);
            subsribeCircle[0].UserIds.Add(subscriberId);
            _circlesService.Update(subscribedToId, subsribeCircle[0]);
            var Subscriber = _usersService.Get(subscriberId);
            Subscriber.SubscribedTo.Add(subscribedToId);
            _usersService.Update(subscriberId, Subscriber);

        }

        public void UnsubcribeToUser(string subscriberId, string subscribedToId)
        {
            var user = _usersService.Get(subscribedToId);
            List<Circle> subsribeCircle = _circlesService.FindCircleFromName("Public", subscribedToId);
            subsribeCircle[0].UserIds.Remove(subscriberId);
            _circlesService.Update(subscribedToId, subsribeCircle[0]);
            var Subscriber = _usersService.Get(subscriberId);
            Subscriber.SubscribedTo.Remove(subscribedToId);
            _usersService.Update(subscriberId, Subscriber);

        }

        public void CreateCircle(string id)
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

        public void AddUserToCircle(string id1, string id2, string circleId)
        {
            var user1 = _usersService.Get(id1);
            var user2 = _usersService.Get(id2);
            var circle1 = _circlesService.Get(circleId);

            circle1.UserIds.Add(id2);
            _circlesService.Update(circleId, circle1);

            user2.MyCirclesId.Add(circleId);
            _usersService.Update(user2.Id, user2);
        }


        public void RemoveUserFromCircle(string id1, string id2, string circleId)
        {
            var user1 = _usersService.Get(id1);
            var user2 = _usersService.Get(id2);
            var circle1 = _circlesService.Get(circleId);

            circle1.UserIds.Remove(id2);
            _circlesService.Update(circleId, circle1);

            user2.MyCirclesId.Remove(circleId);
            _usersService.Update(user2.Id, user2);
        }


        public List<Posts> Feed(string Logged_In_UserName)
        {
            List<Posts> Feed = new List<Posts>();
            List<Users> _userList = _usersService.FindUserFromName(Logged_In_UserName);
            Users _loggedInUser = _userList[0];


        // SUBSCRIBED TO
        if (_loggedInUser.SubscribedTo == null)
        {
            
        }
        foreach (var subscription in _loggedInUser.SubscribedTo)
            {
                var provider = _usersService.Get(_loggedInUser.Id);

                // Check for BannedUser
                if (provider.BlackListedUserId.Contains(_loggedInUser.Id))
                {
                    continue;
                }

                var publicCircle = _circlesService.Get(subscription);

                // Get the 3 latest post from Subscribee's Public Circle
                for (int i = 0; i < 3; i++)
                {
                    Feed.Add(publicCircle.Posts[publicCircle.Posts.Count - i]);
                }
            }

            //Circles
            foreach (string CircleId in _loggedInUser.MyCirclesId)
            {
                var circle = _circlesService.Get(CircleId);

                var circleOwner = _usersService.Get(circle.CircleOwner);

                // Check for BannedUser
                if (circleOwner.BlackListedUserId.Contains(_loggedInUser.Id))
                {
                    continue;
                }
                var privateCircle = _circlesService.Get(CircleId);

                // Get the 3 latest post from Subscribee's Public Circle
                if (privateCircle.Posts.Count != 0)
                {
                    int count = privateCircle.Posts.Count - 1;
                    int countMax = count - 3;
                    if (countMax < 0)
                    {
                        countMax = 0;
                    }
                    for (int i = count; i > countMax; i--)
                    {
                        Feed.Add(privateCircle.Posts[i]);
                    }
                }


            }

            //SORT BY DATE & TIME
            Feed.Sort((x, y) => DateTime.Compare(x.Time, y.Time));
            // ENTEN ELLER
            //Feed = Feed.OrderBy(x => x.Time).ToList();

            return Feed;
        }

        public string FormatFeedListToHTML(List<Posts> Feed)
        {
            string initString = "" +
                                "<html>";
            string endString = "</html>";

            string bodystring = "";
            foreach (var post in Feed)
            {
                bodystring += "<p>" + "Text: " + post.Text + "<br/>";
                foreach (var comment in post.Comments)
                {
                    bodystring += " Comment: " + comment.Text + "<br/>" + "Comment from: " + _usersService.Get(comment.UserId).UserName + "<br/>";
                }

                bodystring += " Posted: " + post.Time + "<p/>" + "<br/>";
            }

            return initString + bodystring + endString;
        }


        // OVERVEJELSE? HVORDAN SKAL PUBLIC FORSTÅS? KAN ALLE SE DET ELLER KUN DEM SOM SUBSCRIBER
        // HVIS JEG BESØGER EN ANDEN BRUGER KAN JEG SE NOGET PÅ PERSONENS WALL?

        public List<Posts> Wall(string VisitorName, string HostName)
        {
            List<Users> _VisitorList = _usersService.FindUserFromName(VisitorName);
            Users VisitorUser = _VisitorList[0];

            List<Users> _HostList = _usersService.FindUserFromName(HostName);
            Users HostUser = _HostList[0];


            List<Posts> Wall = new List<Posts>();
            
            
           if (HostUser.BlackListedUserId.Contains(VisitorUser.Id))
            {
                // HVAD SKAL RETURNES?

                return null;
            }

            foreach (var CircleId in HostUser.MyCirclesId)
            {
                var circle = _circlesService.Get(CircleId);

                if (!circle.UserIds.Contains(VisitorUser.Id))
                {
                    continue;
                }
                
                List<Posts> FromUser = new List<Posts>();

                foreach (var post in circle.Posts)
                {
                    if (post.UserId == VisitorUser.Id)
                    {
                        FromUser.Add(post);

                    }
                }

                //SORT BY DATE & TIME
                FromUser.Sort((x, y) => DateTime.Compare(x.Time, y.Time));
                // Get the 3 latest post from Subscribee's Public Circle
                for (int i = 0; i < 3 && i < FromUser.Count; i++)
                {
                    Wall.Add(FromUser[FromUser.Count - i]);
                }
            }

            //SORT BY DATE & TIME
            Wall.Sort((x, y) => DateTime.Compare(x.Time, y.Time));
            // ENTEN ELLER
            //Wall = Wall.OrderBy(x => x.Time).ToList();

            return Wall;
        }
    }


}

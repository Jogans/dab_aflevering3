using System;
using DAB3.DAL;
using DAB3.Services;

namespace ForSeeding
{
    class Program
    {
        static void Main(string[] args)
        {
            AddData addData = new AddData();
            addData.DoTheThing();
            //UsersService user = new UsersService();
            //user.RemoveAll();
            //PostsService post = new PostsService();
            //post.RemoveAll();
            //CommentsService comment = new CommentsService();
            //comment.RemoveAll();
            //CirclesService circle = new CirclesService();
            //circle.RemoveAll();
        }
    }
}

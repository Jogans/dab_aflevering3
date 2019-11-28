using System;
using System.Linq;
using DAB3.DAL;
using DAB3.Services;

namespace ForSeeding
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //AddData addData = new AddData();
            //addData.DoTheThing();

            UsersService service = new UsersService();
            var ting = service.FindUserFromName("Ove Larsen");
            Console.WriteLine($"{ting[0].UserName}");
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

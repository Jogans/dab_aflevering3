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

            UsersService user = new UsersService();
            user.RemoveAll();
            CirclesService circle = new CirclesService();
            circle.RemoveAll();

            AddData addData = new AddData();
            addData.DoTheThing();

          
            Console.WriteLine("Data er nu seedet");



        }
    }
}

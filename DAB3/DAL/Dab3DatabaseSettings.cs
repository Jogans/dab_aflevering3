using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAB3.Models
{
    public class Dab3DatabaseSettings : IDab3DatabaseSettings
    {
        public string PostsCollectionName { get; set; }
        public string CommentsCollectionName { get; set; }
        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        public string CircleCollectionName { get; set; }
    }

    public interface IDab3DatabaseSettings
    {
        string PostsCollectionName { get; set; }
        string CommentsCollectionName { get; set; }
        string UsersCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string CircleCollectionName { get; set; }
    }
}
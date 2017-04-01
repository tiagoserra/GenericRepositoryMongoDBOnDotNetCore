using ConsoleApp.Model;
using Repository;

namespace ConsoleApp.Repository
{
    public class BookRepository : MongoRepository<Book>
    {

        #region Ctor

        public BookRepository()
            : base("mongodb://localhost", "GenericReposiotyMongo")
        {

        }

        #endregion

    }
}

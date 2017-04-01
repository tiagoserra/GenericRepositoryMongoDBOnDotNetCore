using Repository;
using WebApp.Model;

namespace WebApp.Repositories
{
    public class CarRepository : MongoRepository<Car>
    {

        #region Ctor

        public CarRepository()
            : base("mongodb://localhost", "GenericReposiotyMongo")
        {
        }

        #endregion
    }
}

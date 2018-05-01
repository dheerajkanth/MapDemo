using SQLite;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MapDemo.Models
{
    public class DataAccess
    {
        public SQLiteConnection DbConn;

        public DataAccess()
        {
            DbConn = DependencyService.Get<IDatabaseConnection>().DbConnection();

            DbConn.CreateTable<FavoriteLocations>();
        }

        public ObservableCollection<FavoriteLocations> FetchFavoriteLocationses(string query)
        {
            return new ObservableCollection<FavoriteLocations>(DbConn.Query<FavoriteLocations>(query));
        }

        public int SaveFaviorateLocation(FavoriteLocations favoriteLocation)
        {
            return DbConn.Insert(favoriteLocation);
        }

        public int DeleteFaviorateLocation(FavoriteLocations favoriteLocation)
        {
            return DbConn.Delete(favoriteLocation);
        }
    }
}

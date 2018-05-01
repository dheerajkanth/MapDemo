using MapDemo.Droid;
using MapDemo.Models;
using SQLite;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnectionAndroid))]
namespace MapDemo.Droid
{
    public class DatabaseConnectionAndroid : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "MapsDb.db3";
            var path = Path.Combine(System.Environment.
                GetFolderPath(System.Environment.
                    SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}
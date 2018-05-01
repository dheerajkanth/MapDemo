using MapDemo.iOS;
using SQLite;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnectionIos))]
namespace MapDemo.iOS
{
    public class DatabaseConnectionIos
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "MapsDb.db3";
            string personalFolder =
                System.Environment.
                    GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder =
                Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(path);
        }
    }
}
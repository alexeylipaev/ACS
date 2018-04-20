
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using SQLite.Net;
//using SQLite.Net.Platform.Win32;
namespace InitializingDBFromXML.Model
{
    class InitializingDBSQLiteFromXML<T> where T : class
    {
        private static string path;
        //public static SQLite.Net.SQLiteConnection Conn { get; set; } = null;
        //static SQLite.Net.TableQuery<T> query = null;

        public InitializingDBSQLiteFromXML(string nameDB)
        {
            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //Для выделения пути к каталогу, воспользуйтесь `System.IO.Path`:
            var DirectoryPath = Path.GetDirectoryName(location);

            path = Path.Combine(DirectoryPath, string.Format("{0}.db", nameDB));

            //создали базу данных
            //Conn = new SQLiteConnection(new SQLitePlatformWin32(), path);

        }

        public void CreateTableEntity(T TypeEntity)
        {
            //создали таблицу 
            //Conn.CreateTable<T>();
            //query = Conn.Table<T>();
        }
        public void InsertTableEntity(object Entity)
        {
            //Conn.Insert(Entity);
        }
    }
}

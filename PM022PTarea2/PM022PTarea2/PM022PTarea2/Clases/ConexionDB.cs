using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SQLite;

namespace PM022PTarea2.Clases
{
    public class ConexionDB
    {
        private string pathdb;
        public ConexionDB() { }

        public string Conector()
        {
            String dbName = "Firmas";
            string path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            pathdb = Path.Combine(path, dbName);
            return pathdb;

        }

        public SQLiteConnection conn()
        {
            SQLiteConnection conn = new SQLiteConnection(App.Firmas);
            return conn;
        }

        public SQLiteAsyncConnection getConnectionAsync()
        {
            return new SQLiteAsyncConnection(App.Firmas);
        }
    }
}

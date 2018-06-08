using prilogg.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace prilogg.Data
{
    public class zapisDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public zapisDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Zapis>();

        }

        public Zapis GetZapis()
        {
            lock (locker)
            {
                if (database.Table<Zapis>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Zapis>().First();
                }
            }
        }

        public int SaveZapis(Zapis zapis1)
        {
            lock (locker)
            {
                if (zapis1.Id != 0)
                {
                    database.Update(zapis1);
                    return zapis1.Id;
                }
                else
                {
                    return database.Insert(zapis1);

                }
            }
        }
        public int DeleteZapis(int id)
        {
            lock (locker)
            {
                return database.Delete<Zapis>(id);
            }
        }
    }
}
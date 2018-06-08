using prilogg.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace prilogg.Data
{
   public class ystroistvaDatabaseController
    {
        static object locker = new object();

        SQLiteConnection database;

        public ystroistvaDatabaseController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Ystroistva>();

        }

        public Ystroistva Getystroistva()
        {
            lock (locker)
            {
                if (database.Table<Ystroistva>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return database.Table<Ystroistva>().First();
                }
            }
        }

        public int SaveYstroistva(Ystroistva ystroistva1)
        {
            lock (locker)
            {
                if (ystroistva1.Id != 0)
                {
                    database.Update(ystroistva1);
                    return ystroistva1.Id;
                }
                else
                {
                    return database.Insert(ystroistva1);

                }
            }
        }
        public int Deleteystroistva(int id)
        {
            lock (locker)
            {
                return database.Delete<Ystroistva>(id);
            }
        }
    }
}

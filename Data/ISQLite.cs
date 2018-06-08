using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace prilogg.Data
{
    interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}

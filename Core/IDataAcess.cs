using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Dette.Core
{
    public interface IDataAcess
    {
        MySqlConnection getConnection();
        void closeConnection();

    }

    /* 
        db_name : gestion_dette_symfony_ism 
     */
}

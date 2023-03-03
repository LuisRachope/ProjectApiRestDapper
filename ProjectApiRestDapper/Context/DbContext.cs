using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProjectApiRestDapper.Context
{
    public class DbContext : IAsyncDisposable
    {
        public MySqlConnection Connection { get; }

        public DbContext(string connection)
        {
            Connection = new MySqlConnection(connection);
            Connection.OpenAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await Connection.CloseAsync();
            await Connection.ClearAllPoolsAsync();
            await Connection.DisposeAsync();
        }
    }
}

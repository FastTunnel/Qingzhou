using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Persistence.Extensions
{
    public class QingZhouDbContext : DapperDbContext, IDbConnection
    {
        public QingZhouDbContext(IOptions<DapperDBContextOptions> optionsAccessor)
            : base(optionsAccessor)
        {
            dbConnection = new MySqlConnection(optionsAccessor.Value.Configuration);
        }

        readonly DbConnection dbConnection;

        public string ConnectionString
        {
            get => dbConnection.ConnectionString;
            set => dbConnection.ConnectionString = value;
        }

        public int ConnectionTimeout => dbConnection.ConnectionTimeout;

        public string Database => dbConnection.Database;

        public ConnectionState State => dbConnection.State;

        public IDbTransaction BeginTransaction()
        {
            return dbConnection.BeginTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return dbConnection.BeginTransaction(il);
        }

        public void ChangeDatabase(string databaseName)
        {
            dbConnection.ChangeDatabase(databaseName);
        }

        public void Close()
        {
            dbConnection.Close();
        }

        public IDbCommand CreateCommand()
        {
            return dbConnection.CreateCommand();
        }

        public void Open()
        {
            dbConnection.Open();
        }

        public void Dispose()
        {
            dbConnection.Dispose();
        }
    }
}

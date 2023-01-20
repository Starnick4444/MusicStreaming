using System.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using MusicStreamingServer.Models;

namespace MusicStreamingServer.DbAccess;

public class SqlDataAccess : ISqlDataAccess
{

    public SqlDataAccess()
    {

    }

    public async Task<IEnumerable<T>> LoadData<T, U>(
        string storedProcedure,
        U parameters,
        string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionId].ConnectionString);

        return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(
        string storedProcedure,
        T parameters,
        string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionId].ConnectionString);

        await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
    }
}

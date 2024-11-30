using System.Data;
using Dapper;
using Museum.WebApi.Models;

namespace Museum.Data.Queries;

public class QueryTenantCommand
    : IDataCommand<int, TenantDto?>
{
    private readonly IConnectionBroker _connectionBroker;

    public QueryTenantCommand(IConnectionBroker connectionBroker)
    {
        _connectionBroker = connectionBroker ?? throw new ArgumentNullException(nameof(connectionBroker));
    }

    public async Task<TenantDto?> ExecuteAsync(int param)
    {
        await using var connection = _connectionBroker.GetConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@TenantId", param, DbType.Int32, ParameterDirection.Input);

        return await connection.QueryFirstOrDefaultAsync<TenantDto>("[dbo].[QueryTenant]", parameters, commandType: CommandType.StoredProcedure);
    }
}
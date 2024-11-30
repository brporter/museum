using System.Data;
using Dapper;
using Museum.WebApi.Models;

namespace Museum.Data.Commands;

public class EstablishTenantCommand 
    : IDataCommand<TenantDto, int>
{
    private readonly IConnectionBroker _connectionBroker;

    public EstablishTenantCommand(IConnectionBroker connectionBroker)
    {
        _connectionBroker = connectionBroker ?? throw new ArgumentNullException(nameof(connectionBroker));
    }

    public async Task<int> ExecuteAsync(TenantDto param)
    {
        await using var connection = _connectionBroker.GetConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@Name", param.Name, DbType.String, ParameterDirection.Input);
        parameters.Add("@TenantId", DbType.Int32, direction: ParameterDirection.ReturnValue);

        await connection.ExecuteAsync("[dbo].[EstablishTenant]", parameters, commandType: CommandType.StoredProcedure);

        return parameters.Get<int>("@TenantId");
    }
}
using System.Data;
using Dapper;
using Museum.WebApi.Models;

namespace Museum.Data.Commands;

public class EstablishTenantCommand 
    : IDataCommand<string, TenantDto>
{
    private readonly IConnectionBroker _connectionBroker;

    public EstablishTenantCommand(IConnectionBroker connectionBroker)
    {
        _connectionBroker = connectionBroker ?? throw new ArgumentNullException(nameof(connectionBroker));
    }

    public async Task<TenantDto> ExecuteAsync(string tenantName)
    {
        await using var connection = _connectionBroker.GetConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@Name", tenantName, DbType.String, ParameterDirection.Input);
        parameters.Add("@TenantId", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@CreatedAt", dbType: DbType.DateTime2, direction: ParameterDirection.Output);
        parameters.Add("@UpdatedAt", dbType: DbType.DateTime2, direction: ParameterDirection.Output);

        await connection.ExecuteAsync("[dbo].[EstablishTenant]", parameters, commandType: CommandType.StoredProcedure);

        return new TenantDto(
            parameters.Get<int>("@TenantId"),
            tenantName,
            parameters.Get<DateTime>("@CreatedAt"),
            parameters.Get<DateTime>("@UpdatedAt"),
            true
        );
    }
}
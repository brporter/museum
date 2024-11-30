using System.Data;
using Dapper;
using Museum.WebApi.Models;

namespace Museum.Data.Commands;

public class EstablishTenantCommand 
    : IDataCommand<TenantDto>
{
    private readonly IConnectionBroker _connectionBroker;

    public EstablishTenantCommand(IConnectionBroker connectionBroker)
    {
        _connectionBroker = connectionBroker ?? throw new ArgumentNullException(nameof(connectionBroker));
    }

    public async Task ExecuteAsync(TenantDto param)
    {
        await using var connection = _connectionBroker.GetConnection();

        var parameters = new DynamicParameters();
        parameters.Add("@Name", param.Name, DbType.String, ParameterDirection.Input);
        parameters.Add("@TenantId", dbType: DbType.Int32, direction: ParameterDirection.Output);
        parameters.Add("@CreatedAt", dbType: DbType.DateTime2, direction: ParameterDirection.Output);
        parameters.Add("@UpdatedAt", dbType: DbType.DateTime2, direction: ParameterDirection.Output);

        await connection.ExecuteAsync("[dbo].[EstablishTenant]", parameters, commandType: CommandType.StoredProcedure);

        param.TenantId = parameters.Get<int>("@TenantId");
        param.CreatedAt = parameters.Get<DateTime>("@CreatedAt");
        param.UpdatedAt = parameters.Get<DateTime>("@UpdatedAt");
        param.IsEnabled = true;
    }
}
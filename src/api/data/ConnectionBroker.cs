using System.Data.Common;

namespace Museum.Data;

public interface IConnectionBroker
{
    public DbConnection GetConnection();
}

public class ConnectionBroker
    : IConnectionBroker
{
    private readonly string _connectionString;
    private readonly DbProviderFactory _providerFactory;

    public ConnectionBroker(DbProviderFactory providerFactory, string connectionString)
    {
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentException("Value cannot be null or whitespace.", nameof(connectionString));
        }

        _connectionString = connectionString;
        _providerFactory = providerFactory ?? throw new ArgumentNullException(nameof(providerFactory));
    }

    public DbConnection GetConnection()
    {
        var connection = _providerFactory.CreateConnection() ?? throw new InvalidOperationException("Failed to create connection.");
        
        connection.ConnectionString = _connectionString;
        
        return connection;
    }
}
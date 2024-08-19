namespace Aoxe.Extensions.Configuration.Etcd;

public class EtcdClientOptions(string connectionString)
{
    public string ConnectionString { get; set; } = connectionString;
    public int Port { get; set; } = 2379;
    public string ServerName { get; set; } = "my-etcd-server";
    public Action<GrpcChannelOptions>? ConfigureChannelOptions { get; set; } = null;
    public Interceptor[]? Interceptors { get; set; } = null;
}

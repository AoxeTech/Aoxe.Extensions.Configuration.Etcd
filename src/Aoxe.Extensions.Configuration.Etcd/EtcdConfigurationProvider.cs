namespace Aoxe.Extensions.Configuration.Etcd;

public class EtcdConfigurationProvider(EtcdConfigurationSource source, IFlattener? flattener = null)
    : ConfigurationProvider,
        IDisposable
{
    private readonly EtcdClient _etcdClient =
        new(
            source.EtcdClientOptions.ConnectionString,
            source.EtcdClientOptions.Port,
            source.EtcdClientOptions.ServerName,
            source.EtcdClientOptions.ConfigureChannelOptions,
            source.EtcdClientOptions.Interceptors
        );

    public override void Load()
    {
        var value = _etcdClient.GetVal(source.Key);
        Data = flattener is null
            ? new Dictionary<string, string?> { { source.Key, value } }
            : flattener.Flatten(new MemoryStream(Encoding.UTF8.GetBytes(value)));
    }

    public void Dispose() => _etcdClient.Dispose();
}

namespace Aoxe.Extensions.Configuration.Etcd;

public class EtcdConfigurationProvider(
    EtcdConfigurationSource source,
    IEtcdClientFactory etcdClientFactory,
    IFlattener? flattener = null
) : ConfigurationProvider
{
    public override void Load()
    {
        using var etcdClient = etcdClientFactory.Create();
        var value = etcdClient.GetVal(source.Key);
        Data = flattener is null
            ? new Dictionary<string, string?> { { source.Key, value } }
            : flattener.Flatten(new MemoryStream(Encoding.UTF8.GetBytes(value)));
    }
}

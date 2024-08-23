namespace Aoxe.Extensions.Configuration.Etcd;

public class EtcdConfigurationSource(
    EtcdClientOptions etcdClientOptions,
    string key,
    IFlattener? flattener = null
) : IConfigurationSource
{
    public EtcdClientOptions EtcdClientOptions { get; } = etcdClientOptions;
    public string Key { get; } = key;

    public IConfigurationProvider Build(IConfigurationBuilder builder) =>
        new EtcdConfigurationProvider(this, new EtcdClientFactory(this), flattener);
}

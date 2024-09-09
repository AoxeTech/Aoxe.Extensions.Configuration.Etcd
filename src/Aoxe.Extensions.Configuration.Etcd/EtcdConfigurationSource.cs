namespace Aoxe.Extensions.Configuration.Etcd;

public class EtcdConfigurationSource(
    EtcdClientOptions options,
    string key,
    IFlattener? flattener = null
) : IConfigurationSource
{
    public EtcdClientOptions EtcdClientOptions { get; } = options;
    public string Key { get; } = key;

    public EtcdConfigurationSource(
        Func<EtcdClientOptions> optionsFactory,
        string key,
        IFlattener? flattener = null
    )
        : this(optionsFactory(), key, flattener) { }

    public IConfigurationProvider Build(IConfigurationBuilder builder) =>
        new EtcdConfigurationProvider(this, new EtcdClientFactory(this), flattener);
}

namespace Aoxe.Extensions.Configuration.Etcd;

public class EtcdConfigurationSource(
    EtcdClientOptions options,
    string key,
    IFlattener? flattener = null,
    bool reloadOnChange = false
) : IConfigurationSource
{
    public EtcdClientOptions EtcdClientOptions { get; } = options;
    public string Key { get; } = key;
    public bool ReloadOnChange { get; } = reloadOnChange;

    public EtcdConfigurationSource(
        Func<EtcdClientOptions> optionsFactory,
        string key,
        IFlattener? flattener = null,
        bool reloadOnChange = false
    )
        : this(optionsFactory(), key, flattener, reloadOnChange) { }

    public IConfigurationProvider Build(IConfigurationBuilder builder) =>
        new EtcdConfigurationProvider(this, new EtcdClientFactory(this), flattener);
}

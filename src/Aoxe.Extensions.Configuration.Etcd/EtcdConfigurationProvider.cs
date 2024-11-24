namespace Aoxe.Extensions.Configuration.Etcd;

public class EtcdConfigurationProvider : ConfigurationProvider
{
    private readonly EtcdConfigurationSource _source;
    private readonly IEtcdClientFactory _etcdClientFactory;
    private readonly IFlattener? _flattener;

    public EtcdConfigurationProvider(
        EtcdConfigurationSource source,
        IEtcdClientFactory etcdClientFactory,
        IFlattener? flattener = null
    )
    {
        _source = source;
        _etcdClientFactory = etcdClientFactory;
        _flattener = flattener;

        if (!_source.ReloadOnChange)
            return;
        var watcher = new EtcdWatcherService(_etcdClientFactory, _source.Key, ReloadAsync);
        watcher.StartWatching();
    }

    public override void Load()
    {
        LoadAsync().GetAwaiter().GetResult();
    }

    private async Task LoadAsync()
    {
        using var etcdClient = _etcdClientFactory.Create();
        var value = await etcdClient.GetValAsync(_source.Key);
        Data = _flattener is null
            ? new Dictionary<string, string?> { { _source.Key, value } }
            : _flattener.Flatten(new MemoryStream(Encoding.UTF8.GetBytes(value)));
    }

    private void ReloadAsync()
    {
        Load();
        OnReload();
    }
}

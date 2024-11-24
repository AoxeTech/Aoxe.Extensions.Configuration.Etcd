namespace Aoxe.Extensions.Configuration.Etcd;

public class EtcdWatcherService
{
    private readonly IEtcdClientFactory _etcdClientFactory;
    private readonly string _key;
    private readonly Action _onChange;

    internal EtcdWatcherService(IEtcdClientFactory etcdClientFactory, string key, Action onChange)
    {
        _etcdClientFactory = etcdClientFactory;
        _key = key;
        _onChange = onChange;
    }

    internal void StartWatching()
    {
        Task.Run(async () =>
        {
            using var etcdClient = _etcdClientFactory.Create();
            await etcdClient.WatchAsync(_key, WatchCallback);
        });
    }

    private void WatchCallback(WatchResponse response)
    {
        foreach (var evt in response.Events)
        {
            if (evt.Kv.Key.ToString() != _key)
                continue;
            _onChange();
        }
    }
}

namespace Aoxe.Extensions.Configuration.Etcd;

public static class EtcdConfigurationExtensions
{
    public static IConfigurationBuilder AddEtcd(
        this IConfigurationBuilder builder,
        EtcdClientOptions etcdClientOptions,
        string key,
        IFlattener? flattener = null
    ) => builder.Add(new EtcdConfigurationSource(etcdClientOptions, key, flattener));
}

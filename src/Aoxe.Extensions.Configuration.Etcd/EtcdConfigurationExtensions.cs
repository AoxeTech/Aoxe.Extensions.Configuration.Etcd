namespace Aoxe.Extensions.Configuration.Etcd;

public static class EtcdConfigurationExtensions
{
    public static IConfigurationBuilder AddEtcd(
        this IConfigurationBuilder builder,
        Func<EtcdClientOptions> optionsFactory,
        string key,
        IFlattener? flattener = null
    ) => builder.Add(new EtcdConfigurationSource(optionsFactory, key, flattener));

    public static IConfigurationBuilder AddEtcd(
        this IConfigurationBuilder builder,
        EtcdClientOptions options,
        string key,
        IFlattener? flattener = null
    ) => builder.Add(new EtcdConfigurationSource(options, key, flattener));
}

namespace Aoxe.Extensions.Configuration.Etcd.NewtonsoftJson;

public static class EtcdConfigurationExtensions
{
    public static IConfigurationBuilder AddEtcdJson(
        this IConfigurationBuilder builder,
        EtcdClientOptions etcdClientOptions,
        string key
    ) => builder.Add(new EtcdConfigurationSource(etcdClientOptions, key, new JsonFlattener()));
}

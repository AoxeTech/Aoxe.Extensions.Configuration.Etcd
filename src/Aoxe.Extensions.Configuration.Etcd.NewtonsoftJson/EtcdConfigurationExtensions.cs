namespace Aoxe.Extensions.Configuration.Etcd.NewtonsoftJson;

public static class EtcdConfigurationExtensions
{
    public static IConfigurationBuilder AddEtcdJson(
        this IConfigurationBuilder builder,
        Func<EtcdClientOptions> optionsFactory,
        string key
    ) => builder.Add(new EtcdConfigurationSource(optionsFactory, key, new JsonFlattener()));

    public static IConfigurationBuilder AddEtcdJson(
        this IConfigurationBuilder builder,
        EtcdClientOptions options,
        string key
    ) => builder.Add(new EtcdConfigurationSource(options, key, new JsonFlattener()));
}

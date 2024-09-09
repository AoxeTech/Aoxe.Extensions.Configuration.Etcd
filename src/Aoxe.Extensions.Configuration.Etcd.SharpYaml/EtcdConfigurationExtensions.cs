namespace Aoxe.Extensions.Configuration.Etcd.SharpYaml;

public static class EtcdConfigurationExtensions
{
    public static IConfigurationBuilder AddEtcdYaml(
        this IConfigurationBuilder builder,
        Func<EtcdClientOptions> optionsFactory,
        string key
    ) => builder.Add(new EtcdConfigurationSource(optionsFactory, key, new YamlFlattener()));

    public static IConfigurationBuilder AddEtcdYaml(
        this IConfigurationBuilder builder,
        EtcdClientOptions options,
        string key
    ) => builder.Add(new EtcdConfigurationSource(options, key, new YamlFlattener()));
}

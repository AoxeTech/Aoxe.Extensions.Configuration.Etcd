namespace Aoxe.Extensions.Configuration.Etcd.Tomlet;

public static class EtcdConfigurationExtensions
{
    public static IConfigurationBuilder AddEtcdToml(
        this IConfigurationBuilder builder,
        Func<EtcdClientOptions> optionsFactory,
        string key
    ) => builder.Add(new EtcdConfigurationSource(optionsFactory, key, new TomlFlattener()));

    public static IConfigurationBuilder AddEtcdToml(
        this IConfigurationBuilder builder,
        EtcdClientOptions options,
        string key
    ) => builder.Add(new EtcdConfigurationSource(options, key, new TomlFlattener()));
}

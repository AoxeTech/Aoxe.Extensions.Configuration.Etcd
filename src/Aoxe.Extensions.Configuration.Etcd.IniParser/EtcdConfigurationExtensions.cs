namespace Aoxe.Extensions.Configuration.Etcd.IniParser;

public static class EtcdConfigurationExtensions
{
    public static IConfigurationBuilder AddEtcdIni(
        this IConfigurationBuilder builder,
        Func<EtcdClientOptions> optionsFactory,
        string key
    ) => builder.Add(new EtcdConfigurationSource(optionsFactory, key, new IniFlattener()));

    public static IConfigurationBuilder AddEtcdIni(
        this IConfigurationBuilder builder,
        EtcdClientOptions options,
        string key
    ) => builder.Add(new EtcdConfigurationSource(options, key, new IniFlattener()));
}

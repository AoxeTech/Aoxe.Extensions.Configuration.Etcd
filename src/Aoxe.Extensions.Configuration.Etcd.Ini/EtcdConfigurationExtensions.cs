namespace Aoxe.Extensions.Configuration.Etcd.Ini;

public static class EtcdConfigurationExtensions
{
    public static IConfigurationBuilder AddEtcdIni(
        this IConfigurationBuilder builder,
        EtcdClientOptions etcdClientOptions,
        string key
    ) => builder.Add(new EtcdConfigurationSource(etcdClientOptions, key, new IniFlattener()));
}

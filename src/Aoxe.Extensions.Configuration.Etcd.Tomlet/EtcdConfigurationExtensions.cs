namespace Aoxe.Extensions.Configuration.Etcd.Tomlet;

public static class EtcdConfigurationExtensions
{
    public static IConfigurationBuilder AddEtcdYaml(
        this IConfigurationBuilder builder,
        EtcdClientOptions etcdClientOptions,
        string key
    ) => builder.Add(new EtcdConfigurationSource(etcdClientOptions, key, new TomlFlattener()));
}

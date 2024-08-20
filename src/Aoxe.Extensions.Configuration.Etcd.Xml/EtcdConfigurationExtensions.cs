namespace Aoxe.Extensions.Configuration.Etcd.Xml;

public static class EtcdConfigurationExtensions
{
    public static IConfigurationBuilder AddEtcdXml(
        this IConfigurationBuilder builder,
        EtcdClientOptions etcdClientOptions,
        string key
    ) => builder.Add(new EtcdConfigurationSource(etcdClientOptions, key, new XmlFlattener()));
}

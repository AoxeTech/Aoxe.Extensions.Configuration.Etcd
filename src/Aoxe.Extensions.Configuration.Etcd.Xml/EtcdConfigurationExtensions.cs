namespace Aoxe.Extensions.Configuration.Etcd.Xml;

public static class EtcdConfigurationExtensions
{
    public static IConfigurationBuilder AddEtcdXml(
        this IConfigurationBuilder builder,
        Func<EtcdClientOptions> optionsFactory,
        string key
    ) => builder.Add(new EtcdConfigurationSource(optionsFactory, key, new XmlFlattener()));

    public static IConfigurationBuilder AddEtcdXml(
        this IConfigurationBuilder builder,
        EtcdClientOptions options,
        string key
    ) => builder.Add(new EtcdConfigurationSource(options, key, new XmlFlattener()));
}

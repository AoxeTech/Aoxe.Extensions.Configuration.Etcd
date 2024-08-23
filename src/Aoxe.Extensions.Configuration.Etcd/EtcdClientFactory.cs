namespace Aoxe.Extensions.Configuration.Etcd;

public class EtcdClientFactory(EtcdConfigurationSource source) : IEtcdClientFactory
{
    public EtcdClient Create() =>
        new(
            source.EtcdClientOptions.ConnectionString,
            source.EtcdClientOptions.Port,
            source.EtcdClientOptions.ServerName,
            source.EtcdClientOptions.ConfigureChannelOptions,
            source.EtcdClientOptions.Interceptors
        );
}

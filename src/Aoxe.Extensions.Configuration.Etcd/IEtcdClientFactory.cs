namespace Aoxe.Extensions.Configuration.Etcd;

public interface IEtcdClientFactory
{
    EtcdClient Create();
}

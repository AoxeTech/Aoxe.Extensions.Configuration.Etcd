namespace Aoxe.Extensions.Configuration.Etcd.SharpYaml.Test;

public class EtcdConfigurationUnitTest
{
    [Fact]
    public void ConfigurationTest()
    {
        var configBuilder = new ConfigurationBuilder().AddEtcd(
            new EtcdClientOptions("https://127.0.0.1")
            {
                ConfigureChannelOptions = options =>
                    options.Credentials = ChannelCredentials.Insecure
            },
            "/test-yaml",
            new YamlFlattener()
        );
        var configuration = configBuilder.Build();
        Assert.Equal("nestedStringValue", configuration["nestedObject:nestedStringKey"]);
    }

    [Fact]
    public void ConfigurationIniTest()
    {
        var configBuilder = new ConfigurationBuilder().AddEtcdYaml(
            new EtcdClientOptions("https://127.0.0.1")
            {
                ConfigureChannelOptions = options =>
                    options.Credentials = ChannelCredentials.Insecure
            },
            "/test-yaml"
        );
        var configuration = configBuilder.Build();
        Assert.Equal("nestedStringValue", configuration["nestedObject:nestedStringKey"]);
    }
}

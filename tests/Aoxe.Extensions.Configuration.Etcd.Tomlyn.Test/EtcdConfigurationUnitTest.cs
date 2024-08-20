namespace Aoxe.Extensions.Configuration.Etcd.Tomlyn.Test;

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
            "/test-toml",
            new TomlFlattener()
        );
        var configuration = configBuilder.Build();
        Assert.Equal("nestedStringValue", configuration["nestedObject:nestedStringKey"]);
    }

    [Fact]
    public void ConfigurationIniTest()
    {
        var configBuilder = new ConfigurationBuilder().AddEtcdToml(
            new EtcdClientOptions("https://127.0.0.1")
            {
                ConfigureChannelOptions = options =>
                    options.Credentials = ChannelCredentials.Insecure
            },
            "/test-toml"
        );
        var configuration = configBuilder.Build();
        Assert.Equal("nestedStringValue", configuration["nestedObject:nestedStringKey"]);
    }
}

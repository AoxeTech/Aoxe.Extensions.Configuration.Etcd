namespace Aoxe.Extensions.Configuration.Etcd.Test;

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
            "/test-json"
        );
        var configuration = configBuilder.Build();
        Assert.NotEmpty(configuration["/test-json"]!);
    }

    [Fact]
    public void ConfigurationWithFlattenerTest()
    {
        var configBuilder = new ConfigurationBuilder().AddEtcd(
            new EtcdClientOptions("https://127.0.0.1")
            {
                ConfigureChannelOptions = options =>
                    options.Credentials = ChannelCredentials.Insecure
            },
            "/test-json",
            new JsonFlattener()
        );
        var configuration = configBuilder.Build();
        Assert.Equal("nestedStringValue", configuration["nestedObject:nestedStringKey"]);
    }
}

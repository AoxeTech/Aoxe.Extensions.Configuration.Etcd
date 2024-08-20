namespace Aoxe.Extensions.Configuration.Etcd.IniParser.Test;

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
            "/test-ini",
            new IniFlattener()
        );
        var configuration = configBuilder.Build();
        Assert.Equal("nestedStringValue", configuration["nestedSection:nestedStringKey"]);
    }

    [Fact]
    public void ConfigurationIniTest()
    {
        var configBuilder = new ConfigurationBuilder().AddEtcdIni(
            new EtcdClientOptions("https://127.0.0.1")
            {
                ConfigureChannelOptions = options =>
                    options.Credentials = ChannelCredentials.Insecure
            },
            "/test-ini"
        );
        var configuration = configBuilder.Build();
        Assert.Equal("nestedStringValue", configuration["nestedSection:nestedStringKey"]);
    }
}

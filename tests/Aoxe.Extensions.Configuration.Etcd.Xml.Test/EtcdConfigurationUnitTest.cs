namespace Aoxe.Extensions.Configuration.Etcd.Xml.Test;

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
            "/test-xml",
            new XmlFlattener()
        );
        var configuration = configBuilder.Build();
        Assert.Equal("nestedStringValue", configuration["nestedObject:nestedStringKey"]);
    }

    [Fact]
    public void ConfigurationXmlTest()
    {
        var configBuilder = new ConfigurationBuilder().AddEtcdXml(
            new EtcdClientOptions("https://127.0.0.1")
            {
                ConfigureChannelOptions = options =>
                    options.Credentials = ChannelCredentials.Insecure
            },
            "/test-xml"
        );
        var configuration = configBuilder.Build();
        Assert.Equal("nestedStringValue", configuration["nestedObject:nestedStringKey"]);
    }
}

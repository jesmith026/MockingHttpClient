
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApiCaller.Tests.Helpers.HttpClient;
using Xunit;

namespace ApiCaller.Tests
{
    public class ApiProxyTests
    {
        [Fact]
        public async Task WhenTheCallToTheApiFailsThenWeShouldThrowAServiceFailedException()
        {
            var handler = FakeHttpMessageHandler.NewMock();
            handler.SetupFailedCall();
            var client = HttpClientHelper.NewTestClient(handler.Object);

            var proxy = new ApiProxyTestClass(client);

            await Assert.ThrowsAsync<ServiceFailedException>(() => proxy.GetValues());
        }

        [Fact]
        public async Task WhenTheCallIsSuccessfulThenWeShouldReceiveAListOfStrings()
        {
            var handler = FakeHttpMessageHandler.NewMock();
            handler.SetupSuccessfulCall(new List<string>{"test1", "test2"});
            var client = HttpClientHelper.NewTestClient(handler.Object);

            var proxy = new ApiProxyTestClass(client);

            var result = await proxy.GetValues();

            Assert.NotNull(result);
            Assert.True(result.Any());
            Assert.Equal("test1", result.First());
            Assert.Equal("test2", result.Skip(1).First());
        }

        private class ApiProxyTestClass : ApiProxy
        {
            public ApiProxyTestClass(HttpClient client)
            {
                this._client = client;
            }
        }
    }
}
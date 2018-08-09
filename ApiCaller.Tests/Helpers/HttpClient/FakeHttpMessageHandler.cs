using System;
using System.Net.Http;
using System.Threading.Tasks;
using Moq;

namespace ApiCaller.Tests.Helpers.HttpClient
{
    public class FakeHttpMessageHandler : HttpMessageHandler
    {
        public static Mock<FakeHttpMessageHandler> NewMock() => 
            new Mock<FakeHttpMessageHandler> { CallBase = true };

        public virtual HttpResponseMessage Send(HttpRequestMessage request) => 
            throw new NotImplementedException("Now we can setup this method with our mocking framework");

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken) => 
            Task.FromResult(Send(request));
    }
}
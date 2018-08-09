using System;
using System.Net.Http;

namespace ApiCaller.Tests.Helpers.HttpClient
{
    public static class HttpClientHelper
    {
        public static System.Net.Http.HttpClient NewTestClient(HttpMessageHandler handler)
        {
            return new System.Net.Http.HttpClient(handler) { BaseAddress = new Uri("http://localhost") };
        }
    }
}
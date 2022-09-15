using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http;
using Toolbelt.Blazor;

namespace admin.workspace.Client.Interceptor
{
    public class InterceptorServiceGlobal : IDisposable
    {
        private Snackbar _snackbar;
        private readonly HttpClient HttpClient;

        private readonly HttpClientInterceptor HttpClientInterceptor;

        private readonly NavigationManager _navigation;
        public InterceptorServiceGlobal(IHttpClientFactory httpClientFactory, HttpClientInterceptor httpClientInterceptor, NavigationManager navigationManager)
        {
            _navigation = navigationManager;

            this.HttpClient = httpClientFactory.CreateClient("for InterceptorServiceGlobal");
            this.HttpClientInterceptor = httpClientInterceptor;

            this.HttpClientInterceptor.BeforeSend += HttpClientInterceptor_BeforeSend;
            this.HttpClientInterceptor.BeforeSendAsync += HttpClientInterceptor_BeforeSendAsync;
            this.HttpClientInterceptor.AfterSend += HttpClientInterceptor_AfterSend;
            this.HttpClientInterceptor.AfterSendAsync += HttpClientInterceptor_AfterSendAsync;
        }
        private void HttpClientInterceptor_BeforeSend(object sender, HttpClientInterceptorEventArgs e)
        {
        }

        private async Task HttpClientInterceptor_BeforeSendAsync(object sender, HttpClientInterceptorEventArgs e)
        {

        }

        private void HttpClientInterceptor_AfterSend(object sender, HttpClientInterceptorEventArgs e)
        {

        }

        private async Task HttpClientInterceptor_AfterSendAsync(object sender, HttpClientInterceptorEventArgs e)
        {


            if (!e.Response.IsSuccessStatusCode)
            {

                _navigation.NavigateTo($"/ErrorPage/{(int)e.Response.StatusCode} - {e.Response.ReasonPhrase}");
                Console.WriteLine((int)e.Response.StatusCode);
                Console.WriteLine(e.Response.ReasonPhrase);
                Console.WriteLine(e.Response.IsSuccessStatusCode);
                Console.WriteLine(e.Response);
            }

        }

        public void Dispose()
        {
            this.HttpClientInterceptor.BeforeSend -= HttpClientInterceptor_BeforeSend;
            this.HttpClientInterceptor.BeforeSendAsync -= HttpClientInterceptor_BeforeSendAsync;
            this.HttpClientInterceptor.AfterSend -= HttpClientInterceptor_AfterSend;
            this.HttpClientInterceptor.AfterSendAsync -= HttpClientInterceptor_AfterSendAsync;
            this.HttpClient.Dispose();
        }
    }
}

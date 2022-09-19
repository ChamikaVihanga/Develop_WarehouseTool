using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Net.Http;
using Toolbelt.Blazor;

namespace Workspace.Client.Interceptor
{
    public class InterceptorServiceGlobal :IDisposable
    {
        private ISnackbar _snackbar;
        private readonly HttpClient HttpClient;

        private readonly HttpClientInterceptor HttpClientInterceptor;

        private readonly NavigationManager _navigation;
        public InterceptorServiceGlobal(IHttpClientFactory httpClientFactory, HttpClientInterceptor httpClientInterceptor, NavigationManager navigationManager, ISnackbar snackbar)
        {
            _navigation = navigationManager;
            _snackbar = snackbar;
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
              
            }
             
            if (e.Response.IsSuccessStatusCode)
            {
                if (e.Request.Method == HttpMethod.Post || e.Request.Method == HttpMethod.Put || e.Request.Method == HttpMethod.Delete || e.Request.Method == HttpMethod.Patch)
                {
                    _snackbar.Add($"Server-Response: {e.Response.StatusCode}", Severity.Success);

                }
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

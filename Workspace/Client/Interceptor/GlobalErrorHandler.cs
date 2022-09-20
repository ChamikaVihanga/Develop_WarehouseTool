using Microsoft.AspNetCore.Components;
using Toolbelt.Blazor;
using System.Net;

namespace Workspace.Client.Interceptor
{
    public class GlobalErrorHandler
    {
        private readonly HttpClientInterceptor _intercepter;
        private readonly NavigationManager _navManager;

        public GlobalErrorHandler(HttpClientInterceptor intercepter, NavigationManager navManager)
        {
            _intercepter = intercepter;
            _navManager = navManager;
        }
        public void MonitorEvent() => _intercepter.AfterSend += InterceptResponse;

        private void InterceptResponse(object? sender, HttpClientInterceptorEventArgs e)
        {
            string message = string.Empty;
            if (!e.Response.IsSuccessStatusCode)
            {
                var responseCode = e.Response.StatusCode;
                switch (responseCode)
                {
                    case HttpStatusCode.Unauthorized:
                        _navManager.NavigateTo("/401");
                        e.Response.StatusCode = HttpStatusCode.OK;
                        e.Response.Content = null;
                        e.Response.Headers.Clear();
                        

                        message = "Unauthorized";
                        break;
                    case HttpStatusCode.Forbidden:
                        _navManager.NavigateTo("/401");
                        //e.Response.StatusCode = HttpStatusCode.OK;
                        //e.Response.Content = null;
                        message = "Unauthorized";
                        break;

                    default:
                        _navManager.NavigateTo("/500");
                        break;
                        

                }
                throw new Exception(message);
            }
        }
        public void DisposeEvent() => _intercepter.AfterSend -= InterceptResponse;
    }

}

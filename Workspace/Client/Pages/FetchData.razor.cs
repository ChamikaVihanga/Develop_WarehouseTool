using Microsoft.AspNetCore.Components;
using Workspace.Client.Interceptor;

namespace Workspace.Client.Pages
{
    public partial class FetchData
    {
        [Inject] HttpClient Http { get; set; }
        //[Inject] GlobalErrorHandler _interceptor { get; set; }
        private WeatherForecast[]? forecasts;

        protected override async Task OnInitializedAsync()
        {
            //_interceptor.MonitorEvent();
            forecasts = await Http.GetFromJsonAsync<WeatherForecast[]?>("WeatherForecast");

        }

        //public void Dispose()
        //{
        //    Console.WriteLine("Disposed");
        //    _interceptor.DisposeEvent();  
        //}
    }
}

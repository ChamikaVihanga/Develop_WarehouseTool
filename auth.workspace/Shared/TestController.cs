using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace auth.workspace.Shared
{
    public class TestController
    {
        public int id { get; set; }
        public string name { get; set; }

        public int WeatherId { get; set; }

        public WeatherForecast Weather { get; set; }
    }
}

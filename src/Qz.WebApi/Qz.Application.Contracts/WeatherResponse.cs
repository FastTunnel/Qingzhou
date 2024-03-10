using Qz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Contracts
{
    public class WeatherResponse
    {
        public IEnumerable<WeatherAggregateRoot> WeatherList {  get; set; }
    }
}

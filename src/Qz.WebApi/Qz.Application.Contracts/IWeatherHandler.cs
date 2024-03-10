using Qz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qz.Application.Contracts
{
    public interface IWeatherHandler
    {
        public Task<IEnumerable<WeatherAggregateRoot>> Handle(WeatherRequest request, CancellationToken cancellationToken);
    }
}

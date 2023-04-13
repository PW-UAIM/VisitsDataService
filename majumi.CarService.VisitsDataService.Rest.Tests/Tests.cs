using System.Diagnostics;
using System.Text.Json;

using majumi.CarService.VisitsDataService.Logic;
using majumi.CarService.VisitsDataService.Model;
using majumi.CarService.VisitsDataService.Model.Services;
using majumi.CarService.VisitsDataService.Rest.Model.Model;
using majumi.CarService.VisitsDataService.Rest.Model.Services;

namespace majumi.CarService.VisitsDataService.Rest.Tests;
public class Tests : ITestsService
{
    private static readonly HttpClient httpClient = new();

    public string RunTests(string host, int port)
    {
        throw new NotImplementedException();
    }
}


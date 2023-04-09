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
        Debug.Assert(condition: port > 0);

        try
        {
            IVisitCollection visitCollection = new VisitCollection();

            Visit[] visits1 = visitCollection.GetAllVisits();
            VisitData[] visits2 = GetVisits(host, (ushort)port);

            Debug.Assert(condition: visits1.Length == visits2.Length);
        }
        catch (Exception e)
        {
            return e.Message;
        }
        return "No errors";
    }

    private VisitData[] GetVisits(string webServiceHost, ushort webServicePort)
    {
        string webServiceUri = string.Format("https://{0}:{1}/allVisits", webServiceHost, webServicePort);

        Task<string> webServiceCall = CallWebService(HttpMethod.Get, webServiceUri);

        webServiceCall.Wait();

        string jsonResponseContent = webServiceCall.Result;

        VisitData[] visits = ConvertJson(jsonResponseContent);

        return visits;
    }

    public static async Task<string> CallWebService(HttpMethod httpMethod, string webServiceUri)
    {
        HttpRequestMessage httpRequestMessage = new HttpRequestMessage(httpMethod, webServiceUri);

        httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

        HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        httpResponseMessage.EnsureSuccessStatusCode();

        string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

        return httpResponseContent;
    }

    public VisitData[] ConvertJson(string json)
    {
        VisitData[] visits = JsonSerializer.Deserialize<VisitData[]>(json);

        return visits;
    }
}


using Microsoft.AspNetCore.Mvc;

using majumi.CarService.VisitsDataService.Logic;
using majumi.CarService.VisitsDataService.Model;
using majumi.CarService.VisitsDataService.Model.Services;
using majumi.CarService.VisitsDataService.Rest.Model.Services;

namespace majumi.CarService.VisitsDataService.Rest.Controllers;

[ApiController]
[Route("[controller]")]
public class VisitDataController : ControllerBase, IVisitDataService, ITestsService
{
    private readonly ILogger<VisitDataController> _logger;

    private readonly IVisitCollection visitCollection;

    public VisitDataController(ILogger<VisitDataController> logger)
    {
        _logger = logger;
        visitCollection = new VisitCollection();
    }

    [HttpGet]
    [Route("/visit/{id:int}")]
    public Visit GetVisit(int id)
    {
        return visitCollection.GetById(id);
    }

    [HttpGet]
    [Route("/allVisits")]
    public Visit[] GetAllVisits()
    {
        return visitCollection.GetAllVisits();
    }

    [HttpGet]
    [Route("/runTests")]
    public string RunTests(string host, int port)
    {
        ITestsService tests = new Tests.Tests();

        return tests.RunTests(host, port);
    }
}
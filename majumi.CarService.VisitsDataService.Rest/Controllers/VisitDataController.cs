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
    public Visit GetVisitById(int id)
    {
        return visitCollection.GetVisitById(id);
    }

    [HttpGet]
    [Route("/visit/client/{id:int}")]
    public Visit[] GetVisitByClient(int id)
    {
        return visitCollection.GetVisitsByClient(id);
    }

    [HttpGet]
    [Route("/visit/mechanic/{id:int}")]
    public Visit[] GetVisitByMechanic(int id)
    {
        return visitCollection.GetVisitsByMechanic(id);
    }

    [HttpGet]
    [Route("/visit/all")]
    public Visit[] GetAllVisits()
    {
        return visitCollection.GetAllVisits();
    }

    [HttpGet]
    [Route("/visit/mechanic/{id:int}/date/{year:int}/{month:int}/{day:int}")]
    public Visit[] GetVisitByMechanicAndDate(int id, int year, int month, int day)
    {
        return visitCollection.GetVisitsByMechanicAndDate(id, year, month, day);
    }

    [HttpPost]
    [Route("/visit/add")]
    public bool AddVisit(Visit visit)
    {
        return visitCollection.AddVisit(visit);
    }

    [HttpPatch]
    [Route("/visit/{id:int}/update/{status}")]
    public Visit UpdateVisitStatus(int id, string status)
    {
        return visitCollection.UpdateVisitStatus(id, status);
    }

    [HttpGet]
    [Route("/runTests")]
    public string RunTests(string host, int port)
    {
        ITestsService tests = new Tests.Tests();

        return tests.RunTests(host, port);
    }
}
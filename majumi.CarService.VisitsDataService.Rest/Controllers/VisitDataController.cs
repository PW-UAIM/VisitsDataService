using Microsoft.AspNetCore.Mvc;

using majumi.CarService.VisitsDataService.Logic;
using majumi.CarService.VisitsDataService.Model;
using majumi.CarService.VisitsDataService.Model.Services;
using majumi.CarService.VisitsDataService.Rest.Model.Services;
using majumi.CarService.VisitsDataService.Rest.Model.Model;
using majumi.CarService.VisitsDataService.Rest.Model.Converters;

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
    [Route("/getVisit/{id:int}")]
    public ActionResult<VisitData> GetVisitById(int id)
    {
        Visit? visit = visitCollection.GetVisitById(id);
        if (visit == null) 
            return NotFound();
            
        VisitData visitData = DataConverter.ConvertToVisitData(visit);
        return Ok(visitData);
    }

    [HttpGet]
    [Route("/getAllVisitsByClient/{id:int}")]
    public ActionResult<List<VisitData>> GetVisitsByClient(int id)
    {
        List<Visit>? visits = visitCollection.GetVisitsByClient(id);
        List<VisitData> visitData = DataConverter.ConvertToVisitDataList(visits);

        return Ok(visitData);
    }

    [HttpGet]
    [Route("/getAllVisitsByMechanic/{id:int}")]
    public ActionResult<List<VisitData>> GetVisitsByMechanic(int id)
    {
        List<Visit>? visits = visitCollection.GetVisitsByMechanic(id);
        List<VisitData> visitData = DataConverter.ConvertToVisitDataList(visits);

        return Ok(visitData);
    }

    [HttpGet]
    [Route("/getAllVisits")]
    public ActionResult<List<VisitData>> GetAllVisits()
    {
        List<Visit> visits = visitCollection.GetAllVisits();
        List<VisitData> visitData = DataConverter.ConvertToVisitDataList(visits);

        return Ok(visitData);
    }

    [HttpGet]
    [Route("/getAllVisitsByMechanicInDay/{id:int}/{year:int}/{month:int}/{day:int}")]
    public ActionResult<List<VisitData>> GetVisitByMechanicAndDate(int id, int year, int month, int day)
    {
        List<Visit>? visits = visitCollection.GetVisitsByMechanicAndDate(id, year, month, day);
        List<VisitData> visitData = DataConverter.ConvertToVisitDataList(visits);

        return Ok(visitData);
    }

    [HttpPost]
    [Route("/addVisit")]
    public ActionResult<VisitData> AddVisit(Visit visit)
    {
        Visit? addedVisit = visitCollection.AddVisit(visit);
        if (addedVisit == null)
            return UnprocessableEntity();
        VisitData visitData = DataConverter.ConvertToVisitData(addedVisit);

        return Created($"https://localhost:5003/getVisit/{visit.VisitID}", visitData);
    }

    [HttpPatch]
    [Route("/updateVisitStatus/{id:int}/{mechanicid:int}/{status}/{cost:int}")]
    public ActionResult<VisitData> UpdateVisitStatus(int id, int mechanicid, string status, int cost)
    {
        Visit? visit = visitCollection.UpdateVisitStatus(id, mechanicid, status, cost);
        if (visit == null)
            return NotFound();
        
        VisitData visitData = DataConverter.ConvertToVisitData(visit);

        return Ok(visitData);
    }

    [HttpGet]
    [Route("/runTests")]
    public string RunTests(string host, int port)
    {
        ITestsService tests = new Tests.Tests();

        return tests.RunTests(host, port);
    }
}
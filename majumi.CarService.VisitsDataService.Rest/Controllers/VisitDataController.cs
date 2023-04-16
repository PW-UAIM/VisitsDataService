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
    [Route("/visit/{id:int}")]
    public ActionResult<VisitData> GetVisitById(int id)
    {
        Visit? visit = visitCollection.GetVisitById(id);
        if (visit == null) 
            return NotFound();
            
        VisitData visitData = DataConverter.ConvertToVisitData(visit);
        return Ok(visitData);
    }

    [HttpGet]
    [Route("/visit/client/{id:int}")]
    public ActionResult<List<VisitData>> GetVisitByClient(int id)
    {
        List<Visit>? visits = visitCollection.GetVisitsByClient(id);
        List<VisitData> visitData = DataConverter.ConvertToVisitDataList(visits);

        return Ok(visitData);
    }

    [HttpGet]
    [Route("/visit/mechanic/{id:int}")]
    public ActionResult<List<VisitData>> GetVisitByMechanic(int id)
    {
        List<Visit>? visits = visitCollection.GetVisitsByMechanic(id);
        List<VisitData> visitData = DataConverter.ConvertToVisitDataList(visits);

        return Ok(visitData);
    }

    [HttpGet]
    [Route("/visit/all")]
    public ActionResult<List<VisitData>> GetAllVisits()
    {
        List<Visit> visits = visitCollection.GetAllVisits();
        List<VisitData> visitData = DataConverter.ConvertToVisitDataList(visits);

        return Ok(visitData);
    }

    [HttpGet]
    [Route("/visit/mechanic/{id:int}/date/{year:int}/{month:int}/{day:int}")]
    public ActionResult<List<VisitData>> GetVisitByMechanicAndDate(int id, int year, int month, int day)
    {
        List<Visit>? visits = visitCollection.GetVisitsByMechanicAndDate(id, year, month, day);
        List<VisitData> visitData = DataConverter.ConvertToVisitDataList(visits);

        return Ok(visitData);
    }

    [HttpPost]
    [Route("/visit/add")]
    public ActionResult AddVisit(Visit visit)
    {
        Visit? addedVisit = visitCollection.AddVisit(visit);
        if (addedVisit == null)
            return UnprocessableEntity();

        return Created($"https://localhost:5003/visit/get/{visit.VisitID}", addedVisit);
    }

    [HttpPatch]
    [Route("/visit/{id:int}/update/{status}")]
    public ActionResult<VisitData> UpdateVisitStatus(int id, string status)
    {
        Visit? visit = visitCollection.UpdateVisitStatus(id, status);
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
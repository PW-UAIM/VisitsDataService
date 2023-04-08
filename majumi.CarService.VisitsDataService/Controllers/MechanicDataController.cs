using Microsoft.AspNetCore.Mvc;

using majumi.CarService.VisitsDataService.Logic;
using majumi.CarService.VisitsDataService.Model;
using majumi.CarService.VisitsDataService.Model.Services;
using majumi.CarService.VisitsDataService.Rest.Model.Services;

namespace majumi.CarService.VisitsDataService.Rest.Controllers;

[ApiController]
[Route("[controller]")]
public class MechanicDataController : ControllerBase, IMechanicDataService, ITestsService
{
    private readonly ILogger<MechanicDataController> _logger;

    private readonly IMechanicCollection mechanicCollection;

    public MechanicDataController(ILogger<MechanicDataController> logger)
    {
        _logger = logger;
        mechanicCollection = new MechanicCollection();
    }

    [HttpGet]
    [Route("/mechanic/{id:int}")]
    public Mechanic GetMechanic(int id)
    {
        return mechanicCollection.GetById(id);
    }

    [HttpGet]
    [Route("/allMechanics")]
    public Mechanic[] GetAllMechanics()
    {
        return mechanicCollection.GetAllMechanics();
    }

    [HttpGet]
    [Route("/runTests")]
    public string RunTests(string host, int port)
    {
        ITestsService tests = new Tests.Tests();

        return tests.RunTests(host, port);
    }
}
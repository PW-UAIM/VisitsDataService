using majumi.CarService.VisitsDataService.Model;

namespace majumi.CarService.VisitsDataService.Rest.Model.Services;

public interface IVisitDataService
{
    public Visit GetVisitById(int id);
    public Visit[] GetVisitByClient(int id);
    public Visit[] GetVisitByMechanic(int mechanicID);
    public Visit[] GetVisitByMechanicAndDate(int mechanicID, int year, int month, int day);
    public Visit[] GetAllVisits();
    public Visit UpdateVisitStatus(int id, string status);
    public bool AddVisit(Visit visit);
    public string RunTests(string host, int port);  
}

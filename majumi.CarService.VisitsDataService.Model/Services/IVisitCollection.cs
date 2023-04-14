using majumi.CarService.VisitsDataService.Model;

namespace majumi.CarService.VisitsDataService.Model.Services;

public interface IVisitCollection
{
    public Visit GetVisitById(int searchedID);
    public Visit[] GetAllVisits();
    public Visit[] GetVisitsByClient(int id);
    public Visit[] GetVisitsByMechanic(int id);
    public Visit[] GetVisitsByMechanicAndDate(int id, int year, int month, int day);
    public Visit UpdateVisitStatus(int id, string status);
    public bool AddVisit(Visit visit);
}


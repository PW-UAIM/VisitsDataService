namespace majumi.CarService.VisitsDataService.Model.Services;

public interface IVisitCollection
{
    public Visit? GetVisitById(int visitID);
    public List<Visit> GetVisitsByClient(int clientID);
    public List<Visit> GetAllVisits();
    public List<Visit> GetVisitsByMechanic(int mechanicID);
    public List<Visit> GetVisitsByMechanicAndDate(int mechanicID, int year, int month, int day);
    public Visit? UpdateVisitStatus(int visitID, int mechanicID, string newStatus, int serviceCost);
    public Visit? AddVisit(Visit visitData);
}


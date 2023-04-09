using majumi.CarService.VisitsDataService.Model;

namespace majumi.CarService.VisitsDataService.Rest.Model.Services;

public interface IVisitDataService
{
    public Visit GetVisit(int visitID);

    public Visit[] GetAllVisits();
}

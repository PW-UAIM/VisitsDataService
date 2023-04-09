using majumi.CarService.VisitsDataService.Model;

namespace majumi.CarService.VisitsDataService.Model.Services;

public interface IVisitCollection
{
    public Visit? GetById(int searchedID);
    public Visit[] GetAllVisits();
}


using majumi.CarService.VisitsDataService.Model;

namespace majumi.CarService.VisitsDataService.Model.Services;

public interface IMechanicCollection
{
    public Mechanic? GetById(int searchedID);
    public Mechanic[] GetAllMechanics();
}


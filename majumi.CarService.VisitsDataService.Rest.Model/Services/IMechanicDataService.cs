using majumi.CarService.VisitsDataService.Model;

namespace majumi.CarService.VisitsDataService.Rest.Model.Services;

public interface IMechanicDataService
{
    public Mechanic GetMechanic(int mechanicID);

    public Mechanic[] GetAllMechanics();
}

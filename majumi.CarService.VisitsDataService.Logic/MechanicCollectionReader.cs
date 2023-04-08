using System.Text.Json;
using majumi.CarService.VisitsDataService.Model;

namespace majumi.CarService.VisitsDataService.Logic;

public class MechanicCollectionReader
{
    public static Mechanic[]? ReadFromJSON(string path)
    {
        return JsonSerializer.Deserialize<Mechanic[]>(File.ReadAllText(path));
    }
}

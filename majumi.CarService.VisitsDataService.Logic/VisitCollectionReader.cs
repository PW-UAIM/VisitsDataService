using System.Text.Json;
using majumi.CarService.VisitsDataService.Model;

namespace majumi.CarService.VisitsDataService.Logic;

public class VisitCollectionReader
{
    public static Visit[]? ReadFromJSON(string path)
    {
        return JsonSerializer.Deserialize<Visit[]>(File.ReadAllText(path));
    }
}

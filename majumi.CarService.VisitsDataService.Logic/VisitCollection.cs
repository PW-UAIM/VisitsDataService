using majumi.CarService.VisitsDataService.Model;
using majumi.CarService.VisitsDataService.Model.Services;

namespace majumi.CarService.VisitsDataService.Logic;

public class VisitCollection : IVisitCollection
{
    private static readonly List<Visit> Visits;

    private static readonly object VisitLock = new();
    static VisitCollection()
    {
        Visits = new List<Visit>(VisitCollectionReader.ReadFromJSON("Visits.json"));
    }

    public Visit? GetById(int searchedId)
    {
        lock (VisitLock)
        {
            return Visits.Find(visit => visit.VisitID == searchedId);
        }
    }

    public Visit[] GetAllVisits()
    {
        lock (VisitLock)
        {
            return Visits.ToArray();
        }
    }
}
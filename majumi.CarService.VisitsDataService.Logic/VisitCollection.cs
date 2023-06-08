using majumi.CarService.VisitsDataService.Model;
using majumi.CarService.VisitsDataService.Model.Services;
using majumi.CarService.VisitsDataService.Rest.Model.Converters;
using majumi.CarService.VisitsDataService.Rest.Model.Model;

namespace majumi.CarService.VisitsDataService.Logic;

public class VisitCollection  : IVisitCollection
{
    private static List<Visit> Visits;

    private static readonly object VisitLock = new();
    static VisitCollection()
    {
        Visits = new List<Visit>(VisitCollectionReader.ReadFromJSON("Visits.json"));
    }

    private Visit? FindByID(int visitID)
    {
        foreach (Visit visit in Visits)
        {
            if (visit.VisitID == visitID)
            {
                return visit;
            }
        }

        return null;
    }

    public Visit? GetVisitById(int visitID)
    {
        lock (VisitLock)
        {
            return this.FindByID(visitID);
        }
    }
        
    public List<Visit> GetVisitsByClient(int clientID)
    {
        lock (VisitLock)
        {
            List<Visit> visits = new();
            foreach(Visit v in Visits)
            {
                if (v.ClientID == clientID)
                {
                    visits.Add(v);
                }
            }
            return visits;
        }
    }

    public List<Visit> GetAllVisits()
    {
        lock (VisitLock)
        {
            return Visits;
        }
    }

    public List<Visit> GetVisitsByMechanic(int mechanicID)
    {
        lock (VisitLock)
        {
            List<Visit> visits = new();
            foreach (Visit v in Visits)
            {
                if (v.MechanicID == mechanicID)
                {
                    visits.Add(v);
                }
            }
            return visits;
        }
    }

    public List<Visit> GetVisitsByMechanicAndDate(int mechanicID, int year, int month, int day)
    {
        lock (VisitLock)
        {
            List<Visit> visits = new();
            foreach (Visit v in Visits)
            {
                if (v.MechanicID == mechanicID && v.ServiceDate == new DateTime(year, month, day))
                {
                    visits.Add(v);
                }
            }
            return visits;
        }
    }

    public Visit? UpdateVisitStatus(int visitID, int mechanicID, string newStatus, int serviceCost)
    {
        lock (VisitLock)
        {
            foreach (Visit visit in Visits)
            {
                if (visit.VisitID == visitID)
                {
                    visit.MechanicID = mechanicID;
                    visit.ServiceStatus = newStatus;
                    visit.ServiceCost = serviceCost;
                    return visit;
                }
            }
            return null;
        }
    }

    public Visit? AddVisit(Visit visit)
    {
        lock(VisitLock)
        {
            visit.VisitID = Visits.Count + 1;
            Visits.Add(visit);
            
            return visit;
        }
    }
}
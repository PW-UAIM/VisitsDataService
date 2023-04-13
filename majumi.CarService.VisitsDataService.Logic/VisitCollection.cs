﻿using majumi.CarService.VisitsDataService.Model;
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

    public Visit? GetVisitById(int searchedID)
    {
        lock (VisitLock)
        {
            return Visits.Find(visit => visit.VisitID == searchedID);
        }
    }

    public Visit[]? GetVisitsByClient(int clientID)
    {
        lock (VisitLock)
        {
            return Visits.Where(visit => visit.ClientID == clientID).ToArray();
        }
    }

    public Visit[] GetAllVisits()
    {
        lock (VisitLock)
        {
            return Visits.ToArray();
        }
    }

    public Visit[] GetVisitsByMechanic(int mechanicID)
    {
        lock (VisitLock)
        {
            return Visits.Where(visit => visit.MechanicID == mechanicID).ToArray();
        }
    }

    public Visit[] GetVisitsByMechanicAndDate(int mechanicID, int year, int month, int day)
    {
        lock (VisitLock)
        {
            return Visits.Where(visit => (visit.MechanicID == mechanicID && visit.ServiceDate == new DateTime(year,month,day))).ToArray();
        }
    }

    public Visit UpdateVisitStatus(int id, string status)
    {
        lock (VisitLock)
        {
            Visits.Find(visit => visit.VisitID == id).ServiceStatus = status;
            return Visits.Find(visit => visit.VisitID == id);
        }
    }
}
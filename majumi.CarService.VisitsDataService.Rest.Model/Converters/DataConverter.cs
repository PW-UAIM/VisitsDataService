using majumi.CarService.VisitsDataService.Model;
using majumi.CarService.VisitsDataService.Rest.Model.Model;
using System.ComponentModel;

namespace majumi.CarService.VisitsDataService.Rest.Model.Converters;

public static class DataConverter
{
    public static VisitData ConvertToVisitData(this Visit visit)
    {
        return new VisitData
        {
             VisitID = visit.VisitID,
             ClientID = visit.ClientID,
             ServiceType = visit.ServiceType,
             ServiceDate = visit.ServiceDate,
             ServiceCost = visit.ServiceCost,
             ServiceStatus = visit.ServiceStatus,
             Notes = visit.Notes,
             MechanicID = visit.MechanicID,
             CarID = visit.CarID
        };
    }

    public static List<VisitData> ConvertToVisitDataList(this List<Visit> visits)
    {
        List<VisitData> visitData = new();

        foreach (Visit v in visits)
        {
            visitData.Add(ConvertToVisitData(v));
        }

        return visitData;
    }
}
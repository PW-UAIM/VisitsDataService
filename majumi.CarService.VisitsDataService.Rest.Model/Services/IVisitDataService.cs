﻿using majumi.CarService.VisitsDataService.Model;
using majumi.CarService.VisitsDataService.Rest.Model.Model;
using Microsoft.AspNetCore.Mvc;

namespace majumi.CarService.VisitsDataService.Rest.Model.Services;

public interface IVisitDataService
{
    public ActionResult<VisitData> GetVisitById(int id);
    public ActionResult<List<VisitData>> GetVisitsByClient(int id);
    public ActionResult<List<VisitData>> GetVisitsByMechanic(int id);
    public ActionResult<List<VisitData>> GetAllVisits();
    public ActionResult<List<VisitData>> GetVisitByMechanicAndDate(int id, int year, int month, int day);
    public ActionResult<VisitData> AddVisit(Visit visit);
    public ActionResult<VisitData> UpdateVisitStatus(int id, int mechanicid, string status, int cost);
}

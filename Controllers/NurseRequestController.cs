using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SKNHPM.Data;
using SKNHPM.Models;


namespace SKNHPM.Controllers
{

    public class NurseRequestController : Controller
    {
        private readonly AppicationDbContext context;
        public NurseRequestController(AppicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var nurserequest = context.NurseRequests.OrderByDescending(p => p.JobId).ToList();
            return View(nurserequest);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(NurseRequestDto nurseerquestDto)
        {

            if (!ModelState.IsValid)
            {
                return View(nurseerquestDto);
            }

            // save the new product in the database
            NurseRequest nurseerquest = new NurseRequest()
            {
                QN = nurseerquestDto.QN,
                QNName = nurseerquestDto.QNName,
                StartPoint = nurseerquestDto.StartPoint,
                EndPoint = nurseerquestDto.EndPoint,
                MaterialType = nurseerquestDto.MaterialType,
                UrentType = nurseerquestDto.UrentType,
                Remark = nurseerquestDto.Remark,
                // CreatedAt = DateTime.Now,

            };

            context.NurseRequests.Add(nurseerquest);
            context.SaveChangesAsync();

            return RedirectToAction("Index", "NurseRequest");
        }
    }

}
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
        public IActionResult Index(string searchString)
        {
            Response.Headers.Add("Refresh","15");
            var nurserequest = context.NurseRequests.OrderByDescending(p => p.JobId).ToList();
            if(!String.IsNullOrEmpty(searchString))
            {
                nurserequest = nurserequest.Where(n => n.StartPoint.ToLower().Contains(searchString)).ToList();
            }
            
            return View(nurserequest);

        }
         public IActionResult Create()
         {
             return View();
         }

        [HttpPost]
        public IActionResult Create(NurseRequestDto nurseRequestDto)
        {
            if (ModelState.IsValid)
            {
                return View(nurseRequestDto);
            }
            
            NurseRequest nurseRequest = new NurseRequest()
            {
                QN = nurseRequestDto.QN,
                QNName = nurseRequestDto.QNName,
                StartPoint = nurseRequestDto.StartPoint,
                EndPoint1 = nurseRequestDto.EndPoint1,
                MaterialType = nurseRequestDto.MaterialType,
                UrgentType = nurseRequestDto.UrgentType,
                PatientType = nurseRequestDto.PatientType,
                Remark = nurseRequestDto.Remark,
                JobStatusName = "รอจ่ายงาน",
                DeptName = "",
                PoterFname = "",
                QNAge = "",
                QNSex = "",
            };
            context.NurseRequests.Add(nurseRequest);
            context.SaveChanges();
            return RedirectToAction("Index", "NurseRequest");
        }

        public IActionResult Edit(int id)
        {
            var nurseRequest = context.NurseRequests.Find(id);
            if(nurseRequest == null)
            {
                return RedirectToAction("Index", "NurseRequest");
            }
            var nurseRequestDto = new NurseRequestDto()
            {
                QN = nurseRequest.QN,
                QNName = nurseRequest.QNName,
                StartPoint = nurseRequest.StartPoint,
                EndPoint1 = nurseRequest.EndPoint1,
                MaterialType = nurseRequest.MaterialType,
                UrgentType = nurseRequest.UrgentType,
                PatientType = nurseRequest.PatientType,
                Remark = nurseRequest.Remark,
                JobStatusName = "",
                DeptName = "null",
                PoterFname = "",
                QNAge = "null",
                QNSex = "null",
            };

             ViewData["NurseRequestId"] = nurseRequest.JobId;

            return View(nurseRequestDto);
        }
        [HttpPost]
         public IActionResult Edit(int id, NurseRequestDto nurseRequestDto)
         {
            var nurseRequest = context.NurseRequests.Find(id);
            if(nurseRequest == null)
            {
                return RedirectToAction("Index", "NurseRequest");
            }
            if (ModelState.IsValid)
            {
                ViewData["NurseRequestId"] = nurseRequest.JobId;
                return View(nurseRequestDto);
            }

            nurseRequest.QN = nurseRequestDto.QN;
            nurseRequest.QNName = nurseRequestDto.QNName;
            nurseRequest.StartPoint = nurseRequestDto.StartPoint;
            nurseRequest.EndPoint1 = nurseRequestDto.EndPoint1;
            nurseRequest.MaterialType = nurseRequestDto.MaterialType;
            nurseRequest.UrgentType = nurseRequestDto.UrgentType;
            nurseRequest.PatientType = nurseRequestDto.PatientType;
            nurseRequest.Remark = nurseRequestDto.Remark;

            context.SaveChanges();

            return RedirectToAction("Index", "NurseRequest");
         }
         public IActionResult Delete(int id)
        {
            var nurseRequest = context.NurseRequests.Find(id);
            if(nurseRequest == null)
            {
                return RedirectToAction("Index", "NurseRequest");
            }
            context.NurseRequests.Remove(nurseRequest);
            context.SaveChanges(true);

            return RedirectToAction("Index", "NurseRequest");
        }

        public IActionResult EditStatus(int id)
        {
            var nurseRequest = context.NurseRequests.Find(id);
            if(nurseRequest == null)
            {
                return RedirectToAction("Index", "NurseRequest");
            }
            var nurseRequestDto = new NurseRequestDto()
            {
                
                QN = nurseRequest.QN,
                QNName = nurseRequest.QNName,
                StartPoint = nurseRequest.StartPoint,
                EndPoint1 = nurseRequest.EndPoint1,
                MaterialType = nurseRequest.MaterialType,
                UrgentType = nurseRequest.UrgentType,
                PatientType = nurseRequest.PatientType,
                Remark = nurseRequest.Remark,
                JobStatusName = "",
                DeptName = "null",
                PoterFname = "",
                QNAge = "null",
                QNSex = "null",
            };

             ViewData["NurseRequestId"] = nurseRequest.JobId;

            return View(nurseRequestDto);
        }

        [HttpPost]
        public IActionResult EditStatus(int id, NurseRequestDto nurseRequestDto)
         {
            var nurseRequest = context.NurseRequests.Find(id);
            if(nurseRequest == null)
            {
                return RedirectToAction("Index", "NurseRequest");
            }
            if (ModelState.IsValid)
            {
                ViewData["NurseRequestId"] = nurseRequest.JobId;
                return View(nurseRequestDto);
            }

            nurseRequest.JobStatusName="สิ้นสุดการทำงาน";
            context.SaveChanges();
            
            return RedirectToAction("Index", "NurseRequest");
         }

         [HttpPost]
        public IActionResult Cancel(int id, NurseRequestDto nurseRequestDto)
         {
            var nurseRequest = context.NurseRequests.Find(id);
            if(nurseRequest == null)
            {
                return RedirectToAction("Index", "NurseRequest");
            }
            if (ModelState.IsValid)
            {
                ViewData["NurseRequestId"] = nurseRequest.JobId;
                return View(nurseRequestDto);
            }

            nurseRequest.JobStatusName="ยกเลิกบริการ";
            context.SaveChanges();
            
            return RedirectToAction("Index", "NurseRequest");
         }
    }

}
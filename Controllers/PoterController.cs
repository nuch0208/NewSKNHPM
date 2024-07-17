using Microsoft.AspNetCore.Mvc;
using SKNHPM.Data;
using SKNHPM.Models;

namespace SKNHPM.Controllers
{
    public class PoterController : Controller
    {
        private readonly AppicationDbContext context;
        public PoterController(AppicationDbContext context)
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
                EndPoint1 = nurseRequestDto.EndPoint,
                MaterialType = nurseRequestDto.MaterialType,
                UrgentType = nurseRequestDto.UrentType,
                PatientType = nurseRequestDto.PatientType,
                Remark = nurseRequestDto.Remark,
                DeptName = "null",
                PoterFname = "null",
                QNAge = "null",
                QNSex = "null",
            };
            context.NurseRequests.Add(nurseRequest);
            context.SaveChanges();
            return RedirectToAction("Index", "Poter");
        }

        public IActionResult Edit(int id)
        {
            var nurseRequest = context.NurseRequests.Find(id);
            if(nurseRequest == null)
            {
                return RedirectToAction("Index", "Poter");
            }
            var nurseRequestDto = new NurseRequestDto()
            {
                JobId = nurseRequest.JobId,
                QN = nurseRequest.QN,
                QNName = nurseRequest.QNName,
                StartPoint = nurseRequest.StartPoint,
                EndPoint = nurseRequest.EndPoint1,
                MaterialType = nurseRequest.MaterialType,
                UrentType = nurseRequest.UrgentType,
                PatientType = nurseRequest.PatientType,
                Remark = nurseRequest.Remark,
                Department = "null",
                PoterFname = "null",
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
                return RedirectToAction("Index", "Poter");
            }
            if (ModelState.IsValid)
            {
                ViewData["NurseRequestId"] = nurseRequest.JobId;
                return View(nurseRequestDto);
            }

            // nurseRequest.QN = nurseRequestDto.QN;
            // nurseRequest.QNName = nurseRequestDto.QNName;
            // nurseRequest.StartPoint = nurseRequestDto.StartPoint;
            // nurseRequest.EndPoint1 = nurseRequestDto.EndPoint;
            // nurseRequest.MaterialType = nurseRequestDto.MaterialType;
            // nurseRequest.UrgentType = nurseRequestDto.UrentType;
            // nurseRequest.PatientType = nurseRequestDto.PatientType;
            nurseRequest.Remark = nurseRequestDto.Remark;
            nurseRequest.PoterFname=nurseRequestDto.PoterFname;
            nurseRequest.JobStatusName=nurseRequestDto.JobStatusName;

            context.SaveChanges();

            return RedirectToAction("Index", "Poter");
         }
         
         public IActionResult Delete(int id)
        {
            var nurseRequest = context.NurseRequests.Find(id);
            if(nurseRequest == null)
            {
                return RedirectToAction("Index", "Poter");
            }
            context.NurseRequests.Remove(nurseRequest);
            context.SaveChanges(true);

            return RedirectToAction("Index", "Poter");
        }
        
        public IActionResult EditStatus(int id)
        {
            var nurseRequest = context.NurseRequests.Find(id);
            if(nurseRequest == null)
            {
                return RedirectToAction("Index", "Poter");
            }
            var nurseRequestDto = new NurseRequestDto()
            {
                JobId = nurseRequest.JobId,
                QN = nurseRequest.QN,
                QNName = nurseRequest.QNName,
                StartPoint = nurseRequest.StartPoint,
                EndPoint = nurseRequest.EndPoint1,
                MaterialType = nurseRequest.MaterialType,
                UrentType = nurseRequest.UrgentType,
                PatientType = nurseRequest.PatientType,
                Remark = nurseRequest.Remark,
                JobStatusName = nurseRequest.JobStatusName,
                Department = "null",
                PoterFname = "null",
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
                return RedirectToAction("Index", "Poter");
            }
            if (ModelState.IsValid)
            {
                ViewData["NurseRequestId"] = nurseRequest.JobId;
                return View(nurseRequestDto);
            }

            nurseRequest.JobStatusName="สิ้นสุดการทำงาน";
            context.SaveChanges();
            
            return RedirectToAction("Index", "Poter");
         }
    }

}

using System.Data;
using ClosedXML.Excel;
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

        public IActionResult Index(string searchString)
        {
            Response.Headers.Add("Refresh","15");
            var nurserequest = context.NurseRequests.OrderByDescending(p => p.JobId).ToList();
             if(!String.IsNullOrEmpty(searchString))
            {
                nurserequest = nurserequest.Where(n => n.JobStatusName.Contains(searchString)).ToList();
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
                JobStatusName = "null",
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
                
                QN = nurseRequest.QN,
                QNName = nurseRequest.QNName,
                StartPoint = nurseRequest.StartPoint,
                EndPoint1 = nurseRequest.EndPoint1,
                MaterialType = nurseRequest.MaterialType,
                UrgentType = nurseRequest.UrgentType,
                PatientType = nurseRequest.PatientType,
                Remark = nurseRequest.Remark,
                DeptName = "null",
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
                
                QN = nurseRequest.QN,
                QNName = nurseRequest.QNName,
                StartPoint = nurseRequest.StartPoint,
                EndPoint1 = nurseRequest.EndPoint1,
                MaterialType = nurseRequest.MaterialType,
                UrgentType = nurseRequest.UrgentType,
                PatientType = nurseRequest.PatientType,
                Remark = nurseRequest.Remark,
                JobStatusName = "null",
                DeptName = "null",
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

        [HttpPost]
        public IActionResult Cancel(int id, NurseRequestDto nurseRequestDto)
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

            nurseRequest.JobStatusName="ยกเลิกบริการ";
            context.SaveChanges();
            
            return RedirectToAction("Index", "Poter");
         }

         [HttpGet]
        public async Task<FileResult> ExportProductInExcel()
        {
            var nurseRequest = context.NurseRequests.ToList();
            var fileName = "Daily Report.xlsx";
            return GenerateExcel(fileName, nurseRequest);
        }

        private FileResult GenerateExcel(string fileName, IEnumerable<NurseRequest> nurseRequest)
        {
            DataTable dataTable = new DataTable("Daily Report");
            dataTable.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("JobId"),
                new DataColumn("Create Date"),
                new DataColumn("Qn"),
                new DataColumn("Start Point"),
                new DataColumn("End Point"),
                new DataColumn("MaterialType"),
                new DataColumn("PoterFname"),
                new DataColumn("JobStatusName"),
                new DataColumn("Remark"),
                
            });

            foreach (var i in nurseRequest)
            {
                dataTable.Rows.Add(i.JobId, i.CreateDate, i.QN, i.StartPoint , i.EndPoint1, i.MaterialType, i.PoterFname ,i.JobStatusName, i.Remark);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dataTable);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);

                    return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        fileName);
                }
            }
        }

        public IActionResult Report(int pg=1)
        {
            var nurserequest = context.NurseRequests.OrderByDescending(p => p.JobId).ToList();
            const int pageSize = 12;
            if (pg < 1)
                pg = 1;
            var recsCount = nurserequest.Count();
            var pager = new Pager(recsCount, pg, pageSize);
            int recSkip = (pg - 1) * pageSize;
            var data = nurserequest.Skip(recSkip).Take(pager.PageSize).ToList();
            this.ViewBag.Pager = pager;
            //return View(nurserequest);
            return View(data);
        }

    }
}

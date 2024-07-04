using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SKNHPM.Models;
using Microsoft.EntityFrameworkCore;
using SKNHPM.Data;

namespace SKNHPM.Controllers
{
    [Route("api/[controller]")]
     [ApiController]
    public class NurseRequestController : Controller
    {
        private readonly AppDbContext _context;
        public NurseRequestController(AppDbContext context)
        {
            _context = context;
        }
        // Uri baseAddress = new Uri("https://localhost:44329/api");

        // private readonly HttpClient _client;
        // public NurseRequestController()
        // {
        //     _client = new HttpClient();
        //     _client.BaseAddress = baseAddress;
        // }
        // [HttpGet]
        // public IActionResult Index()
        // {
        //     List<NurseRequest> NurseRequests =  new List<NurseRequest>();
        //     HttpResponseMessage respone = _client.GetAsync(_client.BaseAddress + "/NurseRequest/Get").Result;
        //     if (respone.IsSuccessStatusCode)
        //     {
        //         string data = respone.Content.ReadAsStringAsync().Result;
        //         NurseRequests = JsonConvert.DeserializeObject<List<NurseRequest>>(data); 
        //     }
        //     return View(NurseRequests);
        // }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var Jobs = await _context.NurseRequests.ToListAsync();
            
            return Ok(Jobs);
        }
    }
}
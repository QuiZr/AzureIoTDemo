using AzureIoTDemo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AzureIoTDemo.Controllers
{
    public class TempController : Controller
    {
        private TemperatureContext _context;
        public TempController(TemperatureContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var tempReads = await _context.TemperatureReads.ToListAsync();
            return View(tempReads);
        }
    }
}

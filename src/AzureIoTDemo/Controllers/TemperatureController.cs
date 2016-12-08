using AzureIoTDemo.Data;
using AzureIoTDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AzureIoTDemo.Controllers
{
    [Route("api/[controller]")]
    public class TemperatureController : Controller
    {
        private TemperatureContext _context;
        public TemperatureController(TemperatureContext context)
        {
            _context = context;
        }
    }
}

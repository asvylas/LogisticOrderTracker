using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LogisticOrderTracker.Models;

namespace LogisticOrderTracker.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GeneralController : ControllerBase
  {
    private readonly LogisticOrderTrackerContext _context;

    public GeneralController(LogisticOrderTrackerContext context)
    {
      _context = context;
    }

    // GET: api/General/Incoterms
    [HttpGet("Incoterms")]
    public IEnumerable<KeyValuePair<string, int>> GetIncoterms()
    {
      var incoterms = Enum.GetValues(typeof(Incoterms)).Cast<Incoterms>().ToDictionary(k => k.ToString(), v => (int)v);
      return incoterms.ToList();
    }

    // GET: api/General/TransportTypes
    [HttpGet("transporttypes")]
    public IEnumerable<KeyValuePair<string, int>> GetTransportTypes()
    {
      var types = Enum.GetValues(typeof(TransportType)).Cast<TransportType>().ToDictionary(k => k.ToString(), v => (int)v);
      return types.ToList();
    }

    // GET: api/General/PackageTypes
    [HttpGet("packagetypes")]
    public IEnumerable<KeyValuePair<string, int>> GetPackageTypes()
    {
      var types = Enum.GetValues(typeof(PackageType)).Cast<PackageType>().ToDictionary(k => k.ToString(), v => (int)v);
      return types.ToList();
    }

  }
}
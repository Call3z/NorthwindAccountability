using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthwindAccountability.Data;
using NorthwindAccountability.Data.Models;
using NorthwindAccountability.Models;

namespace NorthwindAccountability.Controllers
{
    public class HomeController : Controller
    {
        private NorthwindPremiumDb _context;

        public HomeController(NorthwindPremiumDb context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var party = new Party();
            var partyInformation = new PartyInformation();
            partyInformation.FirstName = "Marcus";
            partyInformation.LastName = "Skrotis";
            party.PartyInformation = partyInformation;

            var party2 = new Party();
            var partyInformation2 = new PartyInformation();
            partyInformation2.FirstName = "Tony";
            partyInformation2.LastName = "Lindhagen";
            partyInformation2.CompanyName = "Starcounter";
            party2.PartyInformation = partyInformation2;

            var employee = new AccountabilityType();
            employee.Name = "Employee";

            var accountability = new Accountability();
            accountability.Commissioner = party2;
            accountability.AccountabilityType = employee;
            accountability.Responsible = party;



            _context.Parties.Add(party);
            _context.Accountabilities.Add(accountability);
            _context.AccountabilityTypes.Add(employee);

            _context.SaveChanges();

            var test = _context.Parties.ToList();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

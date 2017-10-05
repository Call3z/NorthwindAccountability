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

            var party3 = new Party();
            var partyInformation3 = new PartyInformation();
            partyInformation3.CompanyName = "Shipman";
            partyInformation3.FirstName = "Johan";
            party3.PartyInformation = partyInformation3;

            var supplier = new AccountabilityType();
            supplier.Name = "Supplier";

            var shipper = new AccountabilityType();
            shipper.Name = "Shipper";

            var accountability = new Accountability();
            accountability.Commissioner = party;
            accountability.AccountabilityType = supplier;
            accountability.Responsible = party2;

            var accountability2 = new Accountability();
            accountability2.Commissioner = party2;
            accountability2.Responsible = party3;
            accountability2.AccountabilityType = shipper;



            var category = new Category();
            category.Description = "Fiskespön";
            category.Name = "Fiskespö";

            var product = new Product();
            product.Party = party2;
            product.Category = category;
            product.Name = "Superfiskespö";

            var order = new Order();
            order.OrderDate = DateTime.Now;
            order.RequiredDate = DateTime.Now;
            order.ShippedDate = DateTime.Now;
            order.ShipperAccountability = accountability2;
            order.SupplierAccountability = accountability;

            var orderDetail = new OrderDetail();
            orderDetail.Product = product;
            orderDetail.Order = order;


            _context.Parties.Add(party);
            _context.Parties.Add(party2);
            _context.Parties.Add(party3);
            _context.Accountabilities.Add(accountability);
            _context.Accountabilities.Add(accountability2);
            _context.AccountabilityTypes.Add(supplier);
            _context.AccountabilityTypes.Add(shipper);
            _context.Orders.Add(order);
            _context.OrderDetails.Add(orderDetail);
            _context.SaveChanges();

            var test = _context.Orders.ToList();

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

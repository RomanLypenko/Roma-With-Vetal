using Auction___.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Auction___.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext db;
        public HomeController(ApplicationContext context)
        {
            db = context;            
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
        public IActionResult Regist(UsersModel USer) 
        {
            db.usersModels.Add(USer);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        public IActionResult EnterUser()
        {
            return View();
        }
        public  IActionResult EnterPass(UsersModel USer)
        {
            
            var ent = db.usersModels.Include(i=>i.MyLots).SingleOrDefault(i => i.UserName == USer.UserName && i.UserPassword == USer.UserPassword);
            if (ent!=null)
            {
                ent.isReg = true;
                db.Update(ent);
                db.SaveChanges();
                return RedirectToAction("IsEnter");
            }
            return NotFound();

        }

        public IActionResult IsEnter()
        {
            ViewData["Some"] = db.usersModels.SingleOrDefault(i=>i.isReg==true).Balance;
            return View(db.usersLots.Include(i=>i.User).ToList());
        }
        public IActionResult Create()
        {

            return View();
            
        }
        public IActionResult CreateLot(AllLots lot)
        {
            var ent = db.usersModels.SingleOrDefault(i =>i.isReg==true);
            lot.User = ent;
            lot.Finalprice = lot.InitialPrice;

            db.usersLots.Add(lot);
            db.SaveChanges();
            return RedirectToAction("IsEnter");

        }
        public IActionResult Exit()
        {
            var ent = db.usersModels.SingleOrDefault(i => i.isReg == true);
            ent.isReg = false;
            db.Update(ent);
            db.SaveChanges();


            return RedirectToAction("Index");

        }
        public IActionResult Details(int Id, string Name)
        {
            var ent=db.usersLots.Include(i=>i.User).SingleOrDefault(i => i.Id == Id);
            return View(ent);

        }


        public IActionResult Edit(int Id)
        {
            return View(db.usersLots.Include(i=>i.User).SingleOrDefault(i=>i.Id==Id));
        }
        [HttpPost]
        public IActionResult Edit(AllLots lot)
        {
            lot.User = db.usersModels.SingleOrDefault(i => i.isReg);
            lot.Finalprice = lot.InitialPrice;
            db.Update(lot);
            db.SaveChanges();

            return RedirectToAction("IsEnter");
        }

        public IActionResult Delete(int Id)
        {
            db.usersLots.Remove(db.usersLots.SingleOrDefault(i => i.Id == Id));
            db.SaveChanges();
            return RedirectToAction("IsEnter");

        }
        public IActionResult MyLots()
        {

            return View(db.usersModels.Include(i=>i.MyLots).SingleOrDefault(i => i.isReg == true));

        }
        public IActionResult History()
        {
            return View();
        }

        
        public IActionResult AddBalance()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddBalance(int Balance)
        {
            var ent = db.usersModels.SingleOrDefault(i => i.isReg == true);
            ent.Balance += Balance;
            db.Update(ent);
            db.SaveChanges();
            return RedirectToAction("IsEnter");
        }
        public IActionResult Bid_on(int Id)
        {
            var ent = db.usersLots.Include(i=>i.User).SingleOrDefault(i => i.Id == Id);
            ViewData["sum"] = db.usersModels.SingleOrDefault(i => i.isReg).Balance;
            return View(ent);
        }
        [HttpPost]
        public IActionResult Bid_on(int Finalprice , int Id)
        {
            var ent = db.usersLots.Include(i => i.User).SingleOrDefault(i => i.Id == Id);
            var User = db.usersModels.SingleOrDefault(i => i.isReg == true);

            if (User.Balance > Finalprice)
            {
                User.Balance -= Finalprice;
                db.Update(User);                
                ent.Finalprice = Finalprice;
                db.Update(ent);
                db.SaveChanges();
                return RedirectToAction("IsEnter");
            }
            else
            {
                return RedirectToAction("Bid_on");
            }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebService.Models;

namespace WebService.Controllers
{
    public class ServiceController : Controller
    {
        AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            return View(db.Services.ToList());
        }

        public ActionResult Edit(int id)
        {
            return View(db.Services.ToList().FirstOrDefault(x => x.Id == id));
        }

        public ActionResult Delete(int id)
        {
            //List<Service> services = db.Services.ToList();
            Service service = db.Services.FirstOrDefault(x => x.Id == id);
            Person person = db.Persons.FirstOrDefault(x => x.Id == service.PersonId);
            int servicesOfCurrentPersonCount = db.Services.Count(x => x.PersonId == person.Id);

            if (service != null)
                db.Services.Remove(db.Services.Remove(service));

            if (servicesOfCurrentPersonCount == 1 && person != null)
                db.Persons.Remove(person);



            db.SaveChanges();
            return View("Index", db.Services.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Service service)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View("Edit", service);
            //}
            Service updateService = db.Services.ToList().FirstOrDefault(x => x.Id == service.Id);
            if (updateService != null)
            {
                updateService.ServiceName = service.ServiceName;
                updateService.ServiceType = service.ServiceType;

                updateService.Person.PersonName = service.Person.PersonName;
                updateService.Person.PhoneNumber = service.Person.PhoneNumber;
            }
            else
            {
                db.Services.Add(new Service()
                {
                    ServiceName = service.ServiceName,
                    ServiceType = service.ServiceType,
                    Person = new Person() { PersonName = service.Person.PersonName, PhoneNumber = service.Person.PhoneNumber }
                });
            }




            //db.Services.Add(new Service()
            //{

            //});
            db.SaveChanges();
            return RedirectToAction("Index", "Service", new { Id = service.Id });  //make changes later
        }
    }
}
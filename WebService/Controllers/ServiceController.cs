using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
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

        //public ActionResult Edit(int id)
        //{
        //    return View(db.Services.ToList().FirstOrDefault(x => x.Id == id));
        //}

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


        public ActionResult EditService(int id)
        {
            return PartialView("_EditServicePartial",
                db.Services.ToList().FirstOrDefault(x => x.Id == id) ?? new Service() {ServiceName = string.Empty});
        }


        [HttpPost]   
        [ValidateAntiForgeryToken]
        public string Save(Service service)
        {                  //todo error message and emptystring validation
            Service newService = null;

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
                newService = new Service()
                {
                    ServiceName = service.ServiceName,
                    ServiceType = service.ServiceType,
                    Person =
                        new Person() {PersonName = service.Person.PersonName, PhoneNumber = service.Person.PhoneNumber}
                };
                db.Services.Add(newService);
            } 

            db.SaveChanges();  
            return JsonConvert.SerializeObject(newService ?? service);
        }
    }
}
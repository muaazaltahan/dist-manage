using dist_manage.Models;
using dist_manage.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;

namespace dist_manage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly IDataHelper<CardsDB> dataHelper;

        public CardsController(
            IDataHelper<CardsDB> dataHelper)
        {
            this.dataHelper = dataHelper;
        }
        //GET : CardsController
        [HttpGet]
        public IActionResult Index()
        {
            var data = dataHelper.GetAllData();
            return Ok(data);
        }

        // GET: CardsController/Add
        [HttpGet]
        public ActionResult Add()
        {
            return Ok();
        }

        // POST: CardsController/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(CardsDB collection)
        {
            try
            {
                var result = dataHelper.Add(collection);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return Ok();
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: CardsController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return Ok(dataHelper.Find(id));
        }

        // POST: CardsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CardsDB collection)
        {
            try
            {
                var result = dataHelper.Edit(id, collection);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return Ok();
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: CardsController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return Ok(dataHelper.Find(id));
        }

        // POST: CardsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CardsDB collection)
        {
            try
            {
                var result = dataHelper.Delete(id);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));

                }
                else
                {
                    return Ok();
                }
            }
            catch
            {
                return NotFound();
            }
        }

        // GET: CardsController/Import
        [HttpGet]
        public ActionResult Import()
        {
            return Ok();
        }

        // POST: CardsController/Import
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Import(List<CardsDB> collection)
        {
            try
            {
                foreach (var item in collection)
                {
                    dataHelper.Add(item);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}

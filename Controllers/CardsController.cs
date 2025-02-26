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
        [Authorize("User"), HttpGet]
        public IActionResult Index()
        {
            var data = dataHelper.GetAllData();
            return Ok(data);
        }

        // POST: CardsController/Add
        [Authorize(Policy = "AdminOnly"), HttpPost("Add")]
        //[ValidateAntiForgeryToken]
        public ActionResult Add(Cards collection)
        {
            try
            {
                var result = dataHelper.Add(collection);
                if (result == 1)
                {
                    var id = dataHelper.GetAllData().Select(x => x.Id).Last();
                    return Ok(id);

                }
                else
                {
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        // GET: CardsController/5
        [HttpGet("{id}")]
        public ActionResult Find(int id)
        {
            try
            {
                return Ok(dataHelper.Find(id));
            }
            catch { return BadRequest("card not found"); }
        }
        // POST: CardsController/Edit/5
        [Authorize(Policy = "AdminOnly"), HttpPut("Edit/{id}")]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Cards collection)
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Delete: CardsController/Delete/5
        [Authorize(Policy = "AdminOnly"), HttpDelete("Delete/{id}")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Cards collection)
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: CardsController/Import
        [Authorize(Policy = "AdminOnly"), HttpPost("Import")]
        //[ValidateAntiForgeryToken]
        public ActionResult Import(List<Cards> collection)
        {
            try
            {
                foreach (var item in collection)
                {
                    dataHelper.Add(item);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

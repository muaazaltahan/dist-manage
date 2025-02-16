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
    public class SectionsController : ControllerBase
    {
        private readonly IDataHelper<SectionsDB> dataHelper;

        public SectionsController(
            IDataHelper<SectionsDB> dataHelper)
        {
            this.dataHelper = dataHelper;
        }
        //GET : SectionsController
        [HttpGet]
        public IActionResult Index()
        {
            var data = dataHelper.GetAllData();
            return Ok(data);
        }

        // GET: SectionsController/Add/5
        [HttpGet("Add")]
        public ActionResult Add()
        {
            return Ok();
        }

        // POST: SectionsController/Add/5
        [HttpPost("Add")]
        [ValidateAntiForgeryToken]
        public ActionResult Add(SectionsDB collection)
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

        // GET: SectionsController/Edit/5
        [HttpGet("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            return Ok(dataHelper.Find(id));
        }

        // POST: SectionsController/Edit/5
        [HttpPut("Edit/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SectionsDB collection)
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

        // GET: SectionsController/Delete/5
        [HttpGet("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(dataHelper.Find(id));
        }

        // POST: SectionsController/Edit/5
        [HttpDelete("Delete/{id}")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SectionsDB collection)
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
    }
}

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
    public class ProgramsController : ControllerBase
    {
        private readonly IDataHelper<ProgramsDB> dataHelper;

        public ProgramsController(
            IDataHelper<ProgramsDB> dataHelper)
        {
            this.dataHelper = dataHelper;
        }
        //GET : ProgramsController
        [HttpGet]
        public IActionResult Index()
        {
            var data = dataHelper.GetAllData();
            return Ok(data);
        }

        // GET: ProgramsController/Add/5
        [HttpGet("Add")]
        public ActionResult Add()
        {
            return Ok();
        }

        // POST: ProgramsController/Add/5
        [HttpPost("Add")]
        //[ValidateAntiForgeryToken]
        public ActionResult Add(ProgramsDB collection)
        {
            try
            {
                var result = dataHelper.Add(collection);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: ProgramsController/Edit/5
        [HttpGet("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            return Ok(dataHelper.Find(id));
        }

        // POST: ProgramsController/Edit/5
        [HttpPut("Edit/{id}")]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProgramsDB collection)
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

        // GET: ProgramsController/Delete/5
        [HttpGet("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(dataHelper.Find(id));
        }

        // POST: ProgramsController/Delete/5
        [HttpDelete("Delete/{id}")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProgramsDB collection)
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
    }
}

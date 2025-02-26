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
    public class SectionUsersController : ControllerBase
    {
        private readonly IDataHelper<SectionUsersDB> dataHelper;

        public SectionUsersController(
            IDataHelper<SectionUsersDB> dataHelper)
        {
            this.dataHelper = dataHelper;
        }
        //GET : SectionUsersController
        [HttpGet]
        public IActionResult Index()
        {
            var data = dataHelper.GetAllData();
            return Ok(data);
        }

        // GET: SectionUsersController/Add
        [HttpGet("Add")]
        public ActionResult Add()
        {
            return Ok();
        }

        // POST: SectionUsersController/Add
        [HttpPost("Add")]
        //[ValidateAntiForgeryToken]
        public ActionResult Add(List<SectionUsers> collection)
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

        // GET: SectionUsersController/Edit/5
        [HttpGet("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            return Ok(dataHelper.Find(id));
        }

        // POST: SectionUsersController/Edit/5
        [HttpPut("Edit/{id}")]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SectionUsers collection)
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

        // GET: SectionUsersController/Delete/5
        [HttpGet("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(dataHelper.Find(id));
        }

        // POST: SectionUsersController/Edit/5
        [HttpDelete("Delete/{id}")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SectionUsers collection)
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

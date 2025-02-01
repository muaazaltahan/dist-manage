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
    public class LogsController : ControllerBase
    {
        private readonly IDataHelper<LogsDB> dataHelper;

        public LogsController(
            IDataHelper<LogsDB> dataHelper)
        {
            this.dataHelper = dataHelper;
        }
        //GET : LogsController
        [HttpGet]
        public IActionResult Index()
        {
            var data = dataHelper.GetAllData();
            return Ok(data);
        }

        // GET: LogsController/Add/5
        [HttpGet]
        public ActionResult Add()
        {
            return Ok();
        }

        // POST: LogsController/Add/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(LogsDB collection)
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

        // GET: LogsController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return Ok(dataHelper.Find(id));
        }

        // POST: LogsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, LogsDB collection)
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

        // GET: LogsController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return Ok(dataHelper.Find(id));
        }

        // POST: LogsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, LogsDB collection)
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

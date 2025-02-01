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
    public class Link_Prog_UserController : ControllerBase
    {
        private readonly IDataHelper<Link_Prog_UserDB> dataHelper;

        public Link_Prog_UserController(
            IDataHelper<Link_Prog_UserDB> dataHelper)
        {
            this.dataHelper = dataHelper;
        }
        //GET : Link_Prog_UserController
        [HttpGet]
        public IActionResult Index()
        {
            var data = dataHelper.GetAllData();
            return Ok(data);
        }

        // GET: Link_Prog_UserController/Add/5
        [HttpGet]
        public ActionResult Add()
        {
            return Ok();
        }

        // POST: Link_Prog_UserController/Add/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Link_Prog_UserDB collection)
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

        // GET: Link_Prog_UserController/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return Ok(dataHelper.Find(id));
        }

        // POST: Link_Prog_UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Link_Prog_UserDB collection)
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

        // GET: Link_Prog_UserController/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            return Ok(dataHelper.Find(id));
        }

        // POST: Link_Prog_UserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Link_Prog_UserDB collection)
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

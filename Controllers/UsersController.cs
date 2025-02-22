﻿using dist_manage.Models;
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
    public class UsersController : ControllerBase
    {
        private readonly IDataHelper<UsersDB> dataHelper;

        public UsersController(
            IDataHelper<UsersDB> dataHelper)
        {
            this.dataHelper = dataHelper;
        }
        //GET : UsersController
        [HttpGet]
        public IActionResult Index()
        {
            var data = dataHelper.GetAllData();
            return Ok(data);
        }

        // GET: UsersController/Add/5
        [HttpGet("Add")]
        public ActionResult Add()
        {
            return Ok();
        }

        // POST: UsersController/Add/5
        [HttpPost("Add")]
        //[ValidateAntiForgeryToken]
        public ActionResult Add(UsersDB collection)
        {
            try
            {
                var result = dataHelper.Add(collection);
<<<<<<< HEAD
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
=======
                return Ok(result);
            }
            catch(Exception ex)
>>>>>>> 6d5a826b5e00fd4eb2bc309dabdc50ce1798b176
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: UsersController/Edit/5
        [HttpGet("Edit/{id}")]
        public ActionResult Edit(int id)
        {
            return Ok(dataHelper.Find(id));
        }

        // POST: UsersController/Edit/5
        [HttpPut("Edit/{id}")]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UsersDB collection)
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

        // GET: UsersController/Delete/5
        [HttpGet("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            return Ok(dataHelper.Find(id));
        }

        // POST: UsersController/Delete/5
        [HttpDelete("Delete/{id}")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UsersDB collection)
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

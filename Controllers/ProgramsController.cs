using dist_manage.Models;
using dist_manage.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using dist_manage.Models.SqlServerEF;

namespace dist_manage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramsController : ControllerBase
    {
        private readonly IDataHelper<ProgramsDB> dataHelper;
        private readonly IDataHelper<Link_Prog_CardDB> linkDataHelper;
        public ProgramsController(
            IDataHelper<ProgramsDB> dataHelper,
            IDataHelper<Link_Prog_CardDB> linkDataHelper)
        {
            this.dataHelper = dataHelper;
            this.linkDataHelper = linkDataHelper;
        }

        [Authorize]
        [HttpGet("program-cards/{programId}")]
        public ActionResult<IEnumerable<CardsDB>> GetProgramCards([FromRoute] int programId)
        {
            try
            {
                return Ok(linkDataHelper.GetAllData().Where(l => l.ProgramsId == programId).Select(l => l.CardsId).ToList());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("program-card-link/{programId}/{cardId}")]
        public ActionResult<Link_Prog_Card> GetProgramCardLink([FromRoute] int programId, [FromRoute] string cardId)
        {
            try
            {
                var link = linkDataHelper.GetAllData().FirstOrDefault(l => l.CardsId == cardId && l.ProgramsId == programId);
                if (link == null) return BadRequest("no link to this card");
                return Ok(link);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //GET : ProgramsController
        [Authorize, HttpGet]
        public IActionResult Index()
        {
            var data = dataHelper.GetAllData();
            return Ok(data);
        }

        [Authorize, HttpGet("{id}")]
        public IActionResult Find(int id)
        {
            var data = dataHelper.Find(id);
            return Ok(data);
        }

        // POST: ProgramsController/Add/5
        [Authorize(Policy = "AdminOnly")]
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

        // POST: ProgramsController/Edit/5
        [Authorize(Policy = "AdminOnly")]
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: ProgramsController/Delete/5
        [Authorize(Policy = "AdminOnly")]
        [HttpDelete("Delete/{id}")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = dataHelper.Delete(id);
                if (result == 1)
                {
                    return Ok(true);

                }
                else
                {
                    return Ok(false);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

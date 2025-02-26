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
        private DBContext db;

        public ProgramsController(
            IDataHelper<ProgramsDB> dataHelper, DBContext _db)
        {
            this.dataHelper = dataHelper;
            this.db = _db;
        }

        [HttpGet("program-cards/{programId}")]
        public ActionResult<IEnumerable<CardsDB>> GetProgramCards([FromRoute] int programId)
        {
            try
            {
                return Ok(db.Link_Prog_CardDB.Where(l => l.ProgramsId == programId).Select(l => l.Cards).ToList());
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("program-card-link/{programId}/{cardId}")]
        public ActionResult<Link_Prog_Card> GetProgramCardLink([FromRoute] int programId, [FromRoute] int cardId)
        {
            try
            {
                var link = db.Link_Prog_CardDB.FirstOrDefault(l => l.CardsId == cardId && l.ProgramsId == programId);
                if (link == null) return BadRequest("no link to this card");
                return Ok(link);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: ProgramsController/Delete/5
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

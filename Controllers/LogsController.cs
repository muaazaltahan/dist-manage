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
        private readonly IDataHelper<RequestDB> dataHelperRequest;
        private readonly IDataHelper<Link_Prog_CardDB> dataHelperLink_Prog_Card;
        private readonly IDataHelper<SectionUsersDB> dataHelperSectionUsers;
        private readonly IDataHelper<CardsDB> dataHelperCard;

        public LogsController(
            IDataHelper<LogsDB> dataHelper,
            IDataHelper<RequestDB> dataHelperRequest,
            IDataHelper<Link_Prog_CardDB> dataHelperLink_Prog_Card,
            IDataHelper<SectionUsersDB> dataHelperSectionUsers,
            IDataHelper<CardsDB> dataHelperCard)
        {
            this.dataHelper = dataHelper;
            this.dataHelperRequest = dataHelperRequest;
            this.dataHelperLink_Prog_Card = dataHelperLink_Prog_Card;
            this.dataHelperSectionUsers = dataHelperSectionUsers;
            this.dataHelperCard = dataHelperCard;
        }
        //GET : LogsController
        [HttpGet]
        public IActionResult Index()
        {
            var data = dataHelper.GetAllData();
            return Ok(data);
        }

        //GET : LogsController
        [HttpGet]
        public IActionResult ShowForDate()
        {
            var data = dataHelper.GetAllData().Where(x => x.LogDate.Date == DateTime.Now.Date);
            return Ok(data);
        }

        // GET: LogsController/Add
        [HttpGet]
        public ActionResult Add()
        {
            return Ok();
        }

        // POST: LogsController/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(LogsDB collection, int userId)
        {
            try
            {
                var sectionid = dataHelperSectionUsers.GetAllData()
                    .Join(dataHelperCard.GetAllData(), SectionUsersDB => SectionUsersDB.SectionsId, Cards => Cards.Sectionid, (SectionUsersDB, CardsDB) => new { SectionUsersDB = SectionUsersDB, CardsDB = CardsDB }).Where(x => x.SectionUsersDB.UsersId == userId)
                    .ToList();
                if (sectionid.Count > 0)
                {
                    if (dataHelper.GetAllData().Where(x => x.LogDate.Date == DateTime.Now.Date).Count() == 0)
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
                    else
                    {
                        // Error Message 
                        return NotFound();
                    }
                }
                else
                {
                    var data = dataHelperRequest.GetAllData()
                   .Where(x => x.Id == collection.Link_Prog_CardId && x.RequestDate.Date == DateTime.Now.Date)
                   .ToList();
                    if (data.Count > 0)
                    {
                        if (data.Select(x => x.Result).Last() == true)
                        {
                            if (dataHelper.GetAllData().Where(x => x.LogDate.Date == DateTime.Now.Date).Count() == 0)
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
                            else
                            {
                                // Error Message 
                                return NotFound();
                            }
                           
                        }
                        else
                        { 
                            // Error Message
                            return NotFound();
                        }
                    }
                    else
                    {
                        // Redirect to request
                        return Redirect("RequestController/Add");
                    }
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

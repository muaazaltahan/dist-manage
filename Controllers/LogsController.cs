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
    public class LogsController : ControllerBase
    {
        private readonly IDataHelper<LogsDB> dataHelper;
        private readonly IDataHelper<RequestDB> dataHelperRequest;
        private readonly IDataHelper<Link_Prog_CardDB> dataHelperLink_Prog_Card;
        private readonly IDataHelper<SectionUsersDB> dataHelperSectionUsers;
        private readonly IDataHelper<SectionsDB> dataHelperSections;
        private readonly CardsEntity dataHelperCard;

        public LogsController(
            IDataHelper<LogsDB> dataHelper,
            IDataHelper<RequestDB> dataHelperRequest,
            IDataHelper<Link_Prog_CardDB> dataHelperLink_Prog_Card,
            IDataHelper<SectionUsersDB> dataHelperSectionUsers,
            IDataHelper<SectionsDB> dataHelperSections,
            CardsEntity dataHelperCard)
        {
            this.dataHelper = dataHelper;
            this.dataHelperRequest = dataHelperRequest;
            this.dataHelperLink_Prog_Card = dataHelperLink_Prog_Card;
            this.dataHelperSectionUsers = dataHelperSectionUsers;
            this.dataHelperSections = dataHelperSections;
            this.dataHelperCard = dataHelperCard;
        }
        //GET : LogsController
        [HttpGet, Authorize]
        public IActionResult Index()
        {
            var data = dataHelper.GetAllData().Select(x =>
            {
                var link = dataHelperLink_Prog_Card.Find(x.Link_Prog_CardId);
                var card = dataHelperCard.Find(link.CardsId);
                return new { LogDate = x.LogDate, Card = card, Id = x.Id };
            });
            return Ok(data);
        }

        //GET : LogsController\ShowForDate
        [HttpGet("ShowForDate"), Authorize]
        public IActionResult ShowForDate(DateTime date)
        {
            var data = dataHelper.GetAllData().Where(x => x.LogDate.Date == date.Date).Select(x =>
            {
                var link = dataHelperLink_Prog_Card.Find(x.Link_Prog_CardId);
                var card = dataHelperCard.Find(link.CardsId);
                return new { LogDate = x.LogDate, Card = card, Id = x.Id };
            });
            return Ok(data);
        }

        public class Statistic
        {
            public string SectionName { get; set; }

            public int Count { get; set; }

            public int Received { get; set; }
            public int NoReceived { get; set; }


        }
        // GET: LogsController/Add
        [HttpGet("Add"), Authorize]
        public ActionResult Add(int userId)
        {
            var data = dataHelperCard.GetAllData()
                 .Join(dataHelperSectionUsers.GetAllData(), CardsDB => CardsDB.Sectionid, SectionUsersDB => SectionUsersDB.SectionsId, (CardsDB, SectionUsersDB) => new { CardsDB = CardsDB, SectionUsersDB = SectionUsersDB })
                  .Join(dataHelperSections.GetAllData(), temp => temp.SectionUsersDB.SectionsId, SectionsDB => SectionsDB.Id, (temp, SectionsDB) => new { temp.CardsDB, temp.SectionUsersDB, SectionsDB = SectionsDB })
                 .Where(x => x.SectionUsersDB.UsersId == userId).ToList();
            var Received = data
                 .Join(dataHelperLink_Prog_Card.GetAllData(), temp => temp.CardsDB.Id, Link_Prog_CardDB => Link_Prog_CardDB.CardsId, (temp, Link_Prog_CardDB) => new { temp.CardsDB, temp.SectionUsersDB, Link_Prog_CardDB = Link_Prog_CardDB })
                 .Join(dataHelper.GetAllData(), table => table.Link_Prog_CardDB.Id, LogsDB => LogsDB.Link_Prog_CardId, (table, LogsDB) => new { table.CardsDB, table.SectionUsersDB, table.Link_Prog_CardDB, LogsDB = LogsDB })
                 .Where(x => x.LogsDB.LogDate.Date == DateTime.Now.Date);
            var Result = data.GroupBy(x => x.SectionsDB).Select(x => new Statistic
            {
                SectionName = x.Key.SectionName,
                Count = data.Count(),
                Received = Received.Count(),
                NoReceived = data.Count() - Received.Count()
            });;
            return Ok(Result);
        }

        // POST: LogsController/Add
        [HttpPost("Add"), Authorize]
        //[ValidateAntiForgeryToken]
        public ActionResult Add(Logs collection, int userId)
        {
            try
            {
                var sectionid = dataHelperSectionUsers.GetAllData()
                    .Join(dataHelperCard.GetAllData(), SectionUsersDB => SectionUsersDB.SectionsId, Cards => Cards.Sectionid, (SectionUsersDB, CardsDB) => new { SectionUsersDB = SectionUsersDB, CardsDB = CardsDB }).Where(x => x.SectionUsersDB.UsersId == collection.UsersId && x.CardsDB.Id == collection.CardId)
                    .ToList();
                if (sectionid.Count > 0)
                {
                    if (dataHelper.GetAllData().Where(x => x.LogDate.Date == DateTime.Now.Date).Count() == 0)
                    {
                        var result = dataHelper.Add(collection);
                        if (result == 1)
                        {
                            var id = dataHelper.GetAllData().Last();
                            return Ok(id);

                        }
                        else
                        {
                            return Ok();
                        }
                    }
                    else
                    {
                        // Error Message 
                        return BadRequest("تم الاستلام سابقاً");
                    }
                }
                else
                {
                    var data = dataHelperRequest.GetAllData()
                   .Where(x => x.Link_Prog_CardId == collection.Link_Prog_CardId && x.RequestDate.Date == DateTime.Now.Date)
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
                                    var id = dataHelper.GetAllData().Select(x => x.Id).Last();
                                    return Ok(id);

                                }
                                else
                                {
                                    return Ok();
                                }
                            }
                            else
                            {
                                // Error Message 
                                return BadRequest("تم الاستلام سابقاً");
                            }

                        }
                        else
                        {
                            // Error Message
                            return BadRequest("لم يتم الموافقة على طلب الاستلام من غير قطاع");
                        }
                    }
                    else
                    {
                        // Error Message
                        return BadRequest("يرجى طلب الاستلام من غير قطاع");
                    }
                }


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST: LogsController/Delete/5
        [HttpDelete("Delete/{id}"), Authorize("Moderator")]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Logs collection)
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

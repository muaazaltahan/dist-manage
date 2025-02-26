using dist_manage.Models;
using dist_manage.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace dist_manage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private readonly IDataHelper<LogsDB> dataHelper;
        private readonly IDataHelper<CardsDB> dataHelperCard;
        private readonly IDataHelper<Link_Prog_CardDB> dataHelperLink_Prog_CardDB;

        public QueryController(
            IDataHelper<LogsDB> dataHelper,
            IDataHelper<CardsDB> dataHelperCardsDB,
            IDataHelper<Link_Prog_CardDB> dataHelperLink_Prog_CardDB)
        {
            this.dataHelper = dataHelper;
            this.dataHelperCard = dataHelperCardsDB;
            this.dataHelperLink_Prog_CardDB = dataHelperLink_Prog_CardDB;
        }
        //GET : CardsController
        [HttpGet]
        public IActionResult Index()
        {
            var data = dataHelper.GetAllData();
            return Ok(data);
        }

        [HttpPost("Query")]

        public ActionResult Query(QueryTable collection)
        {
            try
            {
                var Result = dataHelperCard.GetAllData();
                var query = dataHelper.GetAllData()
                        .Join(dataHelperLink_Prog_CardDB.GetAllData(), LogsDB => LogsDB.Link_Prog_CardId, Link_Prog_CardDB => Link_Prog_CardDB.Id, (LogsDB, Link_Prog_CardDB) => new { LogsDB = LogsDB, Link_Prog_CardDB = Link_Prog_CardDB })
                              .Join(dataHelperCard.GetAllData(), temp => temp.Link_Prog_CardDB.CardsId, CardsDB => CardsDB.Id, (temp, CardsDB) => new { temp.LogsDB, temp.Link_Prog_CardDB, CardsDB = CardsDB })
                              .AsQueryable();

                if (!string.IsNullOrEmpty(collection.Barcode))
                {
                    query = query.Where(x => (x.CardsDB.Id).ToString().Contains(collection.Barcode));
                }
                if (!string.IsNullOrEmpty(collection.Name))
                {
                    query = query.Where(x => x.CardsDB.Name.Contains(collection.Name));
                }
                if (collection.StartDate != null)
                {
                    query = query.Where(x => x.LogsDB.LogDate.Date == collection.StartDate.Date);
                }
                if (collection.Status == false)
                {
                    var alldata = dataHelperCard.GetAllData().Select(x => x.Id);
                    var nodata = query.Select(x => x.CardsDB.Id);
                    var data = alldata.Except(nodata).ToList();
                    Result = Result.Where(x => data.Contains(x.Id)).ToList();
                }
                else
                {
                    var data = query.Select(x => x.CardsDB.Id);
                    Result = Result.Where(x => data.Contains(x.Id)).ToList();
                }
                return Ok(Result);
            }
            catch (Exception)
            {

                return BadRequest("خطأ في الاستعلام");
            }
        }
        public class QueryTable
        {
            public string Barcode { get; set; }

            public string Name { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public bool Status { get; set; }


        }

    }
}

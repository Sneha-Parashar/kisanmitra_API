using Microsoft.AspNetCore.Mvc;
using CrudWebAPICORESP.Model;
using System.Data;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace CrudWebAPICORESP.Controllers
{
    [ApiVersion("2.0")]
    [Authorize]
    [Route("v{version:apiVersion}/api/kisanmitra/consultantCertification")]
    [ApiController]
    public class Consultantv2Controller : ControllerBase
    {
        private readonly ILogger<Consultantv2Controller> _logger;
        private readonly db dbop = new db();
        private string msg = string.Empty;

        public Consultantv2Controller(ILogger<Consultantv2Controller> logger)
        {
            _logger = logger;
        }

        // GET: v1/api/kisanmitra/consultantCertification
        [HttpGet]
        public IActionResult Get(int pageNumber = 1, int pageSize = 10)
        {
            List<Consultant> list = new List<Consultant>();
            DataSet ds = dbop.ConsultantGetAll(out msg, pageNumber, pageSize);
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new Consultant
                    {
                        consultant_id = dr["consultant_id"].ToString(),
                        certification_number = dr["certification_number"].ToString(),
                        inserted_by = dr["inserted_by"].ToString(),
                        updated_by = dr["updated_by"].ToString(),
                        inserted_date = dr["inserted_date"] == DBNull.Value ? null : (DateTime?)dr["inserted_date"],
                        updated_date = dr["updated_date"] == DBNull.Value ? null : (DateTime?)dr["updated_date"]
                    });
                }
            }
            return Ok(list);
        }

        // GET v1/api/kisanmitra/consultantCertification/{consultant_id}/{certification_number}
        [HttpGet("{consultant_id}/{certification_number}")]
        public IActionResult GetByConsultantId(string consultant_id, string certification_number)
        {
            List<Consultant> list = new List<Consultant>();
            DataSet ds = dbop.ConsultantGetById(consultant_id, certification_number, out string msg);
            if (ds != null && ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    list.Add(new Consultant
                    {
                        consultant_id = dr["consultant_id"].ToString(),
                        certification_number = dr["certification_number"].ToString(),
                        inserted_by = dr["inserted_by"].ToString(),
                        updated_by = dr["updated_by"].ToString(),
                        inserted_date = dr["inserted_date"] == DBNull.Value ? null : (DateTime?)dr["inserted_date"],
                        updated_date = dr["updated_date"] == DBNull.Value ? null : (DateTime?)dr["updated_date"]
                    });
                }
            }
            return Ok(list);
        }

        //// POST v1/api/kisanmitra/consultantCertification
        //[HttpPost]
        //public IActionResult Post([FromBody] Consultant consultant)
        //{
        //    string msg;
        //    try
        //    {
        //        msg = dbop.ConsultantInsert(consultant);
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = ex.Message;
        //        _logger.LogError(ex, "Error inserting consultant");
        //        return BadRequest(msg);
        //    }
        //    return Ok(msg);
        //}

        //// PUT v1/api/kisanmitra/consultantCertification
        //[HttpPut]
        //public IActionResult Put([FromBody] Consultant consultant)
        //{
        //    string msg;
        //    try
        //    {
        //        msg = dbop.ConsultantUpdate(consultant);
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = ex.Message;
        //        _logger.LogError(ex, "Error updating consultant");
        //        return BadRequest(msg);
        //    }
        //    return Ok(msg);
        //}

        //// DELETE v1/api/kisanmitra/consultantCertification/{consultant_id}/{certification_number}
        //[HttpDelete("{certification_number}")]
        //public IActionResult Delete(string certification_number)
        //{
        //    string msg;
        //    try
        //    {
        //        msg = dbop.ConsultantDelete(certification_number);
        //    }
        //    catch (Exception ex)
        //    {
        //        msg = ex.Message;
        //        _logger.LogError(ex, "Error deleting consultant");
        //        return BadRequest(msg);
        //    }
        //    return Ok(msg);
        //}
    }
}

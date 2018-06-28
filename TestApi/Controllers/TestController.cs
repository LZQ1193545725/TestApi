using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using TestApi.Models;
using System.Data.SqlClient;
using System.Data;
using TestApi.Common;

namespace TestApi.Controllers
{
    public class TestController : ApiController
    {
        private int pageIndex = 1;
        private int pageSize = 10;
        private string connection = @"Data Source=.; Initial Catalog=XCReportDB; user id=Sa;password=qq078120066+;MultipleActiveResultSets=True";
        public TestController()
        {
            pageIndex = HttpContext.Current.Request.QueryString["page"] == null ? 1 : Convert.ToInt32(HttpContext.Current.Request.QueryString["page"]);
            pageSize = HttpContext.Current.Request.QueryString["limit"] == null ? 10 : Convert.ToInt32(HttpContext.Current.Request.QueryString["limit"]);
 ;        }
        public JsonResult<TableData> GetData()
        {
            TableData data = new TableData();
            using (SqlConnection con = new SqlConnection(connection))
            {
                con.Open();
                string sql = "select top "+pageSize+" * from (select row_number() over (order by a.id) as rownumber, a.Id,a.UserName,a.DepartMentId,b.ItemName,a.MemberType from PersonData a inner join ItemData b on a.DepartMentId=b.Id and a.IsUsed=1 and b.IsUsed=1) c where c.rownumber>"+((pageIndex-1)*pageSize)+"  order by c.Id";
                string countsql = "select count(a.Id) from PersonData a inner join ItemData b on a.DepartMentId=b.Id and a.IsUsed=1 and b.IsUsed=1";
                int count = 0;
                count =Convert.ToInt32(new SqlCommand(countsql, con).ExecuteScalar());
                SqlDataAdapter da = new SqlDataAdapter(sql,con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                data.data = ds.Tables[0].ToList<PersonView>();
                data.count = count;data.code = 0;
            }
            return Json(data);
        } 
    }
}

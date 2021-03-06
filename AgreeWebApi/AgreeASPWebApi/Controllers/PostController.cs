using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace AgreeASPWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {


        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;

        public PostController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select Id, Title,Subtitle, Description, Text,
                            convert(varchar(10),AddDate,120) as AddDate
                            from
                            dbo.Post
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("PostConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }


            return new JsonResult(table);
        }

    }
}

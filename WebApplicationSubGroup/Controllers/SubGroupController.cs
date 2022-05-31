using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebApplicationSubGroup.Models;


namespace WebApplicationSubGroup.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubGroupController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public SubGroupController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {


            string query = @"
                    select SubGroupID, SubGroupName, GroupID, MakeBy, MakeDate,
                    convert(varchar(10),InsertTime,120) as InsertTime,
                    UpdateBy,
                    convert(varchar(10),UpdateDate,120) as UpdateDate,
                    convert(varchar(10),UpdateTime,120) as UpdateTime
                    from dbo.subGroupNew";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("subgroupnew");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(SubGroup sGroup)
        {

            string query = @"
                    insert into dbo.subGroupNew ( SubGroupName, GroupId, MakeBy, MakeDate, InsertTime, UpdateBy, UpdateDate, UpdateTime)
                    values(
                            '" + sGroup.SubGroupName + @"',
                            '" + sGroup.GroupId + @"',
                            '" + sGroup.MakeBy + @"',
                            '" + sGroup.MakeDate + @"',
                            '" + sGroup.InsertTime + @"',
                            '" + sGroup.UpdateBy + @"',
                            '" + sGroup.UpdateDate + @"',
                            '" + sGroup.UpdateTime + @"'
                        )";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("subgroupnew");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Succesfully");
        }


        [HttpPut]
        public JsonResult Put(SubGroup sGroup)
        {
            string query = @"
                    update dbo.subGroupNew set 
                    SubGroupName = '" + sGroup.SubGroupName + @"'
                    ,MakeBy = '" + sGroup.MakeBy + @"'
                    ,MakeDate = '" + sGroup.MakeDate + @"'
                    ,InsertTime = '" + sGroup.InsertTime + @"'
                    ,UpdateBy = '" + sGroup.UpdateBy + @"'
                    ,UpdateDate = '" + sGroup.UpdateDate + @"'
                    ,UpdateTime = '" + sGroup.UpdateTime + @"'
                    where SubGroupID = " + sGroup.SubGroupID + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("subgroupnew");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }


        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                    delete from dbo.subGroupNew 
                    where SubGroupID = " + id + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("subgroupnew");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

    }
}

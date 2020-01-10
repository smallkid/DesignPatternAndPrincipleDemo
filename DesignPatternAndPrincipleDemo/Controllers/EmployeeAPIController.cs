using darkstar.core;
using DesignPatternAndPrincipleDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DesignPatternAndPrincipleDemo.Controllers
{
    public class EmployeeAPIController : ApiController
    {
        private IEmployeeRepository _repo;

        public EmployeeAPIController()
        {

        }

        public EmployeeAPIController(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        [Route("api/Employee/GetList")]
        public IHttpActionResult GetEmployeeList()
        {
            try
            {
                var res = _repo.GetList(x => true).ToList();
                return Ok(new ApiResult { StatusCode = "0", StatusMessage = "Sucess", DataResult = res });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

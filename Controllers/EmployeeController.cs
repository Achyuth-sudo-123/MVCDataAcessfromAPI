using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using MVCDataAcessfromAPI.DTO.Response;
using MVCDataAcessfromAPI.Helpers;
using MVCDataAcessfromAPI.Models;

namespace MVCDataAcessfromAPI.Controllers
{
    [ServiceFilter(typeof(ExceptionFilters))]
    public class EmployeeController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly Apiconnect _apiconnect;
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiconnect = new Apiconnect(configuration);
        }

        


        public async Task<IActionResult> AllEmployeesDetails()
        
        {
             var data = await _apiconnect.ApiCallPost<List<EmployeeDetailsResponse>>("Employeeservice/GetEmployeeDetails");

            //var data1 = await _apiconnect.ApiCallPost<Employee?>("Employeeservice/GetEmployeeeDetailsById", new { id = 4 });

            return View("ViewTable",data);
        }
        public async Task<IActionResult> SingleEmployeesDetails( int id)

        {
            //var data = await _apiconnect.ApiCallPost<List<Employee>>("Employeeservice/GetEmployeeDetails");

            var data = await _apiconnect.ApiCallPost<Employee?>("Employeeservice/GetEmployeeeDetailsById", new { id = id });

            var employeeList = new List<Employee>();

            if(data is not null)
            {
                employeeList.Add(data);
            }

            return View("ViewTable", employeeList);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {

            ViewData["cities"] =await MVCCitiesTableData();
            ViewData["Gender"] = await MVCGenderTable();
            return View();
        }

        [HttpPost]
        public  async Task<IActionResult>  InsertEmployeeDetails(Employee employee)
        {

            var data = await _apiconnect.ApiCallPost<bool>("Employeeservice/InsertEmployeeDetails", employee);
            if(data==true)
            {
                return RedirectToAction("AllEmployeesDetails");
            }
            else
            {
                return View("Create",employee);
            }
        }



        //Table Data For countries Dropdown list


        public async Task<List<Cities>> MVCCitiesTableData()
        {
            var table = await _apiconnect.ApiCallPost<List<Cities>>("Cities/CitiesTableData");

            if(table is not null)
            {
                return table;
            }
            throw new NullReferenceException("CitiesTable is empty");
        }


        //Table for GenderDropDownList

        public async Task<List<Gender>> MVCGenderTable()
        {
            var GenderTable = await _apiconnect.ApiCallPost<List<Gender>>("Reference/GenderDetailsList");

            if(GenderTable is not null)
            {
                return GenderTable;
            }
            throw new NullReferenceException("Gender Table is Empty");
        }
    }
}

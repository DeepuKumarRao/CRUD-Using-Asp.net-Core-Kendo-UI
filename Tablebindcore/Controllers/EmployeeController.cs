using Microsoft.AspNetCore.Mvc;
using Tablebindcore.Models;
using Microsoft.EntityFrameworkCore;
using Kendo.Mvc.UI;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Tablebindcore.Controllers
{
    public class EmployeeController : Controller
    {
        //private readonly ConnectionStringClass _cc;
        private readonly IConfiguration _configuration;
        private ConnectionStringClass _context;
        private IEmployeeDAO _IemployeeDAO;

        public EmployeeController(ConnectionStringClass context, IConfiguration configuration, IEmployeeDAO IemployeeDAO)
        {
            _context = context;
            _IemployeeDAO = IemployeeDAO;
            //string _configuration = configuration.GetSection("ConnectionStrings:MyConnection").Value;
        }

        public IActionResult Index()
        {
            List<EmpClass> results = new List<EmpClass>();
            var data = _IemployeeDAO.getEmployeeData();
            //using (var objContext = new ConnectionStringClass(_context))
            //{
            //    //string connectionString = _configuration;
            //    results = objContext.Empdata.ToList();

            //}
            //var results = _context..ToList();
            return View(data);
        }



        //public ActionResult create([Datasourcerequest] Datasourcerequest request, Empclass empclass)
        //{
        
        //    dbcontext.Empdata.add(empclass);
        //    dbcontext.savechanges();
        //    return view();
        //}


        public IActionResult Create([DataSourceRequest] DataSourceRequest request,Models.EmpClass empClass)
        {
            if (empClass != null & ModelState.IsValid)
            {
                _context.Add(empClass);
                _context.SaveChanges();

            }
            return View (empClass);
           
          
        }

        public class EmployeeDAO : IEmployeeDAO 
        {
            private readonly ConnectionStringClass _context;
            public EmployeeDAO(ConnectionStringClass context)
            {
                _context= context;
            }

            public List<EmpClass> getEmployeeData()
            {
                var data = _context.Empdata.ToList();
                return data;
            }
        }
        public interface IEmployeeDAO
        {
            public List<EmpClass> getEmployeeData();
        }
        public class EmpClassModel
        {
            public int Id { get; set; }
            public string? EmployeeName { get; set; }
            public string? Designation { get; set; }
            public string? Department { get; set; }
            public int Salary { get; set; }
        }

      
    }
}




using Microsoft.AspNetCore.Mvc;
using OEMINT_exercise.Models;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text;
using CsvHelper;

namespace OEMINT_exercise.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var formDataList = new List<FormDataModel>
         {
        new FormDataModel()
         };

            return View(formDataList);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult ExportToCSV(List<FormDataModel> formData)
        {

            string csvContent = CSVUtility.ConvertToCSV(formData);

            
            var contentType = "text/csv";
            var fileName = "FormData.csv";

           
            return File(Encoding.UTF8.GetBytes(csvContent), contentType, fileName);
        }
    }






}

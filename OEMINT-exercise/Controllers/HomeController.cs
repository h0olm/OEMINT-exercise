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
        new FormDataModel() // Initialize with a default FormDataModel instance
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
            // Convert the form data to a CSV string
            string csvContent = CSVUtility.ConvertToCSV(formData);

            // Set the content type and file name
            var contentType = "text/csv";
            var fileName = "FormData.csv";

            // Return the file to the client
            return File(Encoding.UTF8.GetBytes(csvContent), contentType, fileName);
        }
    }






}
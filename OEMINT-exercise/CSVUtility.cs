namespace OEMINT_exercise
{
    using OEMINT_exercise.Models;
    using System.Collections.Generic;
    using System.Text;

    public static class CSVUtility
    {
        public static string ConvertToCSV(List<FormDataModel> data)
        {
            StringBuilder csvContent = new StringBuilder();
            csvContent.AppendLine("FirstName,LastName,Email");

            foreach (var item in data)
            {
                csvContent.AppendLine($"{item.FirstName},{item.LastName},{item.Email}");
            }

            return csvContent.ToString();
        }
    }

}

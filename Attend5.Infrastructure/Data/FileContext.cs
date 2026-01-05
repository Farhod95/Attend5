using Attend5.Domain.Models;
using OfficeOpenXml;

namespace Attend5.Infrastructure.Data
{
    public class FileContext
    {
        public List<ExternalAttendance> ExternalAttendances { get; set; }

        public FileContext()
        {
            this.ExternalAttendances = new List<ExternalAttendance>();            
        }
        public void ExcelYuklash()
        {
            try
            {
                using var package = new ExcelPackage(new FileInfo(@"D:\DASTURLASH\0 to junior\2-oy 22.12.2025 - 22.01.2026\3-dars 26.12.2025\Attend5\fixed_attendance.xlsx"));

                var worksheet = package.Workbook.Worksheets[0];

                var rowCount = worksheet.Dimension.Rows;

                for (var row = 2; row <= rowCount; row++)
                {
                    ExternalAttendances.Add(new ExternalAttendance
                    {
                        FullNameWithId = worksheet.Cells[row, 1].Text,
                        Email = worksheet.Cells[row, 2].Text,
                        EnterDate = worksheet.Cells[row, 3].GetValue<DateTime>(),
                        ExitDate = worksheet.Cells[row, 4].GetValue<DateTime>(),
                        Duration = int.Parse(worksheet.Cells[row, 5].Text),
                        IsHost = worksheet.Cells[row, 6].Text,
                        IsWaiting = worksheet.Cells[row, 7].Text,
                    });
                }

                if (ExternalAttendances.Count() == 0)
                {
                    Console.WriteLine(" Excel faylni yuklashni iloji bo'lmadi.");
                }
                else
                {
                    Console.WriteLine(" Excel fayl muvaffaqiyatli yuklandi.");
                }
            }
            catch
            {
                Console.WriteLine(" Excel faylni yuklashda xatolik yuz berdi.");
            }           
        }
    }
}
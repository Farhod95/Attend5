using Attend5.Infrastructure.Data;

namespace Attend5.Application.Service
{
    public class ExternalAttendanceService
    {
        public FileContext myExcelFile {  get; set; }
        public ExternalAttendanceService(FileContext fileContext)
        {
            myExcelFile = fileContext;
        }

        public void ExcelEkrangaChiqar()
        {
            if (myExcelFile.ExternalAttendances.Count()!=0)
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine("          EXCEL RO'YXATI                  ");
                Console.WriteLine("*******************************************");
                foreach (var item in myExcelFile.ExternalAttendances)
                {
                    Console.WriteLine($" FullNameWithId = {item.FullNameWithId}, Email = {item.Email}, EnterDate = {item.EnterDate}, ExitDate = {item.ExitDate}, Duration = {item.Duration}, IsHost = {item.IsHost}, IsWainting = {item.IsWaiting}");
                }
            }
            else
            {
                Console.WriteLine(" Excel fayl yuklanmagan!");
            }            
        }
    }
}
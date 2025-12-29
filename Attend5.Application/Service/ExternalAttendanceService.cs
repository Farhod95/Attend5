using Attend5.Infrastructure.Data;

namespace Attend5.Application.Service
{
    public class ExternalAttendanceService
    {
        public FileContext myExcelFile {  get; set; }
        public ExternalAttendanceService()
        {
            this.myExcelFile = new FileContext();
        }

        public void ExcelEkrangaChiqar()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("          EXCEL RO'YXATI                  ");
            Console.WriteLine("*******************************************");
            foreach (var item in myExcelFile.ExternalAttendances)
            {
                Console.WriteLine($" FullNameWithId = {item.FullNameWithId}, Email = {item.Email}, EnterDate = {item.EnterDate}, ExitDate = {item.ExitDate}, Duration = {item.Duration}, IsHost = {item.IsHost}, IsWainting = {item.IsWaiting}");
            }
        }
    }
}

using Attend5.Application.Service;
using Attend5.Infrastructure.Data;

namespace Attend5.Client
{
    internal class Program
    {
        public FileContext myFileContext { get; set; }
        public StudentAttendServices myStudentAttend {  get; set; }
        public ExternalAttendanceService myExternalAttendance { get; set; }
        public Program()
        {
            this.myFileContext = new FileContext();
            this.myStudentAttend = new StudentAttendServices(myFileContext);
            this.myExternalAttendance = new ExternalAttendanceService(myFileContext);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("          XUSH KELIBSIZ  !                 ");
            Console.WriteLine("*******************************************");
            var program = new Program();
            program.Run();
        }

        public void Run()
        {
            bool savol = false;
            while (!savol)
            {
                savol = true;

                Console.WriteLine();
                Console.WriteLine("*******************************************");
                Console.WriteLine("          DASTURNI TANLANG                 ");
                Console.WriteLine("*******************************************");
                Console.WriteLine(" 1. Excel ro'yxatini yuklash ");
                Console.WriteLine(" 2. Excel ro'yxatini chiqarish ");
                Console.WriteLine(" 3. Yangi jadvalni to'liq ko'rish ");
                Console.WriteLine(" 4. Ism, Familiya va ID ko'rish ");
                Console.WriteLine(" 5. Ism va qatnashgan vaqtini ko'rish ");
                Console.WriteLine(" 6. Familiya bo‘yicha qidirish ");
                Console.WriteLine(" 7. Familiya o'zgartrish ");
                Console.WriteLine(" 8. Id bo'yicha o'chirish ");
                Console.WriteLine("*******************************************");
                Console.WriteLine();
                Console.Write(" Kerakli bo'limni kiriting: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            Console.WriteLine();
                            myFileContext.ExcelYuklash();
                            myStudentAttend = new StudentAttendServices(myFileContext);
                            if (QaytaIshgaTushir()) { savol = false; continue; }
                            else { continue; }
                        }
                    case "2":
                        {
                            Console.WriteLine();
                            myExternalAttendance.ExcelEkrangaChiqar();
                            if (QaytaIshgaTushir()) { savol = false; continue; }
                            else { continue; }
                        }
                    case "3":
                        {
                            Console.WriteLine();
                            myStudentAttend.YangiAttendJadvaliKorish();
                            if (QaytaIshgaTushir()) { savol = false; continue; }
                            else { continue; }
                        }
                    case "4":
                        {
                            Console.WriteLine();
                            myStudentAttend.IsmFamiliyaId();
                            if (QaytaIshgaTushir()) { savol = false; continue; }
                            else { continue; }
                        }
                    case "5":
                        {
                            Console.WriteLine();
                            myStudentAttend.IsmQatnashganVaqti();
                            if (QaytaIshgaTushir()) { savol = false; continue; }
                            else { continue; }
                        }
                    case "6":
                        {
                            Console.WriteLine();
                            QidirFamiliya();
                            if (QaytaIshgaTushir()) { savol = false; continue; }
                            else { continue; }
                        }
                    case "7":
                        {
                            Console.WriteLine();
                            FamiliyaOzgar();
                            if (QaytaIshgaTushir()) { savol = false; continue; }
                            else { continue; }
                        }
                    case "8":
                        {
                            Console.WriteLine();
                            IdOchir();
                            if (QaytaIshgaTushir()) { savol = false; continue; }
                            else { continue; }
                        }
                    default:
                        {
                            Console.WriteLine("*******************************************");
                            Console.WriteLine("          NOTO‘G‘RI AMAL KIRITILDI       ");
                            Console.WriteLine("*******************************************");

                            if (QaytaIshgaTushir()) { savol = false; continue; }
                            else { continue; }
                        }
                }
            }            
        }

        public bool QaytaIshgaTushir()
        {
            Console.WriteLine();
            Console.Write(" Dasturni qayta ishga tushirishni istaysizmi? (yes/no): ");
            return Console.ReadLine().ToLower() == "yes";
        }

        public void QidirFamiliya()
        {
            Console.Write(" Kerakli familiyani kiriting: ");
            myStudentAttend.FamiliyaBoyichaQidir(Console.ReadLine());
        }
        public void FamiliyaOzgar()
        {
            Console.Write(" Id kiriting:");
            string id= Console.ReadLine();

            Console.Write(" Familiya kiriting:");
            string familiya = Console.ReadLine();

            myStudentAttend.FamiliyaOzagartr(id, familiya);
        }
        public void IdOchir()
        {
            Console.Write(" Kerakli ID ni kiriting: ");
            myStudentAttend.IdBoyichaOchirish(Console.ReadLine());
        }
    }
}
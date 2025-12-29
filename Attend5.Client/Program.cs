using Attend5.Application.Service;

namespace Attend5.Client
{
    internal class Program
    {
        public ExternalAttendanceService myExternalAttendance {  get; set; }
        public StudentAttendServices myStudentAttend {  get; set; }
        public Program()
        {
            this.myExternalAttendance = new ExternalAttendanceService();
            this.myStudentAttend = new StudentAttendServices();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("          XUSH KELIBSIZ                    ");
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
                Console.WriteLine("          DASTURNI TANLANG                ");
                Console.WriteLine("*******************************************");
                Console.WriteLine(" 1. Excel ro'yxatini chiqarish ");
                Console.WriteLine(" 2. Yangi jadvalni to'liq ko'rish ");
                Console.WriteLine(" 3. Ism, Familiya va ID ko'rish ");
                Console.WriteLine(" 4. Ism va qatnashgan vaqtini ko'rish ");
                Console.WriteLine(" 5. ID bo‘yicha qidirish ");
                Console.WriteLine(" 6. Ism bo‘yicha qidirish ");
                Console.WriteLine(" 7. Familiya bo‘yicha qidirish ");
                Console.WriteLine("*******************************************");
                Console.WriteLine();
                Console.Write(" Kerakli bo'limni kiriting: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            Console.WriteLine();
                            myExternalAttendance.ExcelEkrangaChiqar();
                            if (QaytaIshgaTushir()) { savol = false; continue; }
                            else { continue; }
                        }
                    case "2":
                        {
                            Console.WriteLine();
                            myStudentAttend.YangiAttendJadvaliKorish();
                            if (QaytaIshgaTushir()) { savol = false; continue; }
                            else { continue; }
                        }
                    case "3":
                        {
                            Console.WriteLine();
                            myStudentAttend.IsmFamiliyaId();
                            if (QaytaIshgaTushir()) { savol = false; continue; }
                            else { continue; }
                        }
                    case "4":
                        {
                            Console.WriteLine();
                            myStudentAttend.IsmQatnashganVaqti();
                            if (QaytaIshgaTushir()) { savol = false; continue; }
                            else { continue; }
                        }
                    case "5":
                        {
                            Console.WriteLine();
                            QidirId();
                            if (QaytaIshgaTushir()) { savol = false; continue; }
                            else { continue; }
                        }
                    case "6":
                        {
                            Console.WriteLine();
                            QidirIsm();
                            if (QaytaIshgaTushir()) { savol = false; continue; }
                            else { continue; }
                        }
                    case "7":
                        {
                            Console.WriteLine();
                            QidirFamiliya();
                            if (QaytaIshgaTushir()) { savol = false; continue; }
                            else { continue; }
                        }
                    default:
                        {
                            Console.WriteLine("*******************************************");
                            Console.WriteLine("          NOTO‘G‘RI AMAL KIRITILDIGI       ");
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

        public void QidirId()
        {
            Console.Write(" Kerakli ID ni kiriting: ");
            myStudentAttend.IdBoyichaQidir(Console.ReadLine());
        }
        public void QidirIsm()
        {
            Console.Write(" Kerakli ismni kiriting: ");
            myStudentAttend.IsmBoyichaQidir(Console.ReadLine());
        }
        public void QidirFamiliya()
        {
            Console.Write(" Kerakli familiyani kiriting: ");
            myStudentAttend.FamiliyaBoyichaQidir(Console.ReadLine());
        }
    }
}




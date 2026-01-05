using Attend5.Infrastructure.Data;

namespace Attend5.Application.Service
{
    public class StudentAttendServices
    {
        public FileContext myExcelFile { get; set; }
        public DbContext _DbContext {  get; set; }
        public StudentAttendServices(FileContext fileContext)
        {
            this._DbContext = new DbContext(fileContext.ExternalAttendances);
            this.myExcelFile = fileContext;
        }

        public void YangiAttendJadvaliKorish()
        {
            if (myExcelFile.ExternalAttendances.Count()!=0)
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine("          YANGI JADVAL KO'RINISHI         ");
                Console.WriteLine("*******************************************");
                foreach (var item in this._DbContext.StudentAttendances)
                {
                    Console.WriteLine($" Id = {item.Id}, FirstName = {item.FirstName}, LastName = {item.LastName}, Email = {item.Email}, FirstEntryTime = {item.FirstEntryTime}, LastExitTime = {item.LastExitTime}, ParticipationMinutes = {item.ParticipationMinutes} ");
                }
            }
            else
            {
                Console.WriteLine(" Excel fayl yuklanmagan!");
            }
        }

        public void IsmFamiliyaId()
        {
            if (myExcelFile.ExternalAttendances.Count() != 0)
            {
                Console.WriteLine("*******************************************");
                Console.WriteLine("          ISM, FAMILIYA VA ID            ");
                Console.WriteLine("*******************************************");
                foreach (var item in this._DbContext.StudentAttendances)
                {
                    Console.WriteLine($"ID: {item.Id} | {item.FirstName} {item.LastName}");
                    Console.WriteLine("*******************************************");
                }
            }
            else
            {
                Console.WriteLine(" Excel fayl yuklanmagan!");
            }
        }

        public void IsmQatnashganVaqti()
        {
            if (myExcelFile.ExternalAttendances.Count() != 0)
            {
                var myNewStudentAttend = this._DbContext.StudentAttendances.OrderByDescending(x => x.ParticipationMinutes);
                foreach (var item in myNewStudentAttend)
                {
                    Console.WriteLine($" {item.Id}   {item.FirstName}   {item.ParticipationMinutes}");
                }
            }
            else
            {
                Console.WriteLine(" Excel fayl yuklanmagan!");
            }
        }

        public void IdBoyichaQidir(string id)
        {
            if (myExcelFile.ExternalAttendances.Count() != 0)
            {
                var myNewStudent = this._DbContext.StudentAttendances.Where(x => x.Id.Contains(id)).ToList();
                Console.WriteLine();
                Console.WriteLine("*******************************************");
                Console.WriteLine($"          ID BO'YICHA QIDIRUV: {id}         ");
                Console.WriteLine("*******************************************");
                if (myNewStudent.Count == 0)
                {
                    Console.WriteLine($"Bunday {id} dagi student topilmadi!");
                    Console.WriteLine("*******************************************");
                }
                else
                {
                    foreach (var item in myNewStudent)
                    {
                        Console.WriteLine($"ID: {item.Id} | {item.FirstName} {item.LastName} | ParticipationMinutes: {item.ParticipationMinutes}");
                        Console.WriteLine("*******************************************");
                    }
                }
            }
            else
            {
                Console.WriteLine(" Excel fayl yuklanmagan!");
            }
        }

        public void IsmBoyichaQidir(string text)
        {
            if (myExcelFile.ExternalAttendances.Count() != 0)
            {
                var myNewStudent = this._DbContext.StudentAttendances.Where(x => x.FirstName.ToLower().Contains(text.ToLower())).ToList();
                Console.WriteLine();
                Console.WriteLine("*******************************************");
                Console.WriteLine($"          ISM BO'YICHA QIDIRUV: {text}         ");
                Console.WriteLine("*******************************************");
                if (myNewStudent.Count == 0)
                {
                    Console.WriteLine($"Bunday {text} ismdagi student topilmadi!");
                    Console.WriteLine("*******************************************");
                }

                else
                {
                    foreach (var item in myNewStudent)
                    {
                        Console.WriteLine($"ID: {item.Id} | {item.FirstName} {item.LastName} | ParticipationMinutes: {item.ParticipationMinutes}");
                        Console.WriteLine("*******************************************");
                    }
                }
            }
            else
            {
                Console.WriteLine(" Excel fayl yuklanmagan!");
            }
        }

        public void FamiliyaBoyichaQidir(string text)
        {
            if (myExcelFile.ExternalAttendances.Count() != 0)
            {
                var myNewStudent = this._DbContext.StudentAttendances.Where(x => x.LastName.ToLower().Contains(text.ToLower())).ToList();
                Console.WriteLine();
                Console.WriteLine("*******************************************");
                Console.WriteLine($"          FAMILIYA BO'YICHA QIDIRUV: {text}         ");
                Console.WriteLine("*******************************************");
                if (myNewStudent.Count == 0)
                {
                    Console.WriteLine($"Bunday {text} familiyadagi student topilmadi!");
                    Console.WriteLine("*******************************************");
                }

                else
                {
                    foreach (var item in myNewStudent)
                    {
                        Console.WriteLine($"ID: {item.Id} | {item.FirstName} {item.LastName} | ParticipationMinutes: {item.ParticipationMinutes}");
                        Console.WriteLine("*******************************************");
                    }
                }
            }
            else
            {
                Console.WriteLine(" Excel fayl yuklanmagan!");
            }
        }

        public void FamiliyaOzagartr(string id, string familya)
        {
            var student = _DbContext.StudentAttendances
                .FirstOrDefault(x => x.Id == id);

            if (student != null)
            {
                student.LastName = familya;
                Console.WriteLine("Familiya o‘zgartirildi!");
            }
        }

        public void IdBoyichaOchirish(string id)
        {
            var myStudent = this._DbContext.StudentAttendances.FirstOrDefault(x => x.Id == id);

            if (myStudent != null)
            {
                this._DbContext.StudentAttendances.Remove(myStudent);
                Console.WriteLine($" {id} dagi student o'chirildi ");
            }
            else
            {
                Console.WriteLine($" {id} dagi student topilmadi ");
            }
        }
    }
}
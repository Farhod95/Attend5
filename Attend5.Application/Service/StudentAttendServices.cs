using Attend5.Infrastructure.Data;

namespace Attend5.Application.Service
{
    public class StudentAttendServices
    {
        public DbContext _DbContext {  get; set; }
        public StudentAttendServices()
        {
            this._DbContext = new DbContext();
        }

        public void YangiAttendJadvaliKorish()
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("          YANGI JADVAL KO'RINISHI         ");
            Console.WriteLine("*******************************************");
            foreach (var item in this._DbContext.StudentAttendances)
            {
                Console.WriteLine($" Id = {item.Id}, FirstName = {item.FirstName}, LastName = {item.LastName}, Email = {item.Email}, FirstEntryTime = {item.FirstEntryTime}, LastExitTime = {item.LastExitTime}, ParticipationMinutes = {item.ParticipationMinutes} ");
            }
        }

        public void IsmFamiliyaId()
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

        public void IsmQatnashganVaqti()
        {
            var myNewStudentAttend = this._DbContext.StudentAttendances.OrderByDescending(x=>x.ParticipationMinutes);
            foreach (var item in myNewStudentAttend)
            {
                Console.WriteLine($" {item.Id}   {item.FirstName}   {item.ParticipationMinutes}");
            }
        }

        public void IdBoyichaQidir(string id)
        {
            var myNewStudent = this._DbContext.StudentAttendances.Where(x => x.Id.Contains(id)).ToList();
            Console.WriteLine();
            Console.WriteLine("*******************************************");
            Console.WriteLine($"          ID BO'YICHA QIDIRUV: {id}         ");
            Console.WriteLine("*******************************************");
            if (myNewStudent.Count == 0 )
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

        public void IsmBoyichaQidir(string text)
        {
            var myNewStudent = this._DbContext.StudentAttendances.Where(x=>x.FirstName.ToLower().Contains(text.ToLower())).ToList();
            Console.WriteLine();
            Console.WriteLine("*******************************************");
            Console.WriteLine($"          ISM BO'YICHA QIDIRUV: {text}         ");
            Console.WriteLine("*******************************************");
            if (myNewStudent.Count ==0)
            {
                Console.WriteLine($"Bunday {text} ismdagi student topilmadi!");
                Console.WriteLine("*******************************************");
            }

            else
            {
                foreach(var item in myNewStudent)
                {
                    Console.WriteLine($"ID: {item.Id} | {item.FirstName} {item.LastName} | ParticipationMinutes: {item.ParticipationMinutes}");
                    Console.WriteLine("*******************************************");
                }
            }
        }

        public void FamiliyaBoyichaQidir(string text)
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
    }
}

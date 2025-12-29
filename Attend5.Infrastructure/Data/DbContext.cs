using Attend5.Domain.Models;

namespace Attend5.Infrastructure.Data
{
    public class DbContext: FileContext
    {        
        public List<StudentAttend> StudentAttendances { get; set; }

        public DbContext()
        {
            this.StudentAttendances = new List<StudentAttend>();

            foreach (var item in ExternalAttendances)
            {
                var value = item.FullNameWithId.Split(' ');
                var id = value[2];
                var firstNamer = value[0];
                var lastNamer = value[1];

                var myNewStudent = StudentAttendances.FirstOrDefault(x => x.Id == id);

                if (myNewStudent != null)
                {
                    myNewStudent.ParticipationMinutes += item.Duration;

                    if (myNewStudent.FirstEntryTime>item.EnterDate)
                    {
                        myNewStudent.FirstEntryTime = item.EnterDate;
                    }

                    if (myNewStudent.LastExitTime < item.ExitDate)
                    {
                        myNewStudent.LastExitTime = item.ExitDate;
                    }
                }

                else
                {
                    StudentAttendances.Add(new StudentAttend
                    {
                        Id = id,
                        FirstName = firstNamer,
                        LastName = lastNamer,
                        Email = item.Email,
                        FirstEntryTime = item.EnterDate,
                        LastExitTime = item.ExitDate,
                        ParticipationMinutes = item.Duration,
                    });
                }
            }
        }        
    }
}

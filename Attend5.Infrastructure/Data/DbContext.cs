using Attend5.Domain.Models;

namespace Attend5.Infrastructure.Data
{
    public class DbContext
    {        
        public List<StudentAttend> StudentAttendances { get; set; }

        public DbContext(List<ExternalAttendance> externalAttendances)
        {
            this.StudentAttendances = new List<StudentAttend>();

            foreach (var item in externalAttendances)
            {
                var value = item.FullNameWithId.Split(' ');
                var id = value[2];
                var firstName = value[0];
                var lastName = value[1];

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
                        FirstName = firstName,
                        LastName = lastName,
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
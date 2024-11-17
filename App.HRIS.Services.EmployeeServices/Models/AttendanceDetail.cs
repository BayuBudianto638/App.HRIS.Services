namespace App.HRIS.Services.EmployeeServices.Models
{
    public class AttendanceDetail
    {
        public DateTime Date { get; set; }
        public TimeSpan TimeIn { get; set; }
        public TimeSpan TimeOut { get; set; }
    }
}

namespace App.HRIS.Services.EmployeeServices.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string NIK { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public byte[] EmployeeImage { get; set; }
        public List<AttendanceDetail> AttendanceDetails { get; set; }
    }
}

using System;

namespace Publicaciones.Infrastructure.Model
{
    public class EmployeePubModel
    {
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PubID { get; set; }
        public string PubName { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public DateTime CreationDate { get; set; }
    }
}

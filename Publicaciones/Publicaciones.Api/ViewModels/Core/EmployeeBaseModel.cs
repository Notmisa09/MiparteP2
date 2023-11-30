namespace Publicaciones.Api.Model.Core
{
    public class EmployeeBaseModel : BaseModel
    {
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public int? Joblvl { get; set; }
        public DateTime HireDate { get; set; }
        public int PubID { get; set; }
        public int JobID { get; set; }

    }
}

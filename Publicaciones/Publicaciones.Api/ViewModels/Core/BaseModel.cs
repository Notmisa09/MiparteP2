namespace Publicaciones.Api.Model.Core
{
    public abstract class BaseModel
    {
        public DateTime ChangeDate { get; set; }
        public int ChangeUser { get; set; }
    }
}

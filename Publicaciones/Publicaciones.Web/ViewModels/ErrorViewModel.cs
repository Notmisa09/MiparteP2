using System.Data;

namespace Publicaciones.Web.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool deleted { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
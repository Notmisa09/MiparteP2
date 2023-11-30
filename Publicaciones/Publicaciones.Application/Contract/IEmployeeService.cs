using Publicaciones.Application.Core;
using Publicaciones.Application.DTO.Employee;
using System.Collections.Generic;

namespace Publicaciones.Application.Contract
{
    public interface IEmployeeService : IBaseService<EmployeeDtoUpdate,EmployeeDtoAdd,EmployeeDtoRemove>
    {
        ServiceResult GetEmployeesByPubID(int PubID);
        ServiceResult GetEmployeesByJobID(int JobID);
    }
}

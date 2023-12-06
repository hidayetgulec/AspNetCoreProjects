using AspNetCore_API_Jwt_Bearer.DTOs;

namespace AspNetCore_API_Jwt_Bearer.Services
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetAll();
        EmployeeDto Get(int id);
    }
}

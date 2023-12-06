using AspNetCore_API_Jwt_Bearer.Entities;

namespace AspNetCore_API_Jwt_Bearer.Repositories
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAll();
        Employee GetById(int id);
        Employee Create(Employee city);
        void Update(Employee city);
        void Delete(Employee city);
    }
}

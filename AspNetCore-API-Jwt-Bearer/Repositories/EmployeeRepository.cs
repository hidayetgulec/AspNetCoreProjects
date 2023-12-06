using AspNetCore_API_Jwt_Bearer.Entities;

namespace AspNetCore_API_Jwt_Bearer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private List<Employee> employees = new List<Employee>()
        {
            new() {Id=1, FirstName="Ali", LastName="Uçar", BeginDate=new DateOnly(), Phone="5336456454", Email="ali@gmail.com"},
            new() {Id=2, FirstName="Oya", LastName="Koşar", BeginDate=new DateOnly(), Phone="5351235645", Email="oya@gmail.com"},
            new() {Id=3, FirstName="Neşe", LastName="Sever", BeginDate=new DateOnly(), Phone="5426451399", Email="nese@hotmail.com"},
            new() {Id=4, FirstName="Hasan", LastName="Kaya", BeginDate=new DateOnly(), Phone="5451212138", Email="hasan@gmail.com"}
        };
        public List<Employee> GetAll()
        {
            return employees;
        }
        public Employee GetById(int id)
        {
            return employees.Find(e => e.Id == id);
        }
        public Employee Create(Employee city)
        {
            throw new NotImplementedException();
        }
        public void Delete(Employee city)
        {
            throw new NotImplementedException();
        }
        public void Update(Employee city)
        {
            throw new NotImplementedException();
        }
    }
}

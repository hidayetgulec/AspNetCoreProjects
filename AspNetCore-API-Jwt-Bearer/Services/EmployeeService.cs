using AspNetCore_API_Jwt_Bearer.DTOs;
using AspNetCore_API_Jwt_Bearer.Repositories;
using AutoMapper;

namespace AspNetCore_API_Jwt_Bearer.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        public List<EmployeeDto> GetAll()
        {
            var list = _employeeRepository.GetAll();
            return _mapper.Map<List<EmployeeDto>>(list);
        }
        public EmployeeDto Get(int id)
        {
            var employee = _employeeRepository.GetById(id);
            return _mapper.Map<EmployeeDto>(employee);
        }

    }
}

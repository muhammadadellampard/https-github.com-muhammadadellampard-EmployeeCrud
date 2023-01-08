
using AutoMapper;
using EmployeeCrud.Core.DTO;
using EmployeeCrud.Core.Entities;
using EmployeeCrud.Core.Services;
using EmployeeCrud.Core.UnitOfWork;

namespace EmplyeeCrud.Services.Emplyee
{
    public class EmployeeService : IEmployeeService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeeService(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateEmployee(EmployeeDto model)
        {
            if (model != null)
            {
                var emp =  _mapper.Map<Employee>(model);
                await _unitOfWork.Employee.Add(emp);

                var result =await _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> DeleteEmployee(int EmployeeId)
        {
            if (EmployeeId > 0)
            {
                var Employee = await _unitOfWork.Employee.GetById(EmployeeId);
                if (Employee != null)
                {
                    _unitOfWork.Employee.Delete(Employee);
                    var result = await _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<EmployeeDto>> GetAllEmployees()
        {
            var EmployeeList = _mapper.Map<List<EmployeeDto>>( await _unitOfWork.Employee.GetAll());
            return EmployeeList;
        }

        public async Task<EmployeeDto> GetEmployeeById(int EmployeeId)
        {
            if (EmployeeId > 0)
            {
                var EmployeeDetails = _mapper.Map<EmployeeDto>(await _unitOfWork.Employee.GetById(EmployeeId));

                if (EmployeeDetails != null)
                    return EmployeeDetails;
            
            }
            return null;
        }

        public async Task<bool> UpdateEmployee(EmployeeDto EmployeeDto)
        {
            if (EmployeeDto != null)
            {
                var Employee = await _unitOfWork.Employee.GetById(EmployeeDto.Id);
                if (Employee != null)
                {
                    Employee.FirstName = EmployeeDto.FirstName;
                    Employee.MiddleName = EmployeeDto.MiddleName;
                    Employee.LastName = EmployeeDto.LastName;
                    Employee.Age = EmployeeDto.Age;

                    _unitOfWork.Employee.Update(Employee);

                    var result = await _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}

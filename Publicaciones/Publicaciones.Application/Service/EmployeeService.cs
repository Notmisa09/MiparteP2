﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Publicaciones.Application.Contract;
using Publicaciones.Application.Core;
using Publicaciones.Application.DTO.Employee;
using Publicaciones.Application.Exeptions;
using Publicaciones.Application.Validations.ContractValidations;
using Publicaciones.Domain.Entities;
using Publicaciones.Infrastructure.Interface;
using System;

namespace Publicaciones.Application.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> logger;
        private readonly IConfiguration _configuration;
        private readonly IEmployeeValidations _employeevalidations;
        public EmployeeService(IEmployeeRepository employeeRepository, 
                                        ILogger<EmployeeService> logger,
                                        IConfiguration _configuration,
                                        IEmployeeValidations _employeevalidations)
        {
            _employeeRepository = employeeRepository;
            this.logger = logger;
            this._configuration = _configuration;
            this._employeevalidations = _employeevalidations;
                
        }

        public ServiceResult GetAll()
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = _employeeRepository.GetEmployeeinfo();
                result.Message = _configuration["EmployeeSuccessMessages:getAllEmployeesSuccessMessage"];

            }
            catch (EmployeeServiceExeption exx)
            {
                result.Success = false;
                result.Message = exx.Message;
                logger.LogError(result.Message, exx.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = _configuration["EmployeeErrorMessage:getAllEmployeessErrorMessage"];
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        } 

        public ServiceResult GetByID(int ID)
        {
            ServiceResult result= new ServiceResult();
            {
                try
                {
                    result.Data = _employeeRepository.GetEmployeeinfobyID(ID);
                    result.Message = _configuration["EmployeeSuccessMessages:getEmployeeSuccessMessage"];

                }
                catch (EmployeeServiceExeption exx)
                {
                    result.Success = false;
                    result.Message = exx.Message;
                    logger.LogError(result.Message, exx.Message);
                }
                catch (Exception ex)
                {
                    result.Success = false;
                    result.Message = _configuration["EmployeeErrorMessage:getEmployeeErrorMessage"];
                    logger.LogError(result.Message, ex.ToString()); 
                }
                return result;
            }
        } 

        public ServiceResult GetEmployeesByPubID(int PubID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = _employeeRepository.GetEmployeeByPubID(PubID);
                result.Message = _configuration["EmployeeSuccessMessages:getAllEmployeesSuccessMessage"];
            }
            catch (EmployeeServiceExeption exx)
            {
                result.Success = false;
                result.Message = exx.Message;
                logger.LogError(result.Message, exx.Message);
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = _configuration["EmployeeErrorMessage:getEmployeeErrorMessage"];
                logger.LogError(result.Message,ex.ToString());
            }
            return result;
        }

        public ServiceResult GetEmployeesByJobID(int JobID)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                result.Data = _employeeRepository.GetEmployeeByJobID(JobID);
                result.Message = _configuration["EmployeeSuccessMessages:getAllEmployeesSuccessMessage"];
            }
            catch (EmployeeServiceExeption exx)
            {
                result.Success = false;
                result.Message = exx.Message;
                logger.LogError(result.Message, exx.Message);
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = _configuration["EmployeeErrorMessage:getEmployeeErrorMessage"];
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        }

        public ServiceResult Remove(EmployeeDtoRemove DtoRemove)
        {
            ServiceResult result = new ServiceResult(); 
            try
            {
                ServiceResult validation = _employeevalidations.DtoRemoveValidations(DtoRemove);
                if (!validation.Success)
                {
                    return validation;
                }
                else
                {
                    Employee employee = new Employee()
                    {
                        EmpID = DtoRemove.EmpID,
                        DeletedDate = DtoRemove.ChangeDate,
                        DeletedUser = DtoRemove.ChangeUser,
                        Deleted = DtoRemove.Deleted
                    };
                    _employeeRepository.Remove(employee);
                    result.Message = _configuration["EmployeeSuccessMessages:removeEmployeeSuccessMessage"];
                }
            }
            catch (EmployeeServiceExeption exx)
            {
                result.Success = false;
                result.Message = exx.Message;
                logger.LogError(result.Message, exx.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = _configuration["EmployeeErrorMessage:removedEmployeeErrorMessage"];
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        } 

        public ServiceResult Save(EmployeeDtoAdd dtoadd)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                ServiceResult validation = _employeevalidations.DtoAddValidations(dtoadd);
                if (!validation.Success)
                {
                    return validation;
                }
                else
                {
                    Employee employee = new Employee()
                    {
                        CreationDate = dtoadd.ChangeDate,
                        IDCreationUser = dtoadd.ChangeUser,
                        FirstName = dtoadd.FirstName,
                        LastName = dtoadd.LastName,
                        HireDate = dtoadd.HireDate,
                        Joblvl = dtoadd.Joblvl,
                        JobID = dtoadd.JobID,
                        PubID = dtoadd.PubID
                    };
                    _employeeRepository.Save(employee);
                    result.Message = _configuration["EmployeeSuccessMessages:addEmployeeSuccessMessage"];
                }
            }
            catch (EmployeeServiceExeption exx)
            {
                result.Success = false;
                result.Message = exx.Message;
                logger.LogError(result.Message, exx.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = _configuration["EmployeeErrorMessage:addEmployeeErrorMessage"];
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        } 

        public ServiceResult Update(EmployeeDtoUpdate dtoupdate)
        {
            ServiceResult result = new ServiceResult();
            try
            {
                ServiceResult validation = _employeevalidations.DtoUpdateValidations(dtoupdate);
                if (!validation.Success)
                {
                    return validation;
                }
                else
                {
                    Employee employee = new Employee()
                    {
                        EmpID = dtoupdate.EmpID,
                        CreationDate = dtoupdate.ChangeDate,
                        IDCreationUser = dtoupdate.ChangeUser,
                        FirstName = dtoupdate.FirstName,
                        LastName = dtoupdate.LastName,
                        HireDate = dtoupdate.HireDate,
                        Joblvl = dtoupdate.Joblvl,
                        JobID = dtoupdate.JobID,
                        PubID = dtoupdate.PubID
                    };
                    _employeeRepository.Update(employee);
                    result.Message = _configuration["EmployeeSuccessMessages:updateEmployeeSuccessMessage"];
                }
            }
            catch (EmployeeServiceExeption exx)
            {
                result.Success = false;
                result.Message = exx.Message;
                logger.LogError(result.Message, exx.Message);
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = _configuration["EmployeeErrorMessage:updateEmployeeErrorMessage"];
                logger.LogError(result.Message, ex.ToString());
            }
            return result;
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wool.Data.Infrastructure;
using Wool.Data.Repositories;
using Wool.Model;

namespace Wool.Service
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork unitOfWork;

        public CustomerService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICustomerService Members

        public IEnumerable<Customer> GetCustomers()
        {
            return customerRepository.GetAll();
        }

        public Customer GetCustomerByID(long id)
        {
            Customer customer = customerRepository.GetById(id);
            return customer;
        }

        public Customer GetCustomerByName(string username)
        {
            Customer customer = customerRepository.GetByName(username);
            return customer;
        }
        public void CreateCustomer(Customer customer)
        {
            customerRepository.Add(customer);
        }

        public void DeleteCustomer(Customer customer)
        {
            customerRepository.Delete(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            customerRepository.Update(customer);
        }

        public void SaveCustomer()
        {
            unitOfWork.Commit();
        }


        #endregion

    }
}

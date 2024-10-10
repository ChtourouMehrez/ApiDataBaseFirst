using ApiDataBaseFirst.DTO;
using ApiDataBaseFirst.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDataBaseFirst.Repository.Interfaces
{
    public interface ICustomerRepostory
    {
          Task   add(Customer c);
          Task   Update(Customer c);
        public Task   delete(int idCustomer);

        public Task <Customer> GetCustomerAsync(int idCustomer);
        public Task <IEnumerable<Customer>> GetAllAsyncCustomer();

        public Task<IEnumerable<CustomerDTO>> GetAllAsyncCustomerDTO();

    }
}

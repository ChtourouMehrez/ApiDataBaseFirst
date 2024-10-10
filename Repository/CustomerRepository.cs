using ApiDataBaseFirst.DataBaseContext;
using ApiDataBaseFirst.DTO;
using ApiDataBaseFirst.Entities;
using ApiDataBaseFirst.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDataBaseFirst.Repository
{
    public class CustomerRepository : ICustomerRepostory
    {
        private readonly OnlineStoreDBContext _context;
        public CustomerRepository (OnlineStoreDBContext _context)
        {
            this._context = _context;
        }
        public async Task add(Customer c)
        {
         
            _context.Customers.Add(c);
              await  _context.SaveChangesAsync();
 
        }

        public async Task delete(int idCustomer)
        {
            Customer obj =await GetCustomerAsync(idCustomer);
            if (obj != null)
            {
                _context.Customers.Remove(obj);
               await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Customer>> GetAllAsyncCustomer()
        {

            return await _context.Customers.ToListAsync();
           
        }

        public async Task<IEnumerable<CustomerDTO>> GetAllAsyncCustomerDTO()
        {
            return await _context.Customers.Select(c => new CustomerDTO
            {
                Name = c.Name,
                Email = c.Email
            }).ToListAsync();

          
        }

        public async Task<Customer> GetCustomerAsync(int idCustomer)
        {
           return await _context.Customers.FirstOrDefaultAsync(c=>c.Id==idCustomer);
        }

        public async Task Update(Customer c)
        {
            _context.Customers.Update(c);
          await  _context.SaveChangesAsync();

        }
    }
}

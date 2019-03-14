using System;
using System.Data.Entity;
using System.Threading.Tasks;
using LoggingSample_BLL.Helpers;
using LoggingSample_BLL.Models;
using LoggingSample_DAL.Context;

namespace LoggingSample_BLL.Services
{
    public class CustomerService : IDisposable
    {
        private readonly AppDbContext _context = new AppDbContext();

        public Task<CustomerModel> GetCustomer(int customerId)
        {
            if (customerId == 56)
            {
                throw new CustomerException("Wrong Id is requested", CustomerException.ErrorType.WrongId);
            }

            return _context.Customers.SingleOrDefaultAsync(item => item.Id == customerId).ContinueWith(task => {
                var customer = task.Result;

                return customer?.Map();
            });
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

    public class CustomerException : Exception
    {
        public enum ErrorType
        {
            WrongId
        }

        public ErrorType Type { get; set; }

        public CustomerException(string message, ErrorType errorType) : base(message)
        {
            Type = errorType;
        }
    }
}
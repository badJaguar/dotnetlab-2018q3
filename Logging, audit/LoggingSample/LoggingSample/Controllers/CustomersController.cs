using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;
using LoggingSample_BLL.Helpers;
using LoggingSample_BLL.Models;
using LoggingSample_BLL.Services;
using LoggingSample_DAL.Context;
using NLog;

namespace LoggingSample.Controllers
{
    [RoutePrefix("api/customers")]
    public class CustomersController : ApiController
    {
        private readonly AppDbContext _context = new AppDbContext();
        private readonly CustomerService _service = new CustomerService();
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();

        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var customers = (await _context.Customers.ToListAsync()).Select(item => item.Map()).Select(InitCustomer);

            return Ok(customers);
        }

        [Route("{customerId}", Name = "Customer")]
        public async Task<IHttpActionResult> Get(int customerId)
        {
            _logger.Info($"Getting customer id {customerId}.");

            try
            {
                var customer = await _service.GetCustomer(customerId);

                if (customer == null)
                {
                    _logger.Info($"Failed to find customer with id {customerId}.");
                    return NotFound();
                }

                var parsedCustomer = InitCustomer(customer);

                _logger.Info($"Sending customer with id {customerId} back to request originator.");

                return Ok(parsedCustomer);
            }
            catch (CustomerException ex)
            {
                if (ex.Type == CustomerException.ErrorType.WrongId)
                {
                    _logger.Warn(ex, $"Wrong id has been requested: {customerId}.");
                    return BadRequest();
                }

                throw;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error while getting custimer id {customerId}.");
                throw;
            }


        }


        private object InitCustomer(CustomerModel model)
        {
            return new
            {
                _self = new UrlHelper(Request).Link("Customer", new { customerId = model.Id }),
                orders = new UrlHelper(Request).Link("Orders", new { customerId = model.Id }),
                data = model
            };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
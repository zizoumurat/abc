using MediatR;
using Microsoft.EntityFrameworkCore;
using porTIEVserver.Application.Services;
using porTIEVserver.Domain.Entities.ERP.FIN;
using porTIEVserver.Domain.Repositories.ERP.FIN;
using TS.Result;

namespace porTIEVserver.Application.Features.ERP.FIN.Customers.GetAllCustomers
{
    internal sealed class GetAllCustomersQueryHandler(
        ICustomerRepository customerRepository,
        ICacheService cacheService
        ) : IRequestHandler<GetAllCustomersQuery, Result<List<Customer>>>
    {
        public async Task<Result<List<Customer>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            string cacheName = "customers";

            List<Customer> customers;
            customers = cacheService.Get<List<Customer>>(cacheName);
            if (customers is null)
            {
                customers =
                    await customerRepository
                    .GetAll()
                    //.Where(p => request.CustomerTypeValue > 0 && p.CustomerType.Value == request.CustomerTypeValue)
                    .OrderBy(p => p.FirstName)
                     .ThenBy(p => p.LastName)
                    .ToListAsync(cancellationToken);


                cacheService.Set(cacheName, customers);
            }

            return customers;
        }
    }
}

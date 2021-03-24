using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, ReCapProjectContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails()
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from customer in context.Customers
                             join user in context.Users
                             on customer.UserId equals user.Id
                            select new CustomerDetailDto
                             {
                                CustomerId=customer.CustomerId,
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                Email = user.Email,
                                CompanyName=customer.CompanyName
                            };
                return result.ToList();
            }
        }
    }
}

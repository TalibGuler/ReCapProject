using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental,ReCapContext>,IRentalDal
    {
        public Rental GetById(int id)
        {
            using (ReCapContext context = new ReCapContext())
            {
                return context.Rentals.SingleOrDefault(b => b.Id == id);
            }
        }

        public List<RentalDetailDto> GetRentalDetails(Expression<Func<RentalDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Customers
                             on r.CustomerId equals c.CustomerId
                             join u in context.Users
                             on c.UserId equals u.UserId
                             join cr in context.Cars
                             on r.CarId equals cr.CarId
                             join b in context.Brands
                             on cr.BrandId equals b.BrandId
                             join cl in context.Colors
                             on cr.ColorId equals cl.ColorId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CustomerId = c.CustomerId,
                                 CompanyName = c.CompanyName,
                                 UserId = c.UserId,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 Email = u.Email,
                                 CarId = r.CarId,
                                 CarName = cr.CarName,
                                 BrandId = cr.BrandId,
                                 BrandName = b.Name,
                                 ColorId = cr.ColorId,
                                 ColorName = cl.Name,
                                 ModelYear = cr.ModelYear,
                                 DailyPrice = cr.DailyPrice,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return filter == null
                    ? result.ToList()
                    : result.Where(filter).ToList();
            }
        }
    }
}

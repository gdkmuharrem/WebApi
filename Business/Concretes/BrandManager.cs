using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }
        public CreatedBrandResponses Add(CreatedBrandRequest createdBrandRequest)
        {
            // mapping --> automapper kütüphanesi otomatik yapıyor.
            Brand brand = new();
            brand.Name = createdBrandRequest.Name;
            brand.CreatedDate = DateTime.Now;

            _brandDal.Add(brand);

            //mapping = veri tabanından gelen nesneyi direkt olarak son kullanıcıya göstermiyoruz.
            CreatedBrandResponses createdBrandResponse = new CreatedBrandResponses();
            createdBrandResponse.Name = brand.Name;
            createdBrandResponse.Id = 4;
            createdBrandResponse.CreatedDate = brand.CreatedDate;

            return createdBrandResponse;
        }

        public List<GetAllBrandResponse> GetAll()
        {
            List<Brand> brands = _brandDal.GetAll();
            List<GetAllBrandResponse> getAllBrandResponses = new List<GetAllBrandResponse>();
            foreach (var brand in brands)
            {
                GetAllBrandResponse getAllBrandResponse = new GetAllBrandResponse();
                getAllBrandResponse.Name = brand.Name;
                getAllBrandResponse.Id = brand.Id;
                getAllBrandResponse.CreatedDate = brand.CreatedDate;

                getAllBrandResponses.Add(getAllBrandResponse);
            }
            return getAllBrandResponses;

        }


    }
}

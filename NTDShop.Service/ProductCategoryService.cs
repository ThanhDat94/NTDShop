using NTDShop.Data.Infrastructure;
using NTDShop.Data.Repositories;
using NTDShop.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTDShop.Service
{
    public interface IProductCategoryService
    {
        ProductCategory Add(ProductCategory ProductCategory);

        void UpDate(ProductCategory ProductCategory);

        void Delete(ProductCategory ProductCategory);


        void Delete(int ID);

        IEnumerable<ProductCategory> GetAll();

        IEnumerable<ProductCategory> GetAll(string keyWord);
        ProductCategory GetByID(int id);

        void SavChanges();
    }

    public class ProductCategoryService : IProductCategoryService
    {
        private IProductCategoryRepository _ProductCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public ProductCategoryService(IProductCategoryRepository ProductCategoryReposity, IUnitOfWork unitOfWork)
        {
            this._ProductCategoryRepository = ProductCategoryReposity;
            this._unitOfWork = unitOfWork;
        }

        public ProductCategory Add(ProductCategory ProductCategory)
        {
            return _ProductCategoryRepository.Add(ProductCategory);
        }

        public void UpDate(ProductCategory ProductCategory)
        {
            _ProductCategoryRepository.Update(ProductCategory);
        }

        public void Delete(ProductCategory ProductCategory)
        {
            _ProductCategoryRepository.Delete(ProductCategory);
        }

        public void Delete(int ID)
        {
            _ProductCategoryRepository.Delete(ID);
        }

        public IEnumerable<ProductCategory> GetAll()
        {
            return _ProductCategoryRepository.GetAll();
        }

        public ProductCategory GetByID(int id)
        {
            return _ProductCategoryRepository.GetSingleById(id);
        }

        public void SavChanges()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<ProductCategory> GetAll(string keyWord)
        {
            if (!string.IsNullOrEmpty(keyWord))
                return _ProductCategoryRepository.GetMulti(x => x.Name.Contains(keyWord) || x.MetaDescription.Contains(keyWord));
            else
                return _ProductCategoryRepository.GetAll();
        }
    }
}

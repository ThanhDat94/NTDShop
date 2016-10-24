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
    public interface IProductService
    {
        Product Add(Product Product);

        void UpDate(Product Product);

        void Delete(Product Product);


        Product Delete(int ID);

        IEnumerable<Product> GetAll();

        IEnumerable<Product> GetAll(string keyWord);
        Product GetByID(int id);

        void SavChanges();
    }

    public class ProductService : IProductService
    {
        private IProductRepository _ProductRepository;
        private IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository ProductReposity, IUnitOfWork unitOfWork)
        {
            this._ProductRepository = ProductReposity;
            this._unitOfWork = unitOfWork;
        }

        public Product Add(Product Product)
        {
            return _ProductRepository.Add(Product);
        }

        public void UpDate(Product Product)
        {
            _ProductRepository.Update(Product);
        }

        public void Delete(Product Product)
        {
            _ProductRepository.Delete(Product);
        }

        public Product Delete(int ID)
        {
            _ProductRepository.Delete(ID);
            return _ProductRepository.GetSingleById(ID);
        }

        public IEnumerable<Product> GetAll()
        {
            return _ProductRepository.GetAll();
        }

        public Product GetByID(int id)
        {
            return _ProductRepository.GetSingleById(id);
        }

        public void SavChanges()
        {
            _unitOfWork.Commit();
        }

        public IEnumerable<Product> GetAll(string keyWord)
        {
            if (!string.IsNullOrEmpty(keyWord))
                return _ProductRepository.GetMulti(x => x.Name.Contains(keyWord) || x.MetaDescription.Contains(keyWord));
            else
                return _ProductRepository.GetAll();
        }
    }
}

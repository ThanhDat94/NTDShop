using NTDShop.Data.Infrastructure;
using NTDShop.Data.Repositories;
using NTDShop.Model.Models;
using System.Collections.Generic;

namespace NTDShop.Service
{
    public interface IPostCategoryService
    {
        void Add(PostCategory postCategory);

        void UpDate(PostCategory postCategory);

        void Delete(PostCategory postCategory);

        void Delete(int ID);

        IEnumerable<PostCategory> GetAll();

        PostCategory GetByID(int id);

        void SavChanges();
    }

    public class PostCategoryService : IPostCategoryService
    {
        private IPostCategoryRepository _postCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public PostCategoryService(IPostCategoryRepository postCategoryReposity, IUnitOfWork unitOfWork)
        {
            this._postCategoryRepository = postCategoryReposity;
            this._unitOfWork = unitOfWork;
        }

        public void Add(PostCategory postCategory)
        {
            _postCategoryRepository.Add(postCategory);
        }

        public void UpDate(PostCategory postCategory)
        {
            _postCategoryRepository.Update(postCategory);
        }

        public void Delete(PostCategory postCategory)
        {
            _postCategoryRepository.Delete(postCategory);
        }

        public void Delete(int ID)
        {
            _postCategoryRepository.Delete(ID);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return _postCategoryRepository.GetAll();
        }

        public PostCategory GetByID(int id)
        {
            return _postCategoryRepository.GetSingleById(id);
        }

        public void SavChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
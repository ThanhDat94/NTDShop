using NTDShop.Data.Infrastructure;
using NTDShop.Data.Repositories;
using NTDShop.Model.Models;
using System.Collections.Generic;

namespace NTDShop.Service
{
    public interface IPostService
    {
        void Add(Post post);

        void Update(Post post);

        void Delete(int ID);

        IEnumerable<Post> GetAll();

        IEnumerable<Post> GetAllPaging(int page, int pagesize, out int totalrow);

        IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pagesize, int totalrow);

        Post GetByID(int id);

        void SavChanges();
    }

    public class PostService : IPostService
    {
        private IPostRepository _postRepository;
        private IUnitOfWork _unitOfWork;

        public PostService(IPostRepository postRepository, IUnitOfWork unitOfWork)
        {
            this._postRepository = postRepository;
            this._unitOfWork = unitOfWork;
        }

        public void Add(Post post)
        {
            _postRepository.Add(post);
        }

        public void Update(Post post)
        {
            _postRepository.Update(post);
        }

        public void Delete(int ID)
        {
            _postRepository.Delete(ID);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll(new string[] { "PostCategory" });
        }

        public IEnumerable<Post> GetAllPaging(int page, int pagesize, out int totalrow)
        {
            return _postRepository.GetMultiPaging(x => x.Status, out totalrow, page, pagesize);
        }

        public IEnumerable<Post> GetAllByTagPaging(string tag, int page, int pagesize, int totalrow)
        {
            return _postRepository.GetAllByTag(tag, page, pagesize, out totalrow);
        }

        public Post GetByID(int id)
        {
            return _postRepository.GetSingleById(id);
        }

        public void SavChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
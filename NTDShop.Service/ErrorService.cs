using NTDShop.Data.Infrastructure;
using NTDShop.Data.Repositories;
using NTDShop.Model.Models;

namespace NTDShop.Service
{
    public interface IErrorService
    {
        Error Create(Error error);

        void Save();
    }

    public class ErrorService : IErrorService
    {
        private IErrorRepository _errorRepository;
        private IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository errorReprository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorReprository;
            this._unitOfWork = unitOfWork;
        }

        public Error Create(Error error)
        {
            return _errorRepository.Add(error);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
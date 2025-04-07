using Liberos.Api.Interfaces;
using Liberos.Api.Models;

namespace Liberos.Api.Services
{
    public class ContentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ContentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Content> GetAllContents() => _unitOfWork.ContentRepository.GetAll();

        public Content? GetContentById(int id) => _unitOfWork.ContentRepository.Get(c => c.Id == id);
    }
}

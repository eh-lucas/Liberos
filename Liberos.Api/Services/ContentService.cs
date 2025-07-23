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

        public async Task<IEnumerable<Content>> GetAllContentsAsync() => await _unitOfWork.ContentRepository.GetAllAsync();

        public async Task<Content?> GetContentByIdAsync(int id) => await _unitOfWork.ContentRepository.GetAsync(c => c.Id == id);
    }
}

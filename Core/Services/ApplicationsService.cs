using Core.Models;
using Core.Repositories.Abstracts.Interfaces;
using Core.Services.Abstract;

namespace Core.Services
{
    public class ApplicationsService : ServiceBase<Application>
    {
        public ApplicationsService(IUnitOfWork unitOfWork) : base(unitOfWork) { }
    }
}
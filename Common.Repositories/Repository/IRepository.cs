using System.Collections;
using System.Threading.Tasks;
using ForumComments.Models;

namespace ForumComments.Controllers.Repository
{
    public interface IDataRepository
    {
        void Create<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void Update(Comment entity);
        Comment GetId(int Id);
        IEnumerable GetAll();
        Task<bool> SaveAll();
    }
}

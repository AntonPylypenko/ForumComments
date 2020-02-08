using ForumComments.Models;
using System.Collections;
using System.Threading.Tasks;

namespace ElifTechProject.Controllers.Repository
{
    public interface IRepository
    {
        void Create (Comment entity);
        void Delete (Comment entity);
        void Update(Comment entity);
        Comment GetId(int Id);
        IEnumerable GetAll();
        IEnumerable GetAllByName();
    }
}

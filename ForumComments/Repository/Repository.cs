using Common.Events;
using ElifTechProject.Data;
using ForumComments.Models;
using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace ElifTechProject.Controllers.Repository
{
    public class DataRepository  : IRepository
    {
        private readonly CommentContext _context;

        public DataRepository(CommentContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(
                    string.Format(
                    "Repository<{0}>: context == null",
                    typeof(CommentContext).Name));
            }
            this._context = context;
        }

        public event EventHandler<EntityUpdateEventArgs> ItemUpdate;

        protected void OnItemUpdating(EntityUpdateEventArgs args)
        {
            if (ItemUpdate != null)
            {
                ItemUpdate(this, args);
            }
        }
       
        public Comment GetById(int id)
        {
            return _context.Comments.First(e => e.Id == id);
        }

        public void Create(Comment entity) 
        {
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        public void Delete (Comment entity) 
        {
            _context.Comments.Remove(entity);
            _context.SaveChanges();
        }

        public void Update (Comment entity)
        {
            var comment = _context.Comments.FirstOrDefault(x => x.Id == entity.Id);
            comment.Name = entity.Name;
            comment.Country = entity.Country;
            comment.IsPositive = entity.IsPositive;
            comment.Text = entity.Text;
            _context.SaveChanges();

        }

        public Comment GetId(int Id) 
        {
           var comment = _context.Comments.FirstOrDefault( x => x.Id == Id);
           return comment;
        }

        public IEnumerable GetAll()
        {
            var list = _context.Comments.ToList();
            return list;
        }

        public IEnumerable GetAllByName()
        {
            var list = _context.Comments.Select(e => e.Name).ToList();
            return list;
        }

        public event EventHandler<EventArgs> DataSave;
        public event EventHandler<EventArgs> DataLoad;
    }
}

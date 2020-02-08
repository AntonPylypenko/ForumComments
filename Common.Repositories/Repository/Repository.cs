using Common.Events;
using ElifTechProject.Data;
using ElifTechProject.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElifTechProject.Controllers.Repository
{
    public class DataRepository  : IDataRepository
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

        public void Create<T>(T entity) where T : class
        {
            if (entity == null)
                return;
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        public void Update (Comment entity)
        {
            var comment = _context.Comments.FirstOrDefault(x => x.Id == entity.Id);
            comment.AuthName = entity.AuthName;
            comment.Country = entity.Country;
            comment.IsPositive = entity.IsPositive;
            comment.Text = entity.Text;
            comment.AmountOfLikes = entity.AmountOfLikes;
            _context.SaveChanges();

        }

        public Comment GetId(int Id) 
        {
           var comment = _context.Comments.FirstOrDefault( x => x.Id == Id);
           return comment;
        }

        IEnumerable IDataRepository.GetAll()
        {
            var list = _context.Comments.ToList();
            return list;
        }

        public Task<bool> SaveAll()
        {
            throw new NotImplementedException();
        }

        public event EventHandler<EventArgs> DataSave;
        public event EventHandler<EventArgs> DataLoad;
    }
}

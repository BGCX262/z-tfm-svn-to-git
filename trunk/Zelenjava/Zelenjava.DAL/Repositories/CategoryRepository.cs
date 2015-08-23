using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Srida.DAL;
using Zelenjava.Model.Entities;
using Zelenjava.Model.RepositoryInterfaces;

namespace Zelenjava.DAL.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        public void Create(Category entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(entity);
                        transaction.Commit();
                    }
                    catch (NHibernate.ADOException)
                    {
                        throw new Exception("Defined category already exists");
                    }
                }
            }
        }

        public Category Read(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                Category category = session.Get<Category>(id);

                if (category == null)
                {
                    throw new Exception("Defined category doesn't exist");
                }

                return category;
            }
        }

        public void Update(Category entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Update(entity);
                        transaction.Commit();
                    }
                    catch (ADOException)
                    {
                        throw new Exception("Unable to update category");
                    }
                }
            }
        }

        public void Delete(Category entity)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(entity);
                        transaction.Commit();
                    }
                    catch (ADOException)
                    {
                        throw new Exception("Defined category doesn't exist");
                    }
                }
            }
        }

        public IList<Category> ReadAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IQuery query = session.CreateQuery("from Category");
                IList<Category> categories = query.List<Category>();
                return categories;
            }
        }
    }
}

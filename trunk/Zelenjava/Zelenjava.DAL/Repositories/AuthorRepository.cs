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
    public class AuthorRepository:IAuthorRepository
    {
        public void Create(Author entity)
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
                        throw new Exception("Defined author already exists");
                    }
                }
            }
        }

        public Author Read(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                Author author = session.Get<Author>(id);

                if (author == null)
                {
                    throw new Exception("Defined author doesn't exist");
                }

                return author;
            }
        }

        public void Update(Author entity)
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
                        throw new Exception("Unable to update author");
                    }
                }
            }
        }

        public void Delete(Author entity)
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
                        throw new Exception("Defined author doesn't exist");
                    }
                }
            }
        }

        public IList<Author> ReadAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IQuery query = session.CreateQuery("from Author");
                IList<Author> authors = query.List<Author>();
                return authors;
            }
        }
    }
}

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
    public class ArticleRepository:IArticleRepository
    {
        public void Create(Article entity)
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
                        throw new Exception("Defined article already exists");
                    }
                }
            }
        }

        public Article Read(int id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                Article article = session.Get<Article>(id);

                if (article == null)
                {
                    throw new Exception("Defined article doesn't exist");
                }

                return article;
            }
        }

        public void Update(Article entity)
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
                        throw new Exception("Unable to update article");
                    }
                }
            }
        }

        public void Delete(Article entity)
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
                        throw new Exception("Defined article doesn't exist");
                    }
                }
            }
        }

        public IList<Article> ReadAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                IQuery query = session.CreateQuery("from Article");
                IList<Article> articles = query.List<Article>();
                return articles;
            }
        }
    }
}

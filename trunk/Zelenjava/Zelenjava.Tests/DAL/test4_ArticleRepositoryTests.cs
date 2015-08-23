using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Zelenjava.DAL.Repositories;
using Zelenjava.Model.Entities;
using Zelenjava.Model.RepositoryInterfaces;

namespace Zelenjava.Tests.DAL
{
    [TestClass]
    public class test4_ArticleRepositoryTests
    {
        [TestMethod]
        public void A_CreateArticle()
        {
            IRepository<Category> categoryRep = new CategoryRepository();
            Category category = categoryRep.Read(1);

            IRepository<Author> authorRep = new AuthorRepository();
            Author author = authorRep.Read(1);

            #region Read photo from file

            FileInfo fileInfo = new FileInfo(@"..\..\..\..\..\DAL\Resources\Chrysanthemum.jpg");
            FileStream fileStream = fileInfo.OpenRead();
            long length = fileStream.Length;

            byte[] photoData = null;

            if (length > 0)
            {
                photoData = new byte[length];
            }

            fileStream.Read(photoData, 0, Convert.ToInt32(length));
            fileStream.Close();

            #endregion

            Photo photo1 = new Photo(PhotoType.Large, "testName", photoData);
            Photo photo2 = new Photo(PhotoType.Medium, "testName", photoData);
            Photo photo3 = new Photo(PhotoType.Small, "testName", photoData);
            List<Photo> photos = new List<Photo>();
            photos.Add(photo1);
            photos.Add(photo2);
            photos.Add(photo3);

            Article article = new Article("testName", "testName", "testName", "testName", "testName", "testName", "testName", true, true, true, category, author, photos);
            
            IRepository<Article> articleRep = new ArticleRepository();
            articleRep.Create(article);
        }

        [TestMethod]
        public void B_ReadArticle()
        {
            IRepository<Article> articleRep = new ArticleRepository();

            Article article = articleRep.Read(1);
            Assert.IsNotNull(article);
        }

        [TestMethod]
        public void C_UpdateArticle()
        {
            A_CreateArticle();
           
            IRepository<Article> articleRep = new ArticleRepository();

            Article article = articleRep.Read(2);

            article.TitleHr = "updatedName";
            articleRep.Update(article);

            Assert.AreEqual("updatedName", articleRep.Read(2).TitleHr);
        }

        [TestMethod]
        public void D_ReadAllArticles()
        {
            IRepository<Article> articleRep = new ArticleRepository();

            List<Article> articles = articleRep.ReadAll().ToList();
            Assert.AreEqual(2, articles.Count);
        }

        [TestMethod]
        public void E_DeleteArticle()
        {
            IRepository<Article> articleRep = new ArticleRepository();

            Article article = articleRep.Read(2);
            articleRep.Delete(article);
        }
    }
}

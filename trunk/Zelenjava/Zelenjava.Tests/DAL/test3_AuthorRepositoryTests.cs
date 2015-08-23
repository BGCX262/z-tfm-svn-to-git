using System;
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
    public class test3_AuthorRepositoryTests
    {
        [TestMethod]
        public void A_CreateAuthor()
        {
            Author author = new Author("testname", "testName");

            IRepository<Author> authorRep = new AuthorRepository();
            authorRep.Create(author);
        }

        [TestMethod]
        public void B_ReadAuthor()
        {
            IRepository<Author> authorRep = new AuthorRepository();

            Author author = authorRep.Read(1);
            Assert.IsNotNull(author);
        }

        [TestMethod]
        public void C_UpdateAuthor()
        {
            A_CreateAuthor();

            IRepository<Author> authorRep = new AuthorRepository();

            Author author = authorRep.Read(2);
            author.FirstName = "updatedName";
            authorRep.Update(author);

            Assert.AreEqual("updatedName", authorRep.Read(2).FirstName);
        }

        [TestMethod]
        public void D_ReadAllAuthors()
        {
            IRepository<Author> authorRep = new AuthorRepository();

            List<Author> authors = authorRep.ReadAll().ToList();
            Assert.AreEqual(2, authors.Count);
        }

        [TestMethod]
        public void E_DeleteAuthor()
        {
            IRepository<Author> authorRep = new AuthorRepository();

            Author author = authorRep.Read(2);
            authorRep.Delete(author);
        }
    }
}

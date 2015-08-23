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
    public class test2_CategoryRepositoryTests
    {
        [TestMethod]
        public void A_CreateCategory()
        {
            Category category = new Category("testName");

            IRepository<Category> categoryRep = new CategoryRepository();
            categoryRep.Create(category);
        }

        [TestMethod]
        public void B_ReadCategory()
        {
            IRepository<Category> categoryRep = new CategoryRepository();

            Category category = categoryRep.Read(1);
            Assert.IsNotNull(category);
        }

        [TestMethod]
        public void C_UpdateCategory()
        {
            A_CreateCategory();

            IRepository<Category> categoryRep = new CategoryRepository();

            Category category = categoryRep.Read(2);
            category.Name = "updatedName";
            categoryRep.Update(category);

            Assert.AreEqual("updatedName", categoryRep.Read(2).Name);
        }

        [TestMethod]
        public void D_ReadAllCategories()
        {
            IRepository<Category> categoryRep = new CategoryRepository();

            List<Category> categories = categoryRep.ReadAll().ToList();
            Assert.AreEqual(2, categories.Count);
        }

        [TestMethod]
        public void E_DeleteCategory()
        {
            IRepository<Category> categoryRep = new CategoryRepository();

            Category category = categoryRep.Read(2);
            categoryRep.Delete(category);
        }
    }
}

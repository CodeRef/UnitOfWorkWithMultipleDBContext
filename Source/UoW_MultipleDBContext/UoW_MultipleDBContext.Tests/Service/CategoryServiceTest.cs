using Autofac;
using AutofacContrib.NSubstitute;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UoW_MultipleDBContext.Data.DBContexts;
using UoW_MultipleDBContext.Data.Infrastructure;
using UoW_MultipleDBContext.Data.UnitOfWork;
using UoW_MultipleDBContext.Entity;
using UoW_MultipleDBContext.Service;

namespace UoW_MultipleDBContext.Tests.Unit.Data.Repositories
{
    public class CategoryServiceTest
    {
        public AutoSubstitute AutoSubstitute { get; private set; }
        [SetUp]
        public void Init()
        {
            AutoSubstitute = new AutoSubstitute();

            // Register commonlog module
            AutoSubstitute = new AutoSubstitute((builder) =>
            {
                builder.RegisterGeneric(typeof(UnitOfWork<>)).As(typeof(IUnitOfWork<>));
                builder.RegisterType<FirstDbContext>().InstancePerLifetimeScope();
            });
        }

        [Test]
        public void GetCategoryWithExpenses_EmptyDB_CountIsZero()
        {
            var data = new List<Category>().AsEnumerable();
            var repoBase = this.AutoSubstitute.SubstituteFor<IRepository<Category>>();
            repoBase.GetAll().Returns(data);
            // Act
            var action = this.AutoSubstitute.Resolve<CategoryService>().CallRightOne();

            // Assert 
            Assert.AreEqual(0, action.ToList().Count());
        }
    }
}

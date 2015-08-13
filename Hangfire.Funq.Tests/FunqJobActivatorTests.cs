using Funq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangfire.Funq.Tests
{
    [TestClass]
    public class FunqJobActivatorTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void New_FunqJobActivator_Given_Null_Container_Throws_ArgumentNullException()
        {
            var activator = new FunqJobActivator(null);
        }

        [TestMethod]
        public void New_FunqJobActivator_Given_Container_Should_Resolve_Job()
        {
            var dummyJob = new DummyJob();

            var container = new Container();
            container.Register<DummyJob>(dummyJob);

            var activator = new FunqJobActivator(container);

            var returnedJob = activator.ActivateJob(typeof(DummyJob));

            Assert.AreEqual(dummyJob, returnedJob);
        }
    }
}
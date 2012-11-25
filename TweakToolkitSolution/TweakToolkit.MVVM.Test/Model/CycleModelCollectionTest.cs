using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TweakToolkit.MVVM.Model;
using TweakToolkit.MVVM.Test.Service;

namespace TweakToolkit.MVVM.Test.Model
{
    [TestClass]
    public class CycleModelCollectionTest
    {
        [TestMethod]
        public void CreateEntity_WithoutMultiplicityConstraints()
        {
            IServiceProvider provider = new TweakTestDataServiceProvider();
            var collection = new CycleModelCollection(provider);

            while (collection.Reading)
            {
                Thread.Sleep(200);
            }

            var cycleModel = new CycleModel();
            collection.Add(cycleModel);
            cycleModel.Gears = 21;
            collection.Save();
        }

        [TestMethod]
        public void CreateEntity_WithMultiplicityConstraints()
        {
            IServiceProvider provider = new TweakTestDataServiceProvider();
            var collection = new CycleModelCollection(provider);
            var cycleModel = new CycleModel { Gears = 30 };
            collection.Add(cycleModel);
        }
    }
}
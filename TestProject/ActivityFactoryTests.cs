 

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImplementationOfObjectOrientedDesigns.Domain;
using System.Collections;

namespace TestProject
{
    [TestClass]
    public class ActivityFactoryTests
    {
        [TestMethod]
        public void TestFactoryGetInstance()
        {
            Assert.IsInstanceOfType(ActivityFactory.GetInstance, typeof(ActivityFactory));
        }

        [TestMethod]
        public void TestFactoryRegisterSucceeds()
        {
            ActivityFactory factory = ActivityFactory.GetInstance;
            PrivateObject privateAccessor = new PrivateObject(factory);
            WallClimbingActivity wallActivity = new WallClimbingActivity();
            ChoclateProducingAndMarketingActivity chocoActivity = new ChoclateProducingAndMarketingActivity();
            TeamBuildingAndProblemSolvingActivity teamActivity = new TeamBuildingAndProblemSolvingActivity();
            MeditationAndMindfullnessActivity mediActivity = new MeditationAndMindfullnessActivity();
            GoKartActivity goKartActivity = new GoKartActivity();

            factory.Register(ActivityTypes.WALL_CLIMBING, wallActivity);
            factory.Register(ActivityTypes.TEAM_BUILDING_AND_PROBLEM_SOLVING, teamActivity);
            factory.Register(ActivityTypes.CHOCOLATE_PRODUCING_AND_MARKETING, chocoActivity);
            factory.Register(ActivityTypes.MEDITATION_AND_MINDFULLNESS, mediActivity);
            factory.Register(ActivityTypes.GO_KART, goKartActivity);
            Hashtable refActivityMap = (Hashtable)privateAccessor.GetField("activityTable");
            Assert.IsTrue(refActivityMap.ContainsKey(ActivityTypes.WALL_CLIMBING));
            Assert.IsTrue(refActivityMap.ContainsKey(ActivityTypes.TEAM_BUILDING_AND_PROBLEM_SOLVING));
            Assert.IsTrue(refActivityMap.ContainsKey(ActivityTypes.CHOCOLATE_PRODUCING_AND_MARKETING));
            Assert.IsTrue(refActivityMap.ContainsKey(ActivityTypes.MEDITATION_AND_MINDFULLNESS));
            Assert.IsTrue(refActivityMap.ContainsKey(ActivityTypes.GO_KART));
        }

        [TestMethod]
        public void TestFactoryCreateActivityReturnsInstanceOfRegisteredActivityType()
        {
            ActivityFactory factory = ActivityFactory.GetInstance;
            factory.Register(ActivityTypes.GO_KART, new GoKartActivity());

           Assert.IsInstanceOfType(factory.CreateActivity(ActivityTypes.GO_KART, "An ID", 10.0M), typeof(GoKartActivity));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Activity does not exists. Has it been registered?")]
        public void TestFactoryCreateActivityRaisesArguementException()
        {
            ActivityFactory factory = ActivityFactory.GetInstance;
            PrivateObject privateAccessor = new PrivateObject(factory);
            privateAccessor.SetField("activityTable", new Hashtable());
            factory.CreateActivity(ActivityTypes.GO_KART, "An ID", 10.0M);
        }
    }
}

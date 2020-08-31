///Chris Aston, Carlton Evans, Sam Noble

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ImplementationOfObjectOrientedDesigns.Domain;

namespace TestProject
{
    [TestClass]
    public class ActivitiesTests
    {
        [TestMethod]
        public void TestChocolateProducingAndMarketActivityIDCostConstructor()
        {
            ChoclateProducingAndMarketingActivity activity = new ChoclateProducingAndMarketingActivity("ID", 10.0M);

            Assert.AreEqual<string>("ID", activity.ID);
            Assert.AreEqual<decimal>(10.0M, activity.cost);
            Assert.AreEqual<string>("Choclate Producing and Marketing", activity.activityName);
        }

        [TestMethod]
        public void TestChocolateProducingAndMarketActivityConstructor()
        {
            ChoclateProducingAndMarketingActivity activity = new ChoclateProducingAndMarketingActivity();

            Assert.AreEqual<string>("", activity.ID);
            Assert.AreEqual<decimal>(0, activity.cost);
            Assert.AreEqual<string>("", activity.activityName);
        }

        [TestMethod]
        public void TestChocolateProducingAndMarketingActivityCreateActivity()
        {
            ChoclateProducingAndMarketingActivity activity = new ChoclateProducingAndMarketingActivity();
            Assert.IsInstanceOfType(activity.CreateActivity("id", 10.0M), typeof(ChoclateProducingAndMarketingActivity));
        }

        [TestMethod]
        public void TestMeditationAndMindfulnessActivityIDCostConstructor()
        {
            MeditationAndMindfullnessActivity activity = new MeditationAndMindfullnessActivity("ID", 500.0M);

            Assert.AreEqual<string>("ID", activity.ID);
            Assert.AreEqual<decimal>(500.0M, activity.cost);
            Assert.AreEqual<string>("Meditation and Mindfullness Workshop", activity.activityName);
        }

        [TestMethod]
        public void TestMeditationAndMindfulnessActivityConstructor()
        {
            MeditationAndMindfullnessActivity activity = new MeditationAndMindfullnessActivity();

            Assert.AreEqual<string>("", activity.ID);
            Assert.AreEqual<decimal>(0, activity.cost);
            Assert.AreEqual<string>("", activity.activityName);
        }

        [TestMethod]
        public void TestMeditationAndMindfulnessActivityCreateActivity()
        {
            MeditationAndMindfullnessActivity activity = new MeditationAndMindfullnessActivity();
            Assert.IsInstanceOfType(activity.CreateActivity("ID", 20.0M), typeof(MeditationAndMindfullnessActivity));
        }

        [TestMethod]
        public void TestWallClimbingActivityIDCostConstructor()
        {
            WallClimbingActivity activity = new WallClimbingActivity("ID", 700.0M);

            Assert.AreEqual<string>("ID", activity.ID);
            Assert.AreEqual<decimal>(700.0M, activity.cost);
            Assert.AreEqual<string>("Wall Climbing", activity.activityName);
        }

        [TestMethod]
        public void TestWallClimbingActivityConstructor()
        {
            WallClimbingActivity activity = new WallClimbingActivity();

            Assert.AreEqual<string>("", activity.ID);
            Assert.AreEqual<decimal>(0, activity.cost);
            Assert.AreEqual<string>("", activity.activityName);
        }

        public void TestWallClimbingActivityCreateActivity()
        {
            WallClimbingActivity activity = new WallClimbingActivity();
            Assert.IsInstanceOfType(activity.CreateActivity("ID", 10.0M), typeof(WallClimbingActivity));
        }

        [TestMethod]
        public void TestGoKartIDCostConstructor()
        {
            GoKartActivity activity = new GoKartActivity("ID", 1400.0M);

            Assert.AreEqual<string>("ID", activity.ID);
            Assert.AreEqual<decimal>(1400.0M, activity.cost);
            Assert.AreEqual<string>("Go Kart", activity.activityName);
        }

        [TestMethod]
        public void TestGoKartConstructor()
        {
            GoKartActivity activity = new GoKartActivity();

            Assert.AreEqual<string>("", activity.ID);
            Assert.AreEqual<decimal>(0, activity.cost);
            Assert.AreEqual<string>("", activity.activityName);
        }

        [TestMethod]
        public void TestGoKartActivityCreateActivity()
        {
            GoKartActivity activity = new GoKartActivity();
            Assert.IsInstanceOfType(activity.CreateActivity("ID", 32.0M), typeof(GoKartActivity));
        }

        [TestMethod]
        public void TestTeamBuildingIDCostConstructor()
        {
            TeamBuildingAndProblemSolvingActivity activity = new TeamBuildingAndProblemSolvingActivity("ID", 10.0M);

            Assert.AreEqual<string>("ID", activity.ID);
            Assert.AreEqual<decimal>(10.0M, activity.cost);
            Assert.AreEqual<string>("Team Building and Outdoor Problem Solving", activity.activityName);
        }

        [TestMethod]
        public void TestTeamBuildingConstructor()
        {
            TeamBuildingAndProblemSolvingActivity activity = new TeamBuildingAndProblemSolvingActivity();

            Assert.AreEqual<string>("", activity.ID);
            Assert.AreEqual<decimal>(0, activity.cost);
            Assert.AreEqual<string>("", activity.activityName);
        }

        [TestMethod]
        public void TestTeamBuildingActivityCreateActivity()
        {
            TeamBuildingAndProblemSolvingActivity activity = new TeamBuildingAndProblemSolvingActivity();
            Assert.IsInstanceOfType(activity.CreateActivity("ID", 10.0M), typeof(TeamBuildingAndProblemSolvingActivity));
        }
    }
}

 

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementationOfObjectOrientedDesigns.Domain
{
    [NotMapped]
    public class ChoclateProducingAndMarketingActivity : Activity
    {
        public ChoclateProducingAndMarketingActivity()
        {
            this.ID = "";
            this.cost = 0;
            this.activityName = "";
        }

        public ChoclateProducingAndMarketingActivity(string id, decimal cost)
        {
            if (String.IsNullOrEmpty(id) || cost < 0.0M)
            {
                throw new Exception("Illegal arguements");
            }

            this.ID = id;
            this.cost = cost;
            this.activityName = "Choclate Producing and Marketing";
        }

        public override IActivity CreateActivity(string id, decimal cost)
        {
            return new ChoclateProducingAndMarketingActivity(id, cost);
        }
    }

    [NotMapped]
    public class TeamBuildingAndProblemSolvingActivity : Activity
    {
        public TeamBuildingAndProblemSolvingActivity()
        {
            this.ID = "";
            this.cost = 0;
            this.activityName = "";
        }

        public TeamBuildingAndProblemSolvingActivity(string id, decimal cost)
        {
            if (String.IsNullOrEmpty(id) || cost < 0.0M)
            {
                throw new Exception("Illegal arguements");
            }

            this.ID = id;
            this.cost = cost;
            this.activityName = "Team Building and Outdoor Problem Solving";
        }

        public override IActivity CreateActivity(string id, decimal cost)
        {
            return new TeamBuildingAndProblemSolvingActivity(id, cost);
        }
    }

    [NotMapped]
    public class MeditationAndMindfullnessActivity : Activity
    {
        public MeditationAndMindfullnessActivity()
        {
            this.ID = "";
            this.cost = 0;
            this.activityName = "";
        }

        public MeditationAndMindfullnessActivity(string id, decimal cost)
        {
            if (String.IsNullOrEmpty(id) || cost < 0.0M)
            {
                throw new Exception("Illegal arguements");
            }

            this.ID = id;
            this.cost = cost;
            this.activityName = "Meditation and Mindfullness Workshop";
        }

        public override IActivity CreateActivity(string id, decimal cost)
        {
            return new MeditationAndMindfullnessActivity(id, cost);
        }
    }

    [NotMapped]
    public class WallClimbingActivity : Activity
    {
        public WallClimbingActivity()
        {
            this.ID = "";
            this.cost = 0;
            this.activityName = "";
        }

        public WallClimbingActivity(string id, decimal cost)
        {
            if (String.IsNullOrEmpty(id) || cost < 0.0M)
            {
                throw new Exception("Illegal arguements");
            }

            this.ID = id;
            this.cost = cost;
            this.activityName = "Wall Climbing";
        }

        public override IActivity CreateActivity(string id, decimal cost)
        {
            return new WallClimbingActivity(id, cost);
        }
    }

    [NotMapped]
    public class GoKartActivity : Activity
    {
        public GoKartActivity()
        {
            this.ID = "";
            this.cost = 0;
            this.activityName = "";
        }

        public GoKartActivity(string id, decimal cost)
        {
            if (String.IsNullOrEmpty(id) || cost < 0.0M)
            {
                throw new Exception("Illegal arguements");

            }
            this.ID = id;
            this.cost = cost;
            this.activityName = "Go Kart";
        }

        public override IActivity CreateActivity(string id, decimal cost)
        {
            return new GoKartActivity(id, cost);
        }
    }
}

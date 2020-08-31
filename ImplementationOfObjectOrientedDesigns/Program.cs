///Chris Aston, Carlton Evans, Sam Noble

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImplementationOfObjectOrientedDesigns.Presentation;
using ImplementationOfObjectOrientedDesigns.Domain;
using ImplementationOfObjectOrientedDesigns.Utilities;
using ImplementationOfObjectOrientedDesigns.DataAccess;

namespace ImplementationOfObjectOrientedDesigns
{

    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            VenueFactory venueFactory = VenueFactory.GetInstance;
            venueFactory.Register(VenueAddOns.AFTERNOON_REFRESHMENTS, new VenueAfternoonRefreshments());
            venueFactory.Register(VenueAddOns.BUS_TRANSPORTS, new VenueBusTransport());
            venueFactory.Register(VenueAddOns.EVENING_MEAL, new VenueEveningMeal());
            venueFactory.Register(VenueAddOns.MIDDAY_LUNCH, new VenueMiddayLunch());
            venueFactory.Register(VenueAddOns.MORNING_REFRESHMENTS, new VenueMorningRefreshments());


            ActivityFactory activityFactory = ActivityFactory.GetInstance;
            activityFactory.Register(ActivityTypes.GO_KART, new GoKartActivity());
            activityFactory.Register(ActivityTypes.WALL_CLIMBING, new WallClimbingActivity());
            activityFactory.Register(ActivityTypes.CHOCOLATE_PRODUCING_AND_MARKETING, new ChoclateProducingAndMarketingActivity());
            activityFactory.Register(ActivityTypes.MEDITATION_AND_MINDFULLNESS, new MeditationAndMindfullnessActivity());
            activityFactory.Register(ActivityTypes.TEAM_BUILDING_AND_PROBLEM_SOLVING, new TeamBuildingAndProblemSolvingActivity());


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BookingGUI gui = new BookingGUI();
            new BookingPresenter(gui);
            Application.Run(gui);           
        }
    }
}

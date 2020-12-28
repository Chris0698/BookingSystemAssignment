 

using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImplementationOfObjectOrientedDesigns.Utilities;

namespace ImplementationOfObjectOrientedDesigns.Domain
{
    public class ActivityFactory
    {
        private Hashtable activityTable = new Hashtable();
        private static ActivityFactory instance;

        private ActivityFactory()
        {

        }

        public static ActivityFactory GetInstance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ActivityFactory();
                }

                return instance;
            }  
        }


        public void Register(ActivityTypes activityType, IActivity activity)
        {
            //activity type cant be null

            if(activity == null)
            {
                throw new ArgumentNullException("Activity cannot be null.");
            }


            if(!activityTable.ContainsKey(activityType))
            {
                activityTable[activityType] = activity;
            }
        }

        public IActivity CreateActivity(ActivityTypes activityType, string id, decimal cost)
        {
            //activity type cant be null

            IActivity activity = null;

            if(activityTable.ContainsKey(activityType))
            {
                activity = (Activity)activityTable[activityType];
            }
            else
            {
                throw new ArgumentException("Activity does not exist. Has it been registered?");
            }

            return activity.CreateActivity(id, cost);
        }
    }
}

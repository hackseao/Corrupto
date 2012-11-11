using System;
using System.Configuration;
using System.Net;
using System.Web;
using System.Web.Caching;

namespace Corrupto.Logic
{
    /// <summary>
    /// What a hackjob... :S
    /// </summary>
    public class Scheduler
    {
        private const string AppKey = "CorruptoToggle";
        private const string CacheKey = "Corrupto";
        private static readonly TimeSpan ExecutionInterval = TimeSpan.FromSeconds(Convert.ToInt32(ConfigurationManager.AppSettings["executionInterval"]));

        public static bool ToggledOn
        {
            get
            {
                return (bool) HttpContext.Current.Application[AppKey];
            }
            set
            {
                HttpContext.Current.Application[AppKey] = value;
            }
        }

        public static void Schedule()
        {
            if(ToggledOn)
            {
                HttpContext.Current.Cache.Add(CacheKey, "Corrupto was here!", null, DateTime.Now.Add(ExecutionInterval), Cache.NoSlidingExpiration, CacheItemPriority.Default, new CacheItemRemovedCallback(Scheduler.Hit));
            }
        }
      
        public static void Start()
        {
            System.Diagnostics.Debug.WriteLine(String.Format("[{0}] Start!", DateTime.Now.TimeOfDay.ToString()));
            ToggledOn = true;
            Hit(String.Empty, null, CacheItemRemovedReason.Expired);
        }

        public static void Stop()
        {
            System.Diagnostics.Debug.WriteLine(String.Format("[{0}] Stop!", DateTime.Now.TimeOfDay.ToString()));
            ToggledOn = false;
        }

        private static void Hit(string s, object o, CacheItemRemovedReason reason)
        {
            string path = ConfigurationManager.AppSettings["hitPath"];

            WebClient request = new WebClient();
            request.DownloadData(path);
        }
        
    }
}

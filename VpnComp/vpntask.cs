using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Vpn;
using Windows.ApplicationModel.Background;
using Windows.ApplicationModel.Core;
using System.Diagnostics;


using Windows.UI.Notifications;
namespace VpnComp
{
    public sealed class vpntask : IBackgroundTask
    {
       
        public vpntask()
        {

        }

        public void Run(IBackgroundTaskInstance taskInstance)
        {
 
            
            BackgroundTaskDeferral def = taskInstance.GetDeferral();
            

         
            VpnPlgin plg = new VpnPlgin();
   
            VpnChannel.ProcessEventAsync(plg, taskInstance.TriggerDetails);
           
        }
    }

  
}

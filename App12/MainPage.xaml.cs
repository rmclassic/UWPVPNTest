using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.ApplicationModel.Core;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Networking.Vpn;
using Windows.Foundation.Metadata;
using Windows.Networking;
using Windows.ApplicationModel.Background;
using Windows.UI.Core;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VpnComp
{
   
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

       

        public MainPage()
        {
            bool tasked = false;

            var e  = SystemNavigationManager.GetForCurrentView();

            e.AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;

            this.InitializeComponent();
            
        }


        public static BackgroundTaskRegistration RegisterTask(string TaskEntryPoint, string Name, IBackgroundTrigger trigger, IBackgroundCondition condition)
        {
            foreach (var cur in BackgroundTaskRegistration.AllTasks)
            {

                if (cur.Value.Name == Name)
                {
                    //
                    // The task is already registered.
                    //

                    return (BackgroundTaskRegistration)(cur.Value);
                }
            }

            //
            // Register the background task.
            //

            var builder = new BackgroundTaskBuilder();

            builder.Name = Name;

            // in-process background tasks don't set TaskEntryPoint
            if (TaskEntryPoint != null && TaskEntryPoint != String.Empty)
            {
                builder.TaskEntryPoint = TaskEntryPoint;
            }
            builder.SetTrigger(trigger);

            if (condition != null)
            {
                builder.AddCondition(condition);
            }

            BackgroundTaskRegistration task = builder.Register();

            return task;
        }

     


     


        class VPNProfile : IVpnProfile
        {
             string profilename;

            public IList<VpnDomainNameInfo> DomainNameInfoList => throw new NotImplementedException();

            public string ProfileName { get { return profilename; } set { profilename = value; } }
            public bool RememberCredentials { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            public IList<VpnRoute> Routes => throw new NotImplementedException();

            public IList<VpnTrafficFilter> TrafficFilters => throw new NotImplementedException();

            bool IVpnProfile.AlwaysOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

            IList<VpnAppId> IVpnProfile.AppTriggers { get { return null; } }
        }

        class MyVPN : IVpnPlugIn
        {
            public void Connect(VpnChannel channel)
            {
                
            }

            public void Disconnect(VpnChannel channel)
            {
                throw new NotImplementedException();
            }

            public void GetKeepAlivePayload(VpnChannel channel, out VpnPacketBuffer keepAlivePacket)
            {
                throw new NotImplementedException();
            }

            public void Encapsulate(VpnChannel channel, VpnPacketBufferList packets, VpnPacketBufferList encapulatedPackets)
            {
                throw new NotImplementedException();
            }

            public void Decapsulate(VpnChannel channel, VpnPacketBuffer encapBuffer, VpnPacketBufferList decapsulatedPackets, VpnPacketBufferList controlPacketsToSend)
            {
                throw new NotImplementedException();
            }
        }
    }
}

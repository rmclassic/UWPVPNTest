using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.Vpn;
using Windows.Security.Credentials;
using Windows.Networking.Sockets;
using Windows.Security.Cryptography.Certificates;
using Windows.Networking;
using System.Net.Sockets;


namespace VpnComp
{
    
    class VpnCred : IVpnCredential
    {
        string additionalpin;
        Certificate certificatecredential;
        PasswordCredential oldpass;
        PasswordCredential passkey;
        public string AdditionalPin { set { additionalpin = value; } get { return additionalpin; } }

        public Certificate CertificateCredential { set { certificatecredential = value; } get { return certificatecredential; } }

        public PasswordCredential OldPasswordCredential { set { oldpass = value; } get { return oldpass; } }

        public PasswordCredential PasskeyCredential { set { passkey = value; } get { return passkey; } }
    }
    class VpnPlgin : IVpnPlugIn
    {
        public void Connect(VpnChannel channel)
        {

            List<HostName> hosts = new List<HostName>();
            hosts.Add(new HostName("216.58.208.46"));

            StreamSocket streamsock = new StreamSocket();




            VpnRouteAssignment vpr = new VpnRouteAssignment();
            vpr.ExcludeLocalSubnets = true;
            VpnNamespaceAssignment na = new VpnNamespaceAssignment();
            
            VpnInterfaceId id = new VpnInterfaceId(Encoding.ASCII.GetBytes("1"));
            channel.AssociateTransport(streamsock, null);
            //channel.TerminateConnection("FUCKU");
            try
            {
                channel.Start(null, null, id, vpr, na, 512, 512, true, streamsock, null);
                VpnPacketBuffer buf = channel.GetVpnReceivePacketBuffer();
            }
            catch (Exception e)
            {
                return;
            }
     
        }

        private void Channel_ActivityStateChange(VpnChannel sender, VpnChannelActivityStateChangedArgs args)
        {
            throw new NotImplementedException();
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
            Task.Delay(12);
        }

        public void Decapsulate(VpnChannel channel, VpnPacketBuffer encapBuffer, VpnPacketBufferList decapsulatedPackets, VpnPacketBufferList controlPacketsToSend)
        {
            throw new NotImplementedException();
        }
        
    }
}

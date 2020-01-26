using System;
using System.Net.Sockets;
using System.Net;
using System.Linq;
using System.Collections.Generic;
using System.Web;
using System.Text;

namespace WakeMain {
    public static class MainCode {
        public static int SendPort = 9;
        static UdpClient GlobalUdp = new UdpClient();
        static IPAddress Mask = IPAddress.Parse("255.255.255.255");
        static IPEndPoint SendPonitInfo = new IPEndPoint(Mask, SendPort);
        public static byte[] MakeMagicPacket(String Mac_Address)
        {
            String Header_Stream = "FFFFFFFFFFFF";
            byte[] SendPacket = new byte[102];
            byte[] MacgicHex = new byte[Mac_Address.Length / 2];
            for (int i = 0; i < 6; i++)
            {
                SendPacket[i] = Convert.ToByte(Header_Stream.Substring(i*2,2),16);
            }
            for (int j = 0; j < MacgicHex.Length; j++)
            {
                MacgicHex[j] = Convert.ToByte(Mac_Address.Substring(j*2,2),16);
            }
            for (int k = 6; k < 102; k++)
            {
                SendPacket[k] = MacgicHex[k % 6];
            }
            return SendPacket;
        }
        public  static void WakeMachine(String Mac_Text) {
            byte[] RawPacket = MakeMagicPacket(Mac_Text);

            GlobalUdp.Send(RawPacket,RawPacket.Length,SendPonitInfo);
        }
        public  static void CloseMachines()
        {
            byte[] SendClosePoint = Encoding.Default.GetBytes("off");
            MainCode.SendPort = 7856;
            MainCode.SendPonitInfo = new IPEndPoint(Mask,SendPort);
            GlobalUdp.Send(SendClosePoint,SendClosePoint.Length,SendPonitInfo);
        }

    }
}
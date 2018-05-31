using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Flurl.Http;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace VKApi
{

    class Program
    {
        //private static readonly HttpClient client = new HttpClient();
        private const string home = "http://94.31.140.217:8000/";
        private static string autrize_request = "https://oauth.vk.com/authorize?client_id=6495077&display=page&scope=4098&response_type=code&v=5.78";
        //private static string code = null;
        //private static string token = null;
        private static string secret = "nBDKAxM9kSRGRGsVOxv4";
        static void Main(string[] args)
        {
            System.Diagnostics.Process.Start(autrize_request);
            var code = Console.ReadLine();
            var res = String.Format("https://oauth.vk.com/access_token?client_id=6495077&client_secret={0}&code={1}", secret, code).GetAsync().Result;
            Console.WriteLine(res);
            var token = res.Content.ReadAsStringAsync().Result.Split(new []{'"'},5)[3];
            res = String.Format("https://api.vk.com/method/messages.send?chat_id=25&message=Test%20with%20Flurl&access_token={0}&v=5.78",token).GetAsync().Result;
            for(int i=0;i<1000;i++)
                res=String.Format("https://api.vk.com/method/messages.send?chat_id=25&message=Test%20with%20Flurl&access_token={0}&v=5.78", token).GetAsync().Result;
            Console.WriteLine(res);
            Console.ReadKey();
        }

        static void InitToken()
        {
            //WebServer ws = new WebServer(request => {
            //    code = request.QueryString["code"];
            //    return "";
            //}, "http://127.0.0.1:8000/");
            //ws.Run();
            //while (code == null)
            //    Thread.Sleep(10);
            //ws.Stop();
            //Console.WriteLine(code);

            //var tkn = String.Format("https://oauth.vk.com/access_token?client_id=1&client_secret={0}&redirect_uri={1}&code={2}", secret, home, code).GetAsync().Result;
            //Console.WriteLine(tkn.Content.);
        }

        //static string output = "";

        //public void createListener()
        //{
        //    // Create an instance of the TcpListener class.
        //    TcpListener tcpListener = null;
        //    IPAddress ipAddress = Dns.GetHostEntry("localhost").AddressList[0];
        //    try
        //    {
        //        // Set the listener on the local IP address
        //        // and specify the port.
        //        tcpListener = new TcpListener(ipAddress, 13);
        //        tcpListener.Start();
        //        tcpListener.
        //        output = "Waiting for a connection...";
        //    }
        //    catch (Exception e)
        //    {
        //        output = "Error: " + e.ToString();
        //    }
        //    while (true)
        //    {
        //        // Always use a Sleep call in a while(true) loop
        //        // to avoid locking up your CPU.
        //        Thread.Sleep(10);
        //        // Create a TCP socket.
        //        // If you ran this server on the desktop, you could use
        //        // Socket socket = tcpListener.AcceptSocket()
        //        // for greater flexibility.
        //        TcpClient tcpClient = tcpListener.AcceptTcpClient();
        //        // Read the data stream from the client.
        //        byte[] bytes = new byte[256];
        //        NetworkStream stream = tcpClient.GetStream();
        //        stream.Read(bytes, 0, bytes.Length);
        //        SocketHelper helper = new SocketHelper();
        //        helper.processMsg(tcpClient, stream, bytes);
        //    }
        //}
    }
}

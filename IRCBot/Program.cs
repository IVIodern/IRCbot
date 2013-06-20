using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amrykid.Web.IRC;
using System.Net; 
namespace IRCBot
{
    class Program
    {
        public static string server = "irc.rizon.net";
        public static string channel = "#IIIIII";
        public static string channel2 = "#moz.use"; 
        public static string chanp = "";
        public static string nick = "moz";
        public static int port = 6667;
        public static IRC _irc;
        static void Main(string[] args)
        {
            _irc = new IRC("Nothing");
            _irc.Nick = nick;
            _irc.Connect(server, port);
            _irc.Logon(nick, nick);
            _irc.Join(channel, chanp);
            _irc.Join(channel2); 
            _irc.IRCMessageRecieved += new IRC.IRCMessageRecievedHandler(_irc_IRCMessageRecieved);
            while (true)
            {
                _irc.ProcessEvents(0);
            }
        }

        static void _irc_IRCMessageRecieved(object sender, string message, User user, IRCChannel chan)
        {



            if (message.StartsWith("!lol"))
            {
                int pauseTime = 1500;

                _irc.SendMessage(user.Nick + " is now laughing out loud!", IRC.SupportedColors.DarkGreen, chan.Channel);
                System.Threading.Thread.Sleep(pauseTime);

            }

            if (message.StartsWith("!version"))
            {
                string nick1 = user.Nick;
                string version = _irc.SendCTCP(nick1, IRC.CTCPType.VERSION);
                _irc.SendMessage(user.Nick + "'s version is: " + _irc.SendCTCP(nick1, IRC.CTCPType.VERSION));


            }

            if (message.StartsWith("!help"))
            {
                int pauseTime = 1000;
                _irc.SendNotice(user.Nick, "=====================================");
                System.Threading.Thread.Sleep(pauseTime);
                _irc.SendNotice(user.Nick, "The current commands are:");
                
                System.Threading.Thread.Sleep(pauseTime);
                _irc.SendNotice(user.Nick, "!lol - tell the entire irc about your laugh!");
                System.Threading.Thread.Sleep(pauseTime);
                _irc.SendNotice(user.Nick, "!about - find out about the bot and it's maker.");
                System.Threading.Thread.Sleep(pauseTime);
                _irc.SendNotice(user.Nick, "!request - request something");
                System.Threading.Thread.Sleep(pauseTime);
                _irc.SendNotice(user.Nick, "!shoutout - shoutout something");
                System.Threading.Thread.Sleep(pauseTime); 
                _irc.SendNotice(user.Nick, "=====================================");    
               
            }

            if (message.StartsWith("!about"))
            {
                int pauseTime = 1000;
                _irc.SendNotice(user.Nick, "moz is a bot designed and developed in C# using the Amrykid framework.");
                System.Threading.Thread.Sleep(pauseTime);
                _irc.SendNotice(user.Nick, "=====================================");
                System.Threading.Thread.Sleep(pauseTime);
                _irc.SendNotice(user.Nick, "Credits:");
                System.Threading.Thread.Sleep(pauseTime);
                _irc.SendNotice(user.Nick, "Vextor - main coder of 'moz'");
                System.Threading.Thread.Sleep(pauseTime);
                _irc.SendNotice(user.Nick, "IVIodern/xyz - basic framework"); 


            }

            if (message.StartsWith("!request"))
            {
                    string archive = message;
                    string request = archive.Replace("!request ", "");

                    _irc.SendMessage("Request from " + user.Nick + " for: " + request, IRC.SupportedColors.Olive, channel2);
                    _irc.SendNotice(user.Nick, "Message sent to Vextor"); 
                    int pauseTime = 1500;
                    System.Threading.Thread.Sleep(pauseTime);

                }

            if (message.StartsWith("!shoutout"))
            {
                string archive = message;
                string request = archive.Replace("!shoutout ", "");

                _irc.SendMessage("Shoutout from " + user.Nick + ": "+ request, IRC.SupportedColors.Olive, channel2);
                _irc.SendNotice(user.Nick, "Shoutout sent to Vextor");
                int pauseTime = 1500;
                System.Threading.Thread.Sleep(pauseTime);

            }


        }



    }
}
    


























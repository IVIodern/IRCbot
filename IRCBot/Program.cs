using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Amrykid.Web.IRC;
namespace IRCBot
{
    class Program
    {
        public static string server = "irc.rizon.net";
        public static string channel = "#IIIIII";
        public static string chanp = "";
        public static string nick = "BOTNAME";
        public static int port = 6667;
        public static IRC _irc;
        static void Main(string[] args)
        {
            _irc = new IRC("Nothing");
            _irc.Nick = nick;
            _irc.Connect(server, port);
            _irc.Logon(nick, nick);
            _irc.Join(channel, chanp);
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
                _irc.SendMessage(  user.Nick + " is now laughing out loud!" + IRC.SupportedColors.NavyBlue, chan.Channel);
            }
        }
    }
}

























/*static void _irc_IRCMessageRecieved(object sender, string message, User user, IRCChannel chan)
{
    if (message.StartsWith("!"))
    {
        if (message.Replace("!", "").StartsWith("time"))
        {
            _irc.SendMessage("Your current time is: " + DateTime.Now.ToLongTimeString(), IRC.SupportedColors.NavyBlue, chan.Channel);
        }
    }
}*/
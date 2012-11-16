using System;
using System.Collections.Generic;
using System.Net.Mail;
using EmbeddedMail;
using FubuMVC.SelfHost;
using StructureMap;

namespace SystemStateExample.StoryTeller.Fixtures.Data
{
    public class SmtpServerController
    {
        private readonly Lazy<EmbeddedSmtpServer> _server;
        private int _port;

        public SmtpServerController()
        {
            _port = 5600;
            _server = new Lazy<EmbeddedSmtpServer>(() =>
                                                   {
                                                       _port = PortFinder.FindPort(_port);
                                                       var server = new EmbeddedSmtpServer(_port);

                                                       return server;
                                                   });
        }

        public int Start()
        {
            _server.Value.Start();
            return _port;
        }

        public void Shutdown()
        {
            if(_server.IsValueCreated)
            {
                _server.Value.Stop();
            }
        }

        public IEnumerable<MailMessage> RecordedMessages()
        {
            Shutdown();
            return _server.Value.ReceivedMessages();
        }
    }
}
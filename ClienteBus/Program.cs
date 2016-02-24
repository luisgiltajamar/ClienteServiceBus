using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using ServicioServiceBus;

namespace ClienteBus
{
    class Program
    {
        static void Main(string[] args)
        {
            var cf=new ChannelFactory<IServicioSaludo>(new NetTcpRelayBinding(),new EndpointAddress(ServiceBusEnvironment.CreateServiceUri("sb","demo48707","saludo")));

            cf.Endpoint.Behaviors.Add(new TransportClientEndpointBehavior()
            {
                TokenProvider = TokenProvider.CreateSharedSecretTokenProvider("owner", "gNZ5qIyZ7cZilcfAhnDrLmGYXJ0j9Xm66FXkV8ZM/KQ=")
            });

            var ch = cf.CreateChannel();
            
            Console.WriteLine(ch.GetSaludo("es"));

            cf.Close();
            
            Console.Read();

        }
    }
}

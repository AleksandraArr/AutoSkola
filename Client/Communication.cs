using Common.Communication;
using Common.Domain;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Client
{
    public class Communication
    {

        private static Communication _instance;
        public static Communication Instance { 
            get 
            {
                if( _instance == null ) _instance = new Communication();
                return _instance;
            } 
        }
        private Communication() { }

        private Socket socket;
        private JsonNetworkSerializer serializer;

        public void Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);
            serializer = new JsonNetworkSerializer(socket);
        }

        // Polaznik
        internal Response KreirajPolaznik(Polaznik polaznik) => SendRequest<Polaznik, Polaznik>(Operation.KreirajPolaznik, polaznik);
        internal Response VratiListuPolaznik(Polaznik polaznik) =>  SendRequest<Polaznik, List<Polaznik>>(Operation.VratiListuPolaznik, polaznik);
        internal Response VratiListuSviPolaznik() => SendRequest<object, List<Polaznik>>(Operation.VratiListuSviPolaznik);
        internal Response PromeniPolaznik(Polaznik polaznik) => SendRequest<Polaznik, VoidType>(Operation.PromeniPolaznik, polaznik);
        internal Response ObrisiPolaznik(Polaznik polaznik) => SendRequest<Polaznik, VoidType>(Operation.ObrisiPolaznik, polaznik);
        internal Response PretraziPolaznik(string tekst) => SendRequest<string, List<Polaznik>>(Operation.PretraziPolaznik, tekst);

        // Kategorija vozacke
        internal Response UbaciKategorijaVozacke(KategorijaVozacke kategorija) => SendRequest<KategorijaVozacke, VoidType>(Operation.UbaciKategorijaVozacke, kategorija);

        // Instruktor
        internal Response PrijaviInstruktor(Instruktor instruktor) => SendRequest<Instruktor, Instruktor>(Operation.PrijaviInstruktor, instruktor);
        internal Response VratiListuSviInstruktor() => SendRequest<object, List<Instruktor>>(Operation.VratiListuSviInstruktor);
        
        // Automobil
        internal Response VratiListuSviAutomobil() => SendRequest<object, List<Automobil>>(Operation.VratiListuSviAutomobil);

        // Evidencioni obrazac
        internal Response KreirajEvidencioniObrazac(EvidencioniObrazac obrazac) => SendRequest<EvidencioniObrazac, EvidencioniObrazac>(Operation.KreirajEvidencioniObrazac, obrazac);
        internal Response VratiListuEvidencioniObrazac(EvidencioniObrazac obrazac) => SendRequest<EvidencioniObrazac, List<EvidencioniObrazac>>(Operation.VratiListuEvidencioniObrazac, obrazac);
        internal Response VratiListuSviEvidencioniObrazac() => SendRequest<object, List<EvidencioniObrazac>>(Operation.VratiListuSviEvidencioniObrazac);
        internal Response PromeniEvidencioniObrazac(EvidencioniObrazac obrazac) => SendRequest<EvidencioniObrazac, VoidType>(Operation.PromeniEvidencioniObrazac, obrazac);
        internal Response ObrisiEvidencioniObrazac(EvidencioniObrazac obrazac) => SendRequest<EvidencioniObrazac, VoidType>(Operation.ObrisiEvidencioniObrazac, obrazac);
        internal Response PretraziEvidencioniObrazac(EvidencioniObrazacKriterijumiDTO entities) => SendRequest<EvidencioniObrazacKriterijumiDTO, List<EvidencioniObrazac>>(Operation.PretraziEvidencioniObrazac, entities);

        //TRequest - which type being send, TResponse - which type is receiver
        private Response SendRequest<TRequest, TResponse>(Operation operation, TRequest data = default)
            where TResponse : class
        {
            try
            {
                var req = new Request
                {
                    Operation = operation,
                    Data = data
                };

                serializer.Send(req);

                var response = serializer.Receive<Response>();

                if (!response.IsSuccess)
                {
                    return response;
                }

                if (typeof(TResponse) == typeof(VoidType))
                {
                    return new Response { IsSuccess = true };
                }

                var result = serializer.ReadType<TResponse>(response.Data);
                return new Response { IsSuccess = true, Data = result };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    ExceptionMessage = ex.Message
                };
            }
        }
        public class VoidType { }

    }
}

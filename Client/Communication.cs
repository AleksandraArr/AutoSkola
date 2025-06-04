using Common.Communication;
using Common.Domain;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
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
        private Communication()
        {
            
        }

        private Socket socket;
       private JsonNetworkSerializer serializer;

        public void Connect()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect("127.0.0.1", 9999);
            serializer = new JsonNetworkSerializer(socket);
        }

        internal Response PrijaviInstruktor(Instruktor instruktor)
        {
            return SendRequest<Instruktor, Instruktor>(Operation.PrijaviInstruktor, instruktor);
        }

        internal Response UbaciKategorijaVozacke(KategorijaVozacke kategorija)
        {
            return SendRequest<KategorijaVozacke, VoidType>(Operation.UbaciKategorijaVozacke, kategorija);
        }

        internal Response VratiListuSviPolaznik()
        {
            return SendRequest<object, List<Polaznik>>(Operation.VratiListuSviPolaznik);
        }
        internal Response VratiListuPolaznik(Polaznik polaznik)
        {
            return SendRequest<Polaznik, List<Polaznik>>(Operation.VratiListuPolaznik, polaznik);
        }
        internal Response VratiListuSviInstruktor()
        {
            return SendRequest<object, List<Instruktor>>(Operation.VratiListuSviInstruktor);
        }
        internal Response VratiListuSviEvidencioniObrazac()
        {
            return SendRequest<object, List<EvidencioniObrazac>>(Operation.VratiListuSviEvidencioniObrazac);
        }
        internal Response VratiListuEvidencioniObrazac(EvidencioniObrazac obrazac)
        {
            return SendRequest<EvidencioniObrazac, List<EvidencioniObrazac>>(Operation.VratiListuEvidencioniObrazac, obrazac);
        }
        internal Response VratiListuSviAutomobil()
        {
            return SendRequest<object, List<Automobil>>(Operation.VratiListuSviAutomobil);
        }
        internal Response PromeniPolaznik(Polaznik polaznik)
        {
            return SendRequest<Polaznik, VoidType>(Operation.PromeniPolaznik, polaznik);
        }
        internal Response PromeniEvidencioniObrazac(EvidencioniObrazac obrazac)
        {
            return SendRequest<EvidencioniObrazac, VoidType>(Operation.PromeniEvidencioniObrazac, obrazac);
        }
        internal Response ObrisiPolaznik(Polaznik polaznik)
        {
            return SendRequest<Polaznik, VoidType>(Operation.ObrisiPolaznik, polaznik);
        }
        internal Response ObrisiEvidencioniObrazac(EvidencioniObrazac obrazac)
        {
            return SendRequest<EvidencioniObrazac, VoidType>(Operation.ObrisiEvidencioniObrazac, obrazac);
        }
        internal Response PretraziEvidencioniObrazac(EvidencioniObrazacKriterijumiDTO entities)
        {
            return SendRequest<EvidencioniObrazacKriterijumiDTO, List<EvidencioniObrazac>>(Operation.PretraziEvidencioniObrazac, entities);
        }
        internal Response PretraziPolaznik(string tekst)
        {
            return SendRequest<string, List<Polaznik>>(Operation.PretraziPolaznik, tekst);
        }
        private Response SendRequest<TRequest, TResponse>(Operation operation, TRequest data = default) where TResponse : class
        {
            //var req = new Request
            //{
            //    Operation = operation,
            //    Data = data
            //};

            //serializer.Send(req);

            //var response = serializer.Receive<Response>();
            //if (!response.IsSuccess)
            //    throw new Exception(response.ExceptionMessage);

            //if (typeof(TResponse) == typeof(VoidType)) return default;

            //return serializer.ReadType<TResponse>(response.Data);
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

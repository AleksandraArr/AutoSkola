using Common.Communication;
using Common.Domain;
using Common.DTO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class ClientHandler
    {
        private JsonNetworkSerializer serializer;
        private Socket socket;
        private readonly Server server;

        public ClientHandler(Socket socket, Server server)
        {
            this.socket = socket;
            this.server = server;
            serializer = new JsonNetworkSerializer(socket);
        }

        public void HandleRequest()
        {
            try
            {
                while (true)
                {
                    Request req = serializer.Receive<Request>();
                    Response r = ProcessRequest(req);
                    serializer.Send(r);
                }
            }
            catch (SocketException) 
            {
                Debug.WriteLine("Komunikacija sa klijentom je prekinuta");
            }
            catch (IOException)
            {
                Debug.WriteLine("Komunikacija sa klijentom je prekinuta");
            }
            finally
            {
                if (socket.Connected)
                {
                    socket.Close();
                }
                server.RemoveClient(this);
            }
        }

        private Response ProcessRequest(Request req)
        {
            Response r = new Response();
            try
            {
                switch (req.Operation)
                {
                    // Polaznik
                    case Operation.KreirajPolaznik:
                        r.Data = Controller.Instance.KreirajPolaznik(serializer.ReadType<Polaznik>(req.Data));
                        r.IsSuccess = true;
                        break;
                    case Operation.VratiListuPolaznik:
                        r.Data = Controller.Instance.VratiListuPolaznik(serializer.ReadType<Polaznik>(req.Data));
                        r.IsSuccess = true;
                        break;
                    case Operation.VratiListuSviPolaznik:
                        r.Data = Controller.Instance.VratiListuSviPolaznik();
                        r.IsSuccess = true;
                        break;
                    case Operation.PromeniPolaznik:
                        r.Data = Controller.Instance.PromeniPolaznik(serializer.ReadType<Polaznik>(req.Data));
                        r.IsSuccess = true;
                        break;
                    case Operation.ObrisiPolaznik:
                        Controller.Instance.ObrisiPolaznik(serializer.ReadType<Polaznik>(req.Data));
                        r.IsSuccess = true;
                        break;
                    case Operation.PretraziPolaznik:
                        r.Data = Controller.Instance.PretraziPolaznik(serializer.ReadType<string>(req.Data));
                        r.IsSuccess = true;
                        break;

                    // Vozacka kategorija
                    case Operation.UbaciKategorijaVozacke:
                        Controller.Instance.UbaciKategorijaVozacke(serializer.ReadType<KategorijaVozacke>(req.Data));
                        r.IsSuccess = true;
                        break;

                    // Instruktor
                    case Operation.PrijaviInstruktor:
                        r.Data = Controller.Instance.PrijaviInstruktor(serializer.ReadType<Instruktor>(req.Data));
                        r.IsSuccess = true;
                        break;
                    case Operation.VratiListuSviInstruktor:
                        r.Data = Controller.Instance.VratiListuSviInstruktor();
                        r.IsSuccess = true;
                        break;

                    // Automobil
                    case Operation.VratiListuSviAutomobil:
                        r.Data = Controller.Instance.VratiListuSviAutomobil();
                        r.IsSuccess = true;
                        break;

                    // Evidencioni obrazac
                    case Operation.KreirajEvidencioniObrazac:
                        r.Data = Controller.Instance.KreirajEvidencioniObrazac(serializer.ReadType<EvidencioniObrazac>(req.Data));
                        r.IsSuccess = true;
                        break;
                    case Operation.VratiListuEvidencioniObrazac:
                        r.Data = Controller.Instance.VratiListuEvidencioniObrazac(serializer.ReadType<EvidencioniObrazac>(req.Data));
                        r.IsSuccess = true;
                        break;
                    case Operation.VratiListuSviEvidencioniObrazac:
                        r.Data = Controller.Instance.VratiListuSviEvidencioniObrazac();
                        r.IsSuccess = true;
                        break;
                    case Operation.PromeniEvidencioniObrazac:
                        r.Data = Controller.Instance.PromeniEvidencioniObrazac(serializer.ReadType<EvidencioniObrazac>(req.Data));
                        r.IsSuccess = true;
                        break;
                    case Operation.ObrisiEvidencioniObrazac:
                        Controller.Instance.ObrisiEvidencioniObrazac(serializer.ReadType<EvidencioniObrazac>(req.Data));
                        r.IsSuccess = true;
                        break;
                    case Operation.PretraziEvidencioniObrazac:
                        r.Data = Controller.Instance.PretraziEvidencioniObrazac(serializer.ReadType<EvidencioniObrazacKriterijumiDTO>(req.Data));
                        r.IsSuccess = true;
                        break;
                    default:
                        throw new Exception("Nepoznat zahtev");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Greška na serveru: " + ex.Message);
                r.IsSuccess = false;
                r.ExceptionMessage = ex.Message;
            }
            return r;
        }

        internal void CloseSocket()
        {
            socket.Close();
        }
    }
}

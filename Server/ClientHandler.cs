using Common.Communication;
using Common.Domain;
using Common.DTO;
using System.Diagnostics;
using System.Net.Sockets;

namespace Server
{
    public class ClientHandler
    {
        private readonly JsonNetworkSerializer serializer;
        private readonly Socket socket;
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
                        r.Data = Controller.KreirajPolaznik(JsonNetworkSerializer.ReadType<Polaznik>(req.Data));
                        r.IsSuccess = true;
                        break;
                    case Operation.VratiListuPolaznik:
                        r.Data = Controller.VratiListuPolaznik(JsonNetworkSerializer.ReadType<Polaznik>(req.Data));
                        r.IsSuccess = true;
                        break;
                    case Operation.VratiListuSviPolaznik:
                        r.Data = Controller.VratiListuSviPolaznik();
                        r.IsSuccess = true;
                        break;
                    case Operation.PromeniPolaznik:
                        r.Data = Controller.PromeniPolaznik(JsonNetworkSerializer.ReadType<Polaznik>(req.Data));
                        r.IsSuccess = true;
                        break;
                    case Operation.ObrisiPolaznik:
                        Controller.ObrisiPolaznik(JsonNetworkSerializer.ReadType<Polaznik>(req.Data));
                        r.IsSuccess = true;
                        break;
                    case Operation.PretraziPolaznik:
                        r.Data = Controller.PretraziPolaznik(JsonNetworkSerializer.ReadType<string>(req.Data));
                        r.IsSuccess = true;
                        break;

                    // Vozacka kategorija
                    case Operation.UbaciKategorijaVozacke:
                        Controller.UbaciKategorijaVozacke(JsonNetworkSerializer.ReadType<KategorijaVozacke>(req.Data));
                        r.IsSuccess = true;
                        break;

                    // Instruktor
                    case Operation.PrijaviInstruktor:
                        r.Data = Controller.PrijaviInstruktor(JsonNetworkSerializer.ReadType<Instruktor>(req.Data));
                        r.IsSuccess = true;
                        break;
                    case Operation.VratiListuSviInstruktor:
                        r.Data = Controller.VratiListuSviInstruktor();
                        r.IsSuccess = true;
                        break;

                    // Automobil
                    case Operation.VratiListuSviAutomobil:
                        r.Data = Controller.VratiListuSviAutomobil();
                        r.IsSuccess = true;
                        break;

                    // Evidencioni obrazac
                    case Operation.KreirajEvidencioniObrazac:
                        r.Data = Controller.KreirajEvidencioniObrazac(JsonNetworkSerializer.ReadType<EvidencioniObrazac>(req.Data));
                        r.IsSuccess = true;
                        break;
                    case Operation.VratiListuEvidencioniObrazac:
                        r.Data = Controller.VratiListuEvidencioniObrazac(JsonNetworkSerializer.ReadType<EvidencioniObrazac>(req.Data));
                        r.IsSuccess = true;
                        break;
                    case Operation.VratiListuSviEvidencioniObrazac:
                        r.Data = Controller.VratiListuSviEvidencioniObrazac();
                        r.IsSuccess = true;
                        break;
                    case Operation.PromeniEvidencioniObrazac:
                        r.Data = Controller.PromeniEvidencioniObrazac(JsonNetworkSerializer.ReadType<EvidencioniObrazac>(req.Data));
                        r.IsSuccess = true;
                        break;
                    case Operation.ObrisiEvidencioniObrazac:
                        Controller.ObrisiEvidencioniObrazac(JsonNetworkSerializer.ReadType<EvidencioniObrazac>(req.Data));
                        r.IsSuccess = true;
                        break;
                    case Operation.PretraziEvidencioniObrazac:
                        r.Data = Controller.PretraziEvidencioniObrazac(JsonNetworkSerializer.ReadType<EvidencioniObrazacKriterijumiDTO>(req.Data));
                        r.IsSuccess = true;
                        break;
                    default:
                        throw new NotSupportedException("Nepoznat zahtev");
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

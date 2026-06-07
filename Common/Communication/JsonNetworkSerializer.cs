using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Common.Communication
{
    public class JsonNetworkSerializer
    {
        private readonly NetworkStream stream;
        private readonly StreamReader reader;
        private readonly StreamWriter writer;

        public JsonNetworkSerializer(Socket s)
        {
            stream = new NetworkStream(s);
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream)
            {
                AutoFlush = true
            };
        }

        public void Send(object z)
        {
            writer.WriteLine(JsonSerializer.Serialize(z));
        }

        public T Receive<T>()
        {
            string json = reader.ReadLine() ?? throw new IOException("Veza je zatvorena.");
            return JsonSerializer.Deserialize<T>(json)!;
        }

        public static T? ReadType<T>(object podaci) where T : class
        {
            return podaci == null ? null : JsonSerializer.Deserialize<T>((JsonElement)podaci);
        }

        public void Close()
        {
            stream.Close();
            reader.Close();
            writer.Close();
        }
    }
}

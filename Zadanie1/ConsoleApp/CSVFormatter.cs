using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;

namespace Zadanie2
{
    class CSVFormatter : IFormatter
    {
        public ISurrogateSelector SurrogateSelector { get; set; }
        public SerializationBinder Binder { get; set; }
        public StreamingContext Context { get; set; }

        public object Deserialize(Stream serializationStream)
        {
            using (StreamReader sr = new StreamReader(serializationStream))
            {
                object deserializedObject = null;
                string line = "";
                while ((line = sr.ReadLine()) != null)
                {
                    string[] separatedKeyValues = line.Split(',');
                    SerializationInfo info = new SerializationInfo(deserializedObject.GetType(), new FormatterConverter());
                    foreach (string s in separatedKeyValues)
                    {
                        string[] singleKeyValue = s.Split(':');
                        info.AddValue(singleKeyValue[0], singleKeyValue[1]);
                    }

                }
                return deserializedObject;
            }
        }

        public void Serialize(Stream serializationStream, object graph)
        {
            SerializationInfo si = new SerializationInfo(graph.GetType(), new FormatterConverter());
            StreamingContext cx = new StreamingContext(StreamingContextStates.File);
            ISerializable serializableGraph = (ISerializable)graph;
            serializableGraph.GetObjectData(si, cx);

            using (StreamWriter sw = new StreamWriter(serializationStream))
            {
                foreach (SerializationEntry entry in si)
                {
                    sw.Write(entry.Name);
                    sw.Write(":");
                    sw.Write(entry.Value);
                    sw.Write(",");
                }
                sw.WriteLine("");
            }
        }
    }
}

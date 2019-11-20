﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Reflection;

namespace Zadanie2
{
    class CSVFormatter<T> : IFormatter where T: class
    {
        public ISurrogateSelector SurrogateSelector { get; set; }
        public SerializationBinder Binder { get; set; }
        public StreamingContext Context { get; set; }

        public object Deserialize(Stream serializationStream)
        {
            StreamReader sr = new StreamReader(serializationStream);
            string line = "";
            line = sr.ReadLine();
            line = line.Remove(line.Length - 1);
            T obj = (T)FormatterServices.GetUninitializedObject(typeof(T));
            string[] separatedKeyValues = line.Split(',');
            SerializationInfo info = new SerializationInfo(obj.GetType(), new FormatterConverter());
            foreach (string s in separatedKeyValues)
            {
                    string[] singleKeyValue = s.Split(':');
                    info.AddValue(singleKeyValue[0], singleKeyValue[1]);
            }
            var constructor = obj.GetType().GetConstructor(BindingFlags.Instance | BindingFlags.Public, null, new[] { typeof(SerializationInfo), typeof(StreamingContext) }, null);
            constructor.Invoke(obj, new object[] {info, Context });
            sr.Dispose();
            return obj;
            
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
                sw.Flush();
            }
        }
    }
}

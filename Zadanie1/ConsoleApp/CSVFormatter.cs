using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Globalization;

namespace Zadanie2
{
    class CSVFormatter : Formatter
    {
        StringBuilder ObjectTextForm = new StringBuilder();
        private bool firstEntry = true;
        public override ISurrogateSelector SurrogateSelector { get; set; }
        public override SerializationBinder Binder { get; set; }
        public override StreamingContext Context { get; set; }

        public override object Deserialize(Stream serializationStream)
        {          
            StreamReader sr = new StreamReader(serializationStream);
            string line="";
            while ((line = sr.ReadLine())!=null)
            {
                string[] typeDataSplit = line.Split('#');
                Type objType = Type.GetType(typeDataSplit[0]);
                FormatterServices.GetUninitializedObject(objType); // tworzenie obiektu znajac jego nazwe
                string[] keyValuePairs = typeDataSplit[1].Split(',');
                foreach(string pair in keyValuePairs)
                {
                    string[] keyValueSplit = pair.Split(':');
                }
                               
            }
            sr.Dispose();
            
            return new object();
        }

        public override void Serialize(Stream serializationStream, object graph)
        {

        ISerializable _data = (ISerializable)graph;
        SerializationInfo _info = new SerializationInfo(graph.GetType(), new FormatterConverter());
        StreamingContext _context = new StreamingContext(StreamingContextStates.File);
        _data.GetObjectData(_info, _context);
        ObjectTextForm.Append(graph.GetType() +"#"+"ref" + ":" + this.m_idGenerator.GetId(graph, out bool firstTime)+",");
        foreach (SerializationEntry _item in _info)
        {
            WriteMember(_item.Name, _item.Value);
        }
        while (this.m_objectQueue.Count != 0)
        {
            ObjectTextForm.Length--; //remove trailing coma
            ObjectTextForm.Append("\n");
            this.Serialize(null, this.m_objectQueue.Dequeue());
        }
        if(serializationStream != null)
        {
            using (StreamWriter writer = new StreamWriter(serializationStream))
            {
                ObjectTextForm.Length--; //remove last trailing coma
                writer.Write(ObjectTextForm);
            }
        }
    }


    protected override void WriteArray(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }

        protected override void WriteBoolean(bool val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteByte(byte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteChar(char val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDateTime(DateTime val, string name)
        {
            ObjectTextForm.Append(name +":"+val.ToUniversalTime()+",");
        }

        protected override void WriteDecimal(decimal val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteDouble(double val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt16(short val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt32(int val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteInt64(long val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteObjectRef(object obj, string name, Type memberType)
        {
            if(memberType != typeof(string))
            {
                this.Schedule(obj);
                ObjectTextForm.Append(name + ":" + this.m_idGenerator.GetId(obj, out bool firstTime) + ",");
            }
            else
            {
                ObjectTextForm.Append(name + ":" + obj.ToString() + ",");
            }
        }

        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSingle(float val, string name)
        {
            ObjectTextForm.Append(name + ":" + val.ToString("0.00", CultureInfo.InvariantCulture) + ",");
        }

        protected override void WriteTimeSpan(TimeSpan val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt16(ushort val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt32(uint val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteUInt64(ulong val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteValueType(object obj, string name, Type memberType)
        {
            throw new NotImplementedException();
        }
    }
}

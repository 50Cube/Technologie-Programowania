using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Globalization;
using System.Reflection;
using System.Collections.Generic;

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
            Dictionary<string, object> objectRefs = new Dictionary<string, object>();
            object createdObject = null;
            List<object> objects = new List<object>();
            StreamReader sr = new StreamReader(serializationStream);
            string entry = "";
            List<string> lines = new List<string>();
            while ((entry = sr.ReadLine())!=null)
            {
                lines.Add(entry);
                /*
                string[] typeDataSplit = line.Split('#');
                Type objType = Type.GetType(typeDataSplit[0]);
                object tempObject = FormatterServices.GetUninitializedObject(objType); // tworzenie obiektu znajac jego nazwe
                MemberInfo[] members = FormatterServices.GetSerializableMembers(objType, Context);
                string[] keyValuePairs = typeDataSplit[1].Split(',');
                string[] refSplit = keyValuePairs[0].Split(':');
                objectRefs[refSplit[1]] = tempObject;

                SerializationInfo info = new SerializationInfo(objType, new FormatterConverter());
                object[] data = new object[members.Length];
                for (int i = 1;i < members.Length; ++i)
                {
                    string[] keyValueSeparated = keyValuePairs[i].Split(':');
                    FieldInfo fi = ((FieldInfo)members[i]);
                    try
                    {
                        string temp = keyValueSeparated[1];
                        data[i] = Convert.ChangeType(temp, fi.FieldType);
                        info.AddValue(keyValueSeparated[0], keyValueSeparated[1]);
                    }
                    catch(InvalidCastException)
                    {
                        info.AddValue(keyValueSeparated[0], null);
                        //                      data[i] = null;
                    }
                }
                 createdObject = Activator.CreateInstance(objType, info, Context);    
                 */
            }
            foreach(string line in lines)
            {
                string[] typeDataSplit = line.Split('#');
                Type objType = Type.GetType(typeDataSplit[0]);
                object tempObject = FormatterServices.GetUninitializedObject(objType);
                string[] keyValuePairs = typeDataSplit[1].Split(',');
                string[] refSplit = keyValuePairs[0].Split(':');
                objectRefs[refSplit[1]] = tempObject;
            }

            foreach(string line in lines)
            {
                string[] typeDataSplit = line.Split('#');
                Type objType = Type.GetType(typeDataSplit[0]);
                object tempObject = FormatterServices.GetUninitializedObject(objType);
                string[] keyValuePairs = typeDataSplit[1].Split(',');
                string[] refSplit = keyValuePairs[0].Split(':');
                SerializationInfo info = new SerializationInfo(tempObject.GetType(), new FormatterConverter());
                foreach (string s in keyValuePairs)
                {
                    if(!s.Contains("ref"))
                    {
                        string[] singleKeyValue = s.Split(';');
                        if (singleKeyValue[0] == "Data")
                        {
                            DateTime data = DateTime.Parse(singleKeyValue[1], CultureInfo.InvariantCulture);
                            info.AddValue(singleKeyValue[0], data);
                        }
                        else if (singleKeyValue[0] != "Obiekt")
                        {
                            info.AddValue(singleKeyValue[0], singleKeyValue[1]);
                        }
                        else
                        {
                            info.AddValue(singleKeyValue[0], objectRefs[singleKeyValue[1]]);
                        }
                    }
                    
                }
 //               createdObject = Activator.CreateInstance(objType, info, Context);
                objects.Add(createdObject);
            }
                sr.Dispose();        
            return createdObject;
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
            ObjectTextForm.Append(name +";"+val.ToString(DateTimeFormatInfo.InvariantInfo)+",");
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
                ObjectTextForm.Append(name + ";" + this.m_idGenerator.GetId(obj, out bool firstTime)+ ",");
            }
            else
            {
                ObjectTextForm.Append(name + ";" + obj.ToString() + ",");
            }
        }

        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSingle(float val, string name)
        {
            ObjectTextForm.Append(name + ";" + val.ToString("0.00", CultureInfo.InvariantCulture) + ",");
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

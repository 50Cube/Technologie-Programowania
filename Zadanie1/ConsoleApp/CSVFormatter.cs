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
        StringBuilder stringBuilder = new StringBuilder();
        public override ISurrogateSelector SurrogateSelector { get; set; }
        public override SerializationBinder Binder { get; set; }
        public override StreamingContext Context { get; set; }

        public override object Deserialize(Stream serializationStream)
        {
            Dictionary<string, object> objectRefs = new Dictionary<string, object>();  //Id obiektu, obiekt na który wskazuje
            Dictionary<string, Type> RefsTypes = new Dictionary<string, Type>();    //Id obiektu, typ obiektu na który wskazuje
            Dictionary<string, SerializationInfo> refsInfos = new Dictionary<string, SerializationInfo>(); //Id obiektu, przypisane SerializationInfo

            StreamReader sr = new StreamReader(serializationStream);
            string entry = "";
            List<string> lines = new List<string>();
            while ((entry = sr.ReadLine())!=null)
            {
                lines.Add(entry);
            }

            foreach(string line in lines)   //Tworzenie niezainicjalizowanych obiektów, umieszczenie ich oraz ich typów w słownikach.
            {
                string[] typeDataSplit = line.Split('#');
                Type objType = Type.GetType(typeDataSplit[0]);
                object tempObject = FormatterServices.GetUninitializedObject(objType);
                string[] keyValuePairs = typeDataSplit[1].Split(',');
                string[] refSplit = keyValuePairs[0].Split(':');
                objectRefs[refSplit[1]] = tempObject;
                RefsTypes[refSplit[1]] = objType;
            }

            foreach(string line in lines)
            {
                string[] typeDataSplit = line.Split('#');
                string[] keyValuePairs = typeDataSplit[1].Split(',');
                string[] refSplit = keyValuePairs[0].Split(':');

                string objectID = refSplit[1];
                PropertyInfo[] properties = RefsTypes[objectID].GetProperties();
                Type[] types = GetTypesFromProperties(properties);                  //Tablica zawierajaca typy pol obiektu
                SerializationInfo info = new SerializationInfo(RefsTypes[objectID], new FormatterConverter());
                refsInfos.Add(objectID, info);
                for (int i = 1; i < keyValuePairs.Length; i++)  //Dodanie wartosci do SerializationInfo
                {
                    string s = keyValuePairs[i];                   
                    string[] singleKeyValue = s.Split(';');
                    string key = singleKeyValue[0];
                    string value = singleKeyValue[1];
                    if(key.StartsWith("|ObjectReference|"))
                    {
                       string infoName = key.Remove(0, 17);
                       refsInfos[objectID].AddValue(infoName, objectRefs[value]);
                    }
                    else
                    {
                        Type keyType = types[i-1];
                        object returnedValue = null;
                        if(keyType == typeof(string))
                        {
                            returnedValue = value;
                        }
                        else if(keyType == typeof(Single))
                        {
                            returnedValue = Single.Parse(value, CultureInfo.InvariantCulture);
                        }
                        else if(keyType == typeof(DateTime))
                        {
                            returnedValue = DateTime.Parse(value, CultureInfo.InvariantCulture);
                        }
                        else
                        {
                            throw new NotImplementedException("Nie zaimplementowano deserializacji pola tego typu");
                        }
                        info.AddValue(key, returnedValue);
                    }
                }

            }

            foreach (KeyValuePair<string, SerializationInfo> keyValue in refsInfos)
            {
                Type[] constructorTypes = { typeof(SerializationInfo), typeof(StreamingContext) };
                object[] constuctorParameters = { keyValue.Value, Context };
                objectRefs[keyValue.Key].GetType().GetConstructor(constructorTypes).Invoke(objectRefs[keyValue.Key], constuctorParameters);     //Wywołanie konstruktora dla każdego z deserializowanych obiektów
            }
            sr.Dispose();        
            return objectRefs["1"];
        }

        private Type[] GetTypesFromProperties(PropertyInfo[] properties)
        {
            Type[] types = new Type[properties.Length];
            for(int i=0;i<types.Length;i++)
            {
                types[i] = properties[i].PropertyType;
            }
            return types;
        }

        public override void Serialize(Stream serializationStream, object graph)
        {

        ISerializable _data = (ISerializable)graph;
        SerializationInfo _info = new SerializationInfo(graph.GetType(), new FormatterConverter());
        StreamingContext _context = new StreamingContext(StreamingContextStates.File);
        _data.GetObjectData(_info, _context);
        stringBuilder.Append(graph.GetType().AssemblyQualifiedName + "#"+"ref" + ":" + this.m_idGenerator.GetId(graph, out bool firstTime)+",");
        foreach (SerializationEntry _item in _info)
        {
            WriteMember(_item.Name, _item.Value);
        }
        while (this.m_objectQueue.Count != 0)
        {
            stringBuilder.Length--; //remove trailing coma
            stringBuilder.Append("\n");
            this.Serialize(null, this.m_objectQueue.Dequeue());
        }
        if(serializationStream != null)
        {
            using (StreamWriter writer = new StreamWriter(serializationStream))
            {
                stringBuilder.Length--; //remove last trailing coma
                writer.Write(stringBuilder);
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
            stringBuilder.Append(name +";"+val.ToString(DateTimeFormatInfo.InvariantInfo)+",");
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
                stringBuilder.Append("|ObjectReference|"+name + ";" + this.m_idGenerator.GetId(obj, out bool firstTime)+ ",");
            }
            else
            {
                stringBuilder.Append(name + ";" + obj.ToString() + ",");
            }
        }

        protected override void WriteSByte(sbyte val, string name)
        {
            throw new NotImplementedException();
        }

        protected override void WriteSingle(float val, string name)
        {
            stringBuilder.Append(name + ";" + val.ToString("0.00", CultureInfo.InvariantCulture) + ",");
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

﻿using System;
using System.Runtime.Serialization;
namespace Zadanie2
{
    public class KlasaB : ISerializable
    {
        public KlasaB() { }
        public KlasaB(float liczba, string napis, DateTime data, KlasaC obiekt)
        {
            this.Liczba = liczba;
            this.Napis = napis;
            this.Data = data;
            this.Obiekt = obiekt;
        }

        public float Liczba { get; set; }
        public string Napis { get; set; }
        public DateTime Data { get; set; }
        public KlasaC Obiekt { get; set; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Liczba", this.Liczba);
            info.AddValue("Napis", this.Napis);
            info.AddValue("Data", this.Data);
            info.AddValue("Obiekt", this.Obiekt);
        }

        public override string ToString()
        {
            return "Liczba: " + this.Liczba + ", Napis: " + this.Napis + ", Data: " + this.Data;
        }
    }
}

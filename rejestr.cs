using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;
namespace ConsoleApp1
{

    [Serializable]
    [XmlRoot("Rejestr")]
    public class rejestr : IComparable<rejestr>
    {
        public rejestr()
        {

        }
        public rejestr(int id, string imie, string nazwisko, int wiek, char plec, int kod_pocztowy, string miasto, string ulica, int nr_domu, int nr_mieszkania)
        {
            _id = id;
            _imie = imie;
            _nazwisko = nazwisko;
            _wiek = wiek;
            _plec = plec;
            _kod_pocztowy = kod_pocztowy;
            _miasto = miasto;
            _ulica = ulica;
            _nr_domu = nr_domu;
            _nr_mieszkania = nr_mieszkania;
        }
        protected int _id;
        protected string _imie;
        protected string _nazwisko;
        protected int _wiek;
        protected char _plec;
        protected int _kod_pocztowy;
        protected string _miasto;
        protected string _ulica;
        protected int _nr_domu;
        protected int _nr_mieszkania;

        
        public int ID { get => _id; set => _id = value; }
        
        public string Imie { get => _imie; set => _imie = value; }
  
        public string Nazwisko { get => _nazwisko; set => _nazwisko = value; }

        public int Wiek { get => _wiek; set => _wiek = value; }

        public char Plec { get => _plec; set => _plec = value; }

        public int Kod_pocztowy { get => _kod_pocztowy; set => _kod_pocztowy= value; }

        public string Miasto { get => _miasto; set => _miasto = value; }

        public string Ulica { get => _ulica; set => _ulica = value; }

        public int Nr_domu { get => _nr_domu; set => _nr_domu = value; }

        public int Nr_mieszkania { get => _nr_mieszkania; set => _nr_mieszkania = value; }



        public int CompareTo(rejestr other)
        {
            int result = Nazwisko.CompareTo(other.Nazwisko);
            if (result == 0)
                result = Imie.CompareTo(other.Imie);
            return result;
        }


    }
    public class CompareToMiasto : IComparer<rejestr>
    {
        public int Compare(rejestr x, rejestr y)
        {
            if (x == null)
            {
                return -1;
            }
            else if (y == null)
            {
                return -1;
            }
            else
            {

                return x.Miasto.CompareTo(y.Miasto);
            }
        }
    }
    public class CompareToID : IComparer<rejestr>
    {
        public int Compare(rejestr x, rejestr y)
        {
            if (x == null)
            {
                return -1;
            }
            else if (y == null)
            {
                return -1;
            }
            else
            {

                return x.ID.CompareTo(y.ID);
            }
        }
    }
}

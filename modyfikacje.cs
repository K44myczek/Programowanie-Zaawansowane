using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    enum menu { Dodaj = 1, Wyswietl = 2, Posortuj = 3, Edytuj = 4, Wyszukaj = 5, Usun = 6, Wyjdz = 7 }
    public class modyfikacje : rejestr
    {
       static List<rejestr> lista = new List<rejestr>();
        rejestr uzytkownik = new rejestr();
        public List<rejestr> DodajUzytkwnika(List<rejestr> lista)
        {

            string imie;
            string nazwisko;
            int wiek;
            char plec;
            int kod_pocztowy;
            string miasto;
            string ulica;
            int nr_domu;
            int nr_mieszkania;
            string kod;
            string plec_string;

            Console.Clear(); 
            Console.WriteLine("Podaj imię!");
            imie = Console.ReadLine();
            Console.WriteLine("Podaj nazwisko!");
            nazwisko = Console.ReadLine();
            do
            {
                Console.WriteLine("Podaj wiek!");
            }
            while (!int.TryParse(Console.ReadLine(), out wiek) || wiek < 1 || wiek > 100);
           bool sprawdzenie = true;
            do
            {
                Console.WriteLine("Podaj płeć[k/m]!");
                plec_string = Console.ReadLine();

                if(plec_string.ToLower()=="k")
                {
                    sprawdzenie = false;
                }
                else if(plec_string.ToLower() == "m")
                {
                    sprawdzenie = false;
                }

            }
            while ( sprawdzenie);
            plec = Convert.ToChar(plec_string);
            do
            {
                Console.WriteLine("Podaj kod pocztowy[tylko cyfry]!");
                kod = Console.ReadLine();
            }
            while (!int.TryParse(kod, out kod_pocztowy) || kod.Length != 5);
            Console.WriteLine("Podaj Miasto!");
            miasto = Console.ReadLine();
            Console.WriteLine("Podaj ulicę!");
            ulica = Console.ReadLine();
            do
            {
                Console.WriteLine("Podaj nr domu!");
            }
            while (!int.TryParse(Console.ReadLine(), out nr_domu) || nr_domu < 1);
            do
            {
                Console.WriteLine("Podaj nr mieszkania[jeśli nie ma to wpisujemy 0]!");
            }
            while (!int.TryParse(Console.ReadLine(), out nr_mieszkania) || nr_mieszkania < 0);
            int id = (lista[lista.Count-1].ID +1);
            rejestr u = new rejestr((id), imie, nazwisko, wiek, plec, kod_pocztowy, miasto, ulica, nr_domu, nr_mieszkania);
            lista.Add(u);
            Console.Clear();
            Console.WriteLine("Użytkownik został dodany pomyślnie!");
            Thread.Sleep(3000);
            Console.Clear();
            return lista;
        }
        public void WyswietlUzytkownikow(List<rejestr> lista)
        {
            Console.Clear();
            if (lista.Count < 1)
            {
                Console.WriteLine("Brak dodanych użytkowników");
                Thread.Sleep(5000);
            }
            else
            {
                foreach (rejestr uzytkownik in lista)
                {

                    if (uzytkownik.Nr_mieszkania == 0)
                    {
                        Console.WriteLine($"ID: {uzytkownik.ID} | Imie: {uzytkownik.Imie} | Nazwisko: {uzytkownik.Nazwisko} | Wiek: {uzytkownik.Wiek} | Plec: {uzytkownik.Plec} | Kod pocztowy: {uzytkownik.Kod_pocztowy} | Miasto: {uzytkownik.Miasto} | Ulica: {uzytkownik.Ulica} | Nr domu: {uzytkownik.Nr_domu}");
                    }
                    else
                    {
                        Console.WriteLine($"ID: {uzytkownik.ID} | Imie: {uzytkownik.Imie} | Nazwisko: {uzytkownik.Nazwisko} | Wiek: {uzytkownik.Wiek} | Plec: {uzytkownik.Plec} | Kod pocztowy: {uzytkownik.Kod_pocztowy} | Miasto: {uzytkownik.Miasto} | Ulica: {uzytkownik.Ulica} | Nr domu: {uzytkownik.Nr_domu}/{uzytkownik.Nr_mieszkania}");
                    }
                }

                Console.ReadKey();
                Console.Clear();
            }
        }
        public List<rejestr> EdycjaUzytkownika(List<rejestr> lista)
        {
            Console.Clear();
            int pid;
            do { Console.WriteLine("Podaj id uzytkownika, którego chcesz edytowac"); }
            while (!int.TryParse(Console.ReadLine(), out pid));
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].ID == pid)
                {
                    string imie;
                    string nazwisko;
                    int wiek;
                    char plec;
                    int kod_pocztowy;
                    string miasto;
                    string ulica;
                    int nr_domu;
                    int nr_mieszkania;
                    string kod;
                    string plec_string;

                    Console.WriteLine("Podaj imię!");
                    imie = Console.ReadLine();
                    Console.WriteLine("Podaj nazwisko!");
                    nazwisko = Console.ReadLine();
                    do
                    {
                        Console.WriteLine("Podaj wiek!");
                    }
                    while (!int.TryParse(Console.ReadLine(), out wiek) || wiek < 1 || wiek > 100);
                    do
                    {
                        Console.WriteLine("Podaj płeć!");
                        plec_string = Console.ReadLine();

                    }
                    while (plec_string.Length != 1 || plec_string != "k" /*|| plec_string != "K" || plec_string != "m" || plec_string != "M"*/);
                    plec = Convert.ToChar(plec_string);
                    do
                    {
                        Console.WriteLine("Podaj kod pocztowy!");
                        kod = Console.ReadLine();
                    }
                    while (!int.TryParse(kod, out kod_pocztowy) || kod.Length != 5);
                    Console.WriteLine("Podaj Miasto!");
                    miasto = Console.ReadLine();
                    Console.WriteLine("Podaj ulicę!");
                    ulica = Console.ReadLine();
                    do
                    {
                        Console.WriteLine("Podaj nr domu!");
                    }
                    while (!int.TryParse(Console.ReadLine(), out nr_domu) || nr_domu < 1);
                    do
                    {
                        Console.WriteLine("Podaj nr mieszkania!");
                    }
                    while (!int.TryParse(Console.ReadLine(), out nr_mieszkania) || nr_mieszkania < 0);
                    
                    rejestr nowy = new rejestr((i+1), imie, nazwisko, wiek, plec, kod_pocztowy, miasto, ulica, nr_domu, nr_mieszkania);
                    lista[i] = nowy;
                    Console.Clear();
                    Console.WriteLine("Edycja przbiegla pomyślnie");
                    Thread.Sleep(3000);
                    Console.Clear();
                    return lista;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Podane ID nie istnieje");
                    Thread.Sleep(3000);
                    Console.Clear();
                    return lista;
                }

            }
            return lista;
        }
        public List<rejestr> UsunUzytkownika(List<rejestr> lista)
        {
            Console.Clear();
            int pid;
            do { Console.WriteLine("Podaj ID uzytkownika ktorego chcesz usunac"); }
            while (!int.TryParse(Console.ReadLine(), out pid));
            for (int i = 0; i < lista.Count; i++)
            {
                if(lista[i].ID==pid)
                {
                    lista.RemoveAt(i);
                    Console.Clear();
                    Console.WriteLine("Użytkownik został usunięty");
                    Thread.Sleep(3000);
                    Console.Clear();
                    return lista;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Podane ID nie istnieje");
                    Thread.Sleep(3000);
                    Console.Clear();
                }
            }
            return lista;
        }
        public void Wyszukaj(List<rejestr> lista)
        {
            Console.Clear();
            Console.WriteLine("Podaj szukane Imie");
            string szukane_imie = Console.ReadLine();
            Console.WriteLine("Podaj szukane Nazwisko");
            string szukane_nazwisko = Console.ReadLine();
            Console.Clear();
            for (int i = 0; i < lista.Count; i++)
            {
                if(lista[i].Imie == szukane_imie && lista[i].Nazwisko==szukane_nazwisko)
                {
                    Console.WriteLine($"Imię {lista[i].Imie} Nazwisko {lista[i].Nazwisko} Wiek {lista[i].Wiek} Plec {lista[i].Plec} Kod pocztowy {lista[i].Kod_pocztowy} Miasto {lista[i].Miasto} Ulica {lista[i].Ulica} Nr domu {lista[i].Nr_domu} Nr mieszkania {lista[i].Nr_mieszkania}");
                }
            }
            Thread.Sleep(3000);
        }
        static void serialize(List<rejestr> lis)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<rejestr>));
            try
            {
                using (TextWriter writer = new StreamWriter(@"./uzytkownicy.xml"))
                {
                    serializer.Serialize(writer, lis);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void deserialize()
        {
            XmlSerializer serializel = new XmlSerializer(typeof(List<rejestr>));
            lista = new List<rejestr>();

            try
            {
                using (TextReader reader = new StreamReader(@"./uzytkownicy.xml"))
                {
                    var obj = serializel.Deserialize(reader);
                    lista = (List<rejestr>)obj;
                }

            }
            catch (Exception)
            { }
        }
        public static void Menu_uzytkowe()
        {

            modyfikacje modyfikacja = new modyfikacje();  
              deserialize();
            menu m;
            bool exit = false;
            while (!exit)
            {
                do {
                    Console.Clear(); 
                    Console.WriteLine("Wybierz jedną z opcji:\n1.Dodaj nowego użytkownika \n2.Wyświetlenie wszystkich uzytkowników \n3.Posortuj użytkowników \n4.Edycja użytkownika \n5.Wyszukiwanie użytkownika \n6.Usuwanie użytkownika \n7.Wyjście"); }
                while (!Enum.TryParse<menu>(Console.ReadLine(), out m));
                Console.Clear();
                switch (m)
                {
                    case menu.Dodaj:
                        modyfikacja.DodajUzytkwnika(lista);
                        break;
                    case menu.Wyswietl:
                        Console.Clear();
                        lista.Sort(new CompareToID());
                        modyfikacja.WyswietlUzytkownikow(lista);
                        break;
                    case menu.Posortuj:
                        int wybor;
                        Console.Clear();
                        do {
                            Console.Clear();
                            Console.WriteLine("Wybierz po czym chcesz sortować \n 1.Nazwisku \n 2.Mieście"); }
                        while (!int.TryParse(Console.ReadLine(), out wybor) || wybor > 3);
                        switch (wybor)
                        {
                            case 1:
                                Console.Clear();
                                lista.Sort();
                                modyfikacja.WyswietlUzytkownikow(lista);
                                Console.ReadKey();
                                break;
                            case 2:
                                Console.Clear();
                                lista.Sort(new CompareToMiasto());
                                modyfikacja.WyswietlUzytkownikow(lista);
                                break;
                            default:
                                Console.WriteLine("Podano błędną wartość");
                                break;
                        }
                        break;
                    case menu.Edytuj:
                        modyfikacja.EdycjaUzytkownika(lista);
                        break;
                    case menu.Wyszukaj:
                        
                        modyfikacja.Wyszukaj(lista);
                        break;
                    case menu.Usun:
                        modyfikacja.UsunUzytkownika(lista);
                        break;
                    case menu.Wyjdz:
                        serialize(lista);
                        exit = true;
                        Console.Clear();
                        Console.WriteLine("Zapraszam do ponownego skorzystania z aplikacji");
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}

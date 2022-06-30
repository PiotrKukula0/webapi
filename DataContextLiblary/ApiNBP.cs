using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApiNBP
{ 

    [XmlRoot(ElementName = "pozycja")]

    public class Pozycja
    {

        [Key]
        [XmlElement(ElementName = "nazwa_waluty")]
        public string Nazwa_waluty { get; set; }
        [XmlElement(ElementName = "przelicznik")]
        public string Przelicznik { get; set; }
        [XmlElement(ElementName = "kod_waluty")]
        public string Kod_waluty { get; set; }
        [XmlElement(ElementName = "kurs_sredni")]
        public string Kurs_sredni { get; set; }
    }

    [XmlRoot(ElementName = "tabela_kursow")]

    public class Tabela_kursow
    {
        [XmlElement(ElementName = "numer_tabeli")]
        public string Numer_tabeli { get; set; }
        [XmlElement(ElementName = "data_publikacji")]
        public string Data_publikacji { get; set; }
        [XmlElement(ElementName = "pozycja")]
        public List<Pozycja> Pozycja { get; set; }
        [XmlAttribute(AttributeName = "typ")]
        public string Typ { get; set; }
        [XmlAttribute(AttributeName = "uid")]
        public string Uid { get; set; }
    }

}

  
        
    

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace ProbabilityReader
{

    class LocaReader
    {
        string filename = "texts_english.xml";
        XmlDocument loca;

        public LocaReader()
        {
            loca = new XmlDocument();
            loca.Load(new StreamReader(File.OpenRead(filename)));
        }

        public string getText(string guid)
        {
            XmlNode textNode = loca.SelectSingleNode("/TextExport/Texts/Text[GUID = " + guid + "]/Text");
            return textNode.InnerText;
        }
    }


}

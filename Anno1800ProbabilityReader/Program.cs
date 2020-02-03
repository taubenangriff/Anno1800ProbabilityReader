using ProbabilityReader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace ItemProbabilityReader
{
    class Item
    {
        public string Name;
        public string Guid;
        public double Probability;
        public string Rarity;
        public string Template;
    }

    class ProbabilityGenerator
    {
        private string InputFilename = "assets_flatted.xml";
        private string RewardpoolsFilename = "rewardpools.xml";
        private List<Item> AllItems;
        private LocaReader locaReader;

        private bool UseLocalizationReader = true; 

        public ProbabilityGenerator()
        {
            locaReader = new LocaReader();
            //ReadItemList needs LocaReader to be instantiated!!!
            AllItems = ReadItemList();
        }

        static void Main(string[] args)
        {

            ProbabilityGenerator pg = new ProbabilityGenerator();
            //pg.GenerateRewardPoolXML("patched.xml");

            if (args.Length == 2)
            {
                if (!args[1].EndsWith(".txt"))
                {
                    args[1] += ".txt";
                }
                pg.writeItemList(args[0], args[1]);
            }
            else if (args.Length == 1)
            {
                pg.writeItemList(args[0], "output.txt");
            }
            else if (args.Length == 1 && args[0] == "-default")
            {
                pg.DoDefaultProbabilityGeneration();
            }
            else
            {
                Console.WriteLine("Usage: ItemProbabilityReader.exe <rewardpoolGuid> <outputfilename>");
            }

        }

        private void DoDefaultProbabilityGeneration()
        {
            XmlNodeList allPools = GetAllRewardItemPools();

            foreach (XmlNode node in allPools) {
                var Guid = node.SelectSingleNode("GUID").InnerText;
                var TechnicalName = node.SelectSingleNode("Name").InnerText;
                string CategoryName = TechnicalName.Split(" ")[0];
                if (!TechnicalName.EndsWith("Common Reward Pool") && !TechnicalName.EndsWith("Uncommon Reward Pool") && !TechnicalName.EndsWith("Rare Reward Pool") && !TechnicalName.EndsWith("Epic Reward Pool") && !TechnicalName.EndsWith("Legendary Reward Pool"))
                    this.writeItemList(Guid, TechnicalName, CategoryName);
            }

            this.writeItemList("191510", "Huaca");
            this.writeItemList("191314", "Elise");

            this.writeItemList("190130", "Attractiveness_6");
            this.writeItemList("193374", "Attractiveness_7");
            this.writeItemList("193375", "Attractiveness_8");
            this.writeItemList("190131", "Attractiveness_9");
            this.writeItemList("193376", "Attractiveness_10");
            this.writeItemList("190132", "Attractiveness_11");
            this.writeItemList("193377", "Attractiveness_12");
            this.writeItemList("190133", "Attractiveness_13");
            this.writeItemList("190409", "Attractiveness_14");
            this.writeItemList("193373", "Attractiveness_15");
            this.writeItemList("193379", "Attractiveness_16");
            this.writeItemList("193380", "Attractiveness_17");
            this.writeItemList("193381", "Attractiveness_18");
            this.writeItemList("193382", "Attractiveness_19");
            this.writeItemList("193383", "Attractiveness_20");
            this.writeItemList("193384", "Attractiveness_21");
            /*
            this.writeItemList("191510", "Huaca");
            this.writeItemList("191314", "Elise");

            this.writeItemList("190167", "Bleakworth_Earlygame");
            this.writeItemList("190168", "Bleakworth_EarlyMidGame");
            this.writeItemList("190304", "Bleakworth_MidGame");
            this.writeItemList("190305", "Bleakworth_LateMidGame");
            this.writeItemList("190306", "Bleakworth_LateGame");
            this.writeItemList("190774", "Bleakworth_Endgame");

            this.writeItemList("190162", "Blake_Earlygame");
            this.writeItemList("190163", "Blake_EarlyMidGame");
            this.writeItemList("190164", "Blake_MidGame");
            this.writeItemList("190165", "Blake_LateMidGame");
            this.writeItemList("190166", "Blake_LateGame");
            this.writeItemList("192069", "Blake_Endgame");

            this.writeItemList("190362", "Isabel_MidGame");
            this.writeItemList("190363", "Isabel_LateMidGame");
            this.writeItemList("192072", "Isabel_LateGame");
            this.writeItemList("192073", "Isabel_Endgame");

            this.writeItemList("190554", "Kahina_Earlygame");
            this.writeItemList("190555", "Kahina_EarlyMidGame");
            this.writeItemList("190556", "Kahina_MidGame");
            this.writeItemList("190367", "Kahina_LateMidGame");
            this.writeItemList("190387", "Kahina_LateGame");
            this.writeItemList("192068", "Kahina_Endgame");

            this.writeItemList("193447", "Nate_Earlygame");
            this.writeItemList("193448", "Nate_EarlyMidGame");
            this.writeItemList("193449", "Nate_MidGame");
            this.writeItemList("193450", "Nate_LateMidGame");
            this.writeItemList("193451", "Nate_LateGame");
            this.writeItemList("193452", "Nate_Endgame");

            this.writeItemList("193322", "Mercier_Earlygame");
            this.writeItemList("193323", "Mercier_EarlyMidGame");
            this.writeItemList("193324", "Mercier_MidGame");
            this.writeItemList("193325", "Mercier_LateMidGame");
            this.writeItemList("193326", "Mercier_LateGame");
            this.writeItemList("193327", "Mercier_Endgame");

            this.writeItemList("193830", "Inuit_Earlygame");
            this.writeItemList("193831", "Inuit_EarlyMidGame");
            this.writeItemList("193832", "Inuit_MidGame");
            this.writeItemList("193833", "Inuit_LateMidGame");
            this.writeItemList("193834", "Inuit_LateGame");
            this.writeItemList("193835", "Inuit_Endgame");

            this.writeItemList("190130", "Attractiveness_6");
            this.writeItemList("193374", "Attractiveness_7");
            this.writeItemList("193375", "Attractiveness_8");
            this.writeItemList("190131", "Attractiveness_9");
            this.writeItemList("193376", "Attractiveness_10");
            this.writeItemList("190132", "Attractiveness_11");
            this.writeItemList("193377", "Attractiveness_12");
            this.writeItemList("190133", "Attractiveness_13");
            this.writeItemList("190409", "Attractiveness_14");
            this.writeItemList("193373", "Attractiveness_15");
            this.writeItemList("193379", "Attractiveness_16");
            this.writeItemList("193380", "Attractiveness_17");
            this.writeItemList("193381", "Attractiveness_18");
            this.writeItemList("193382", "Attractiveness_19");
            this.writeItemList("193383", "Attractiveness_20");
            this.writeItemList("193384", "Attractiveness_21");

    */
        }

        private void ReadProbabilities(String RewardPoolGuid, double Probability)
        {
            XmlDocument assets = new XmlDocument();
            assets.Load(new StreamReader(File.OpenRead(RewardpoolsFilename)));
            XmlNodeList LinkList = assets.SelectNodes("/Assets/Asset[Values/Standard/GUID = '" + RewardPoolGuid + "']/Values/RewardPool/ItemsPool/Item");
            XmlNodeList RewardPoolWeightList = assets.SelectNodes("/Assets/Asset[Values/Standard/GUID = '" + RewardPoolGuid + "']/Values/RewardPool/ItemsPool/Item/Weight");
            int sumOfWeights = 0;
            foreach (XmlNode weight in RewardPoolWeightList)
            {
                sumOfWeights += Convert.ToInt32(weight.InnerText);
            }
            int AllWeight = LinkList.Count + sumOfWeights - RewardPoolWeightList.Count;

            foreach (XmlElement e in LinkList)
            {
                XmlNode ItemLink = e.SelectSingleNode("ItemLink");


                if(ItemLink != null) {
                    //get the weight of the itemLink. 
                    int ItemLinkWeight = 1;
                    XmlNode Weight = e.SelectSingleNode("Weight");
                    if (Weight != null)
                    {
                        ItemLinkWeight = Convert.ToInt32(Weight.InnerText);
                    }

                    //get the probability for the ItemLink. It is Probability * ItemLinkWeight / AllWeight
                    double ItemLinkProbability = (Probability * ItemLinkWeight) / AllWeight;

                    if (AllItems.Exists(x => x.Guid == ItemLink.InnerText))
                    //if ItemLink is an Item
                    {
                        AllItems.Find(x => x.Guid == ItemLink.InnerText).Probability += ItemLinkProbability;
                    }
                    else if (ItemLinkProbability > 0)
                    {
                        ReadProbabilities(ItemLink.InnerText, ItemLinkProbability);
                    }
                }
            }
        }

        private XmlNodeList GetAllRewardItemPools() {
            XmlDocument RewardPools = new XmlDocument();
            RewardPools.Load(new StreamReader(File.OpenRead(RewardpoolsFilename)));

            return RewardPools.SelectNodes("/Assets/Asset[Template = 'RewardItemPool']/Values/Standard");
        }
        private void writeItemList(string guid, string Name) {
            writeItemList(guid, Name, "output");
        }
        private void writeItemList(string guid, string Name, string dir)
        {
            ResetProbabilities();
            ReadProbabilities(guid, 100);
            if (!Directory.Exists(dir)) {
                Directory.CreateDirectory(dir);
            }

            string Filename = dir + "/" + Name;
            FileStream fs;
            if (!File.Exists(Filename + ".txt"))
            {
                fs = File.Create(Filename + ".txt");
            }
            else {
                fs = File.Create(Filename + "_SecondIsland.txt");
            }
            
            using StreamWriter sw = new StreamWriter(fs);

            //we could clean up the ultimate fuckup of empty reward pools...
            //or we just ignore it, also an option.

            foreach (Item i in AllItems)
            {
                if (i.Probability != 0)
                {
                    sw.Write("GUID: {0}, Type: {4}, Rarity: {3}, Name: {1}, Probability: {2} \n", i.Guid, i.Name, i.Probability, i.Rarity, i.Template);
                    sw.Flush();
                }
            }
        }

        private void GenerateRewardPoolXML(string Filename)
        {
            FileStream fs = File.OpenRead(Filename);
            using StreamReader sr = new StreamReader(fs);

            XmlDocument assets = new XmlDocument();
            assets.Load(sr);
            XmlNodeList RewardPoolList = assets.SelectNodes("//Asset[Template = 'RewardItemPool' or Template = 'RewardPool']");

            using StreamWriter sw = new StreamWriter(File.Create(RewardpoolsFilename));
            sw.Write("<Assets>");
            foreach (XmlNode Node in RewardPoolList)
            {
                sw.Write(Node.OuterXml);
            }
            sw.Write("</Assets>");
            sw.Flush();

        }
        private List<Item> ReadItemList()
        {
            List<Item> Itemlist = new List<Item>();
            XmlDocument assets = new XmlDocument();
            assets.Load(new StreamReader(File.OpenRead(InputFilename)));
            XmlNodeList nodeList = assets.SelectNodes("/Assets/Asset[Template = 'ShipSpecialist' or Template = 'CultureItem' or Template = 'GuildhouseItem' or Template = 'TownhallItem' or Template = 'HarborOfficeItem' or Template = 'ActiveItem' or Template = 'ItemWithUI' or Template = 'VehicleItem']");

            foreach (XmlElement e in nodeList)
            {
                string guid = e.SelectSingleNode("Values/Standard/GUID").InnerText;

                string name;
                if (UseLocalizationReader) name = locaReader.getText(guid);
                else name = e.SelectSingleNode("Values/Standard/Name").InnerText;
                string rarity = "Common";
                string template = e.SelectSingleNode("Template").InnerText;
                XmlNode xmlRarity = e.SelectSingleNode("Values/Item/Rarity");
                if (xmlRarity != null)
                {
                    rarity = xmlRarity.InnerText;
                }

                Item i = new Item { Name = name, Guid = guid, Probability = 0, Rarity = rarity, Template = template };
                Itemlist.Add(i);
            }

            //maybe sort Itemlist based on item rarity now?
            Itemlist.Sort(CompareItems);
            return Itemlist;
        }

        private void ResetProbabilities() {
            foreach (Item i in AllItems) {
                i.Probability = 0; 
            }
        }

        private int CompareItems(Item x, Item y)
        {
            int i = CompareItemsByTemplate(x, y);
            if (i == 0)
            {
                i = CompareItemsByRarity(x, y);
                if (i == 0) {
                    i = CompareItemsByName(x, y);
                }
            }
            return i;
        }

        private int CompareItemsByName(Item x, Item y)
        {
            return x.Name.CompareTo(y.Name);
        }

        private int CompareItemsByRarity(Item x, Item y)
        {
            string StringX = x.Rarity;
            string StringY = y.Rarity;
            int IntX = 0;
            int IntY = 0;
            switch (StringX)
            {
                case "Quest":
                case "Narrative":
                case "Common":
                    IntX = 0; break;
                case "Uncommon":
                    IntX = 1; break;
                case "Rare":
                    IntX = 2; break;
                case "Epic":
                    IntX = 3; break;
                case "Legendary":
                    IntX = 4; break;
            }

            switch (StringY)
            {
                case "Quest":
                case "Narrative":
                case "Common":
                    IntY = 0; break;
                case "Uncommon":
                    IntY = 1; break;
                case "Rare":
                    IntY = 2; break;
                case "Epic":
                    IntY = 3; break;
                case "Legendary":
                    IntY = 4; break;
            }

            return IntX.CompareTo(IntY);
        }

        private int CompareItemsByTemplate(Item x, Item y) {
            int Compare = -1;
            switch (x.Template) {
                case "ShipSpecialist":
                    switch (y.Template) {
                        case "ShipSpecialist":
                            Compare = 0; break;
                        case "CultureItem":
                        case "GuildhouseItem":
                        case "TownhallItem":
                        case "HarborOfficeItem":
                        case "ActiveItem":
                        case "ItemWithUI":
                        case "VehicleItem":
                            Compare = 1; break;
                    }
                    break;
                case "CultureItem":
                    switch (y.Template)
                    {
                        case "CultureItem":
                            Compare = 0; break;
                        case "GuildhouseItem":
                        case "TownhallItem":
                        case "HarborOfficeItem":
                        case "ActiveItem":
                        case "ItemWithUI":
                        case "VehicleItem":
                            Compare = 1; break; 
                    }
                    break; 
                case "GuildhouseItem":
                    switch (y.Template)
                    {
                        case "GuildhouseItem":
                            Compare = 0; break;
                        case "TownhallItem":
                        case "HarborOfficeItem":
                        case "ActiveItem":
                        case "ItemWithUI":
                        case "VehicleItem":
                            Compare = 1; break;
                    }
                    break;
                case "TownhallItem":
                    switch (y.Template)
                    {
                        case "TownhallItem":
                            Compare = 0; break;
                        case "HarborOfficeItem":
                        case "ActiveItem":
                        case "ItemWithUI":
                        case "VehicleItem":
                            Compare = 1; break;
                    }
                    break;
                case "HarborOfficeItem":
                    switch (y.Template)
                    {
                        case "HarborOfficeItem":
                            Compare = 0; break;
                        case "ActiveItem":
                        case "ItemWithUI":
                        case "VehicleItem":
                            Compare = 1; break;
                    }
                    break;
                case "ActiveItem":
                    switch (y.Template)
                    {
                        case "ActiveItem":
                            Compare = 0; break;
                        case "ItemWithUI":
                        case "VehicleItem":
                            Compare = 1; break;
                    }
                    break;
                case "ItemWithUI":
                    switch (y.Template)
                    {
                        case "ItemWithUI":
                            Compare = 0; break;
                        case "VehicleItem":
                            Compare = 1; break;
                    }
                    break;
                case "VehicleItem":
                    switch (y.Template)
                    {
                        case "VehicleItem":
                            Compare = 0; break;
                    }
                    break;
            }

            return Compare;
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace geometryBySku
{
    class Program
    {
        static void Main(string[] args)
        {
            string skuLibPath = @"M:\Z_Software Assets\3ds Max\BorakaScriptPack_vol1\assignmanager\AssignManagerSystem\2_DatabaseLibrary\";
            string geometryToSheetPath = @"M:\Z_Software Assets\3ds Max\BorakaScriptPack_vol1\assignmanager\AssignManagerSystem\";
            string usedSkusPath = @"M:\Z_Software Assets\3ds Max\BorakaScriptPack_vol1\assignmanager\AssignManagerSystem\3_Adds\";

            //Reading the external file
            StreamReader sr = new StreamReader(skuLibPath + "skulib.txt");
            string data = sr.ReadLine();

            //create dictionary ,split rows to indexes and put them to library
            Dictionary<string, string> dict = new Dictionary<string, string>() { };

            while (data != null)
            {
                //Console.WriteLine(data);
                string[] values = data.Split(',');
                //dict.Add(values[0],values[1]);
                dict[values[0]] = values[1];
                //Console.WriteLine($"{dict[values[0]]}");
                data = sr.ReadLine();
            }

            //Here we start with the inputs ,create file and put the results in it
            int skuCounter = 0;
            int skuCounterNonGeometry = 0;
            string sku = "";

            StreamWriter sw = new StreamWriter(geometryToSheetPath + "geomToSheet.txt"); 
            StreamWriter swInputs = new StreamWriter(usedSkusPath + "usedSkus.txt"); 

            while (skuCounter < 20000)
            {
                sku = Console.ReadLine();
                string skuInput = sku;
                string endInput = sku;

                if (sku.Length >= 4)
                {
                    sku = sku.Remove(sku.Length - 4);
                }

                //if input is end! then break
                if (endInput == "end!")
                {
                    break;
                }
                else if (dict.ContainsKey(sku))
                {
                    Console.WriteLine($"{dict[sku]}");
                    sw.WriteLine(dict[sku]);
                    swInputs.WriteLine(skuInput);

                    skuCounter += 1;
                }
                else
                {
                    Console.WriteLine("n/a");
                    sw.WriteLine("n/a");
                    swInputs.WriteLine(skuInput);

                    skuCounterNonGeometry += 1;
                }
            }
            sw.Flush(); //transfer data from memory buffer to the disk
            sw.Close(); // close the file
            swInputs.Flush();
            swInputs.Close();
            sr.Close();

            Console.WriteLine($"Total assigned skus: {skuCounter}");
            Console.WriteLine($"Total UNassigned skus: {skuCounterNonGeometry}");
        }
    }
}

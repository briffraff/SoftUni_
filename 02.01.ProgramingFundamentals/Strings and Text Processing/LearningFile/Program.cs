using System;
using System.Collections.Generic;

namespace LearningFile
{
    class Program
    {
        static void Main(string[] args)
        {


            ////
            ////SPLIT
            //string text = "My name is Borislav!";
            //string[] textSplit = text.Split(" ");
            //Console.WriteLine(string.Join(", ", textSplit));

            //int counterOfIDX = 0;
            //////print with "foreach"
            //foreach (var word in textSplit)
            //{
            //    Console.WriteLine($"Index {counterOfIDX} = {textSplit[counterOfIDX]}");
            //    counterOfIDX++;
            //}

            //////print with "for"
            //for (int i = 0; i < textSplit.Length; i++)
            //{
            //    Console.WriteLine($"Index {i} = {textSplit[i]}");
            //}
            //Console.WriteLine();


            ////
            //////INDEXOF and INDEX
            //string text2 = "My name is Borislav!";
            //string[] textSplitidx = text2.Split(" ");
            //    ////not splitted
            //var idx = (text2.IndexOf("!")); // 19
            //Console.WriteLine(text2[idx]); // !
            //    ////splitted
            //var idxSplit = textSplitidx[3].IndexOf("!"); // [Borislav!] ; //8
            //Console.WriteLine(textSplitidx[3][idxSplit]); // !


            ////
            //////REPLACE
            //////replace by replace method
            //string text3 = "My name is Borislav!";
            //var replacedtText = text3.Replace("!", "!!!");
            //Console.WriteLine(replacedtText);

            //////replace by index
            //var replace = text3[text3.IndexOf("!")];
            //var replacedText2 = text3.Replace($"{replace}", "!!!");
            //Console.WriteLine(replacedText2); //  My name is Borislav!!!


            //
            ////SUBSTRING
            //string text4 = "My name is Borislav!";
            //// --
            //var idxOfchar = text4.IndexOf("B");
            //Console.WriteLine($"index starts from : {idxOfchar}");
            ////--
            //var split = text4.Split(" "); // my,name,is,borislav!
            //var bobiIdx = split[split.Length-1]; // [3]
            //var bobiEndchar = bobiIdx[bobiIdx.Length-1]; // !
            //var bobiLastcharIdx = bobiIdx.IndexOf(bobiEndchar); // 8

            //Console.WriteLine(text4.Substring(idxOfchar,bobiLastcharIdx)); // Borislav
            //Console.WriteLine(text4.Substring(11,8)); //Borislav


            //
            //REMOVE
            //string text4 = "My name is Borislav!";
            //var removed = text4.Remove(2,5); \\" name"
            //Console.WriteLine(removed); \\My is Borislav!


            //
            //CONTAINS 
            //string text5 = "My name is Borislav!";
            //var output = text5.Contains("NAME"); //NAME
            //Console.WriteLine(output);   //  False


            ////
            ////TOLOWER and TOUPPER
            ////--tolower
            //string text6 = "My name is Borislav!";
            //var outputText = text6.ToLower(); //my name is borislav!
            //Console.WriteLine(outputText);

            ////--toUpper
            //var upperText = text6.ToUpper(); //MY NAME IS BORISLAV!
            //Console.WriteLine(upperText);

            ////--split + toupper + replace
            //var splitTheText = text6.Split(" "); 
            //var idxToUpper = splitTheText[1].ToUpper();
            //Console.WriteLine(text6.Replace("name",idxToUpper)); //My NAME is Borislav!


            ////
            ////ENDSWIDTH
            //string text7 = "My name is Borislav!";
            //var end = text7.EndsWith("!"); // True
            //Console.WriteLine(end); // True


            ////
            ////COMPARETO
            //int a = 10;
            //int b = 5;
            //var compareTexts = a.CompareTo(b);
            //Console.WriteLine(compareTexts); // if a<b return -1; if equals = 0; if a>b return 1;


            ////
            ////EQUALS
            //int a = 4;
            //int b = 5;
            //var compareTexts = a.Equals(b);
            //Console.WriteLine(compareTexts); // if equals = True; if a>b return False;

        }
    }
}

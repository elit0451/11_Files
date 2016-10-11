using System;
using System.IO;

namespace _11_Files
{
    internal class StockIO
    {
        internal void WriteStock(StringWriter sw, Stock obj)
        {

            sw.WriteLine(obj.Symbol);
            sw.WriteLine(obj.PricePerShare);
            sw.WriteLine(obj.NumShares);
            sw.Close();
        }

        internal void WriteStock(FileInfo file, Stock obj)
        {
            FileStream fs = file.Create();
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(obj.Symbol);
            sw.WriteLine(obj.PricePerShare);
            sw.WriteLine(obj.NumShares);
            sw.Close();
            fs.Close();
        }

        internal Stock ReadStock(StringReader data)
        {
            Stock finalObj = new Stock(data.ReadLine(), Convert.ToDouble(data.ReadLine()), Convert.ToInt32(data.ReadLine()));

            return finalObj;
        }

        internal Stock ReadStock(FileInfo file)
        {
            FileStream fs = file.OpenRead();
            StreamReader sr = new StreamReader(fs);
            string symb = sr.ReadLine();
            double pps = Convert.ToDouble(sr.ReadLine());
            int numS = Convert.ToInt32(sr.ReadLine());

            sr.Close();
            fs.Close();

            Stock final = new Stock(symb,pps,numS);

            return final;

        }
    }
}
using System.IO;
using System.Collections.Generic;
using System;

namespace _11_Files
{
    internal class FileStockRepository : IStockRepository, IFileRepository
    {
        private DirectoryInfo repositoryDir;

        List<Stock> listOfStocks = new List<Stock>();

        private long id = 0;

        public FileStockRepository(DirectoryInfo repositoryDir)
        {
            this.repositoryDir = repositoryDir;
        }

        public long NextId()
        {
            id++;
            return id;
        }
        public void SaveStock(Stock stockObj)
        {
            stockObj.Id = (int)NextId();
            FileInfo file = new FileInfo(repositoryDir.FullName + "stock" + stockObj.Id + ".txt");
            FileStream fs = file.Create();
            StreamWriter sw = new StreamWriter(fs);

            listOfStocks.Add(stockObj);
            sw.WriteLine(stockObj.Symbol);
            sw.WriteLine(stockObj.PricePerShare);
            sw.WriteLine(stockObj.NumShares);
            sw.Close();
            fs.Close();
        }
        public Stock LoadStock(long idNumber)
        {
            FileInfo[] fileList = repositoryDir.GetFiles();
            string nameOfFile = "stock" + idNumber + ".txt";

            Stock finalObj = new Stock();

            foreach (FileInfo file in fileList)
            {

                if (nameOfFile == file.Name)
                {
                    FileStream fs = file.OpenRead();
                    StreamReader sr = new StreamReader(fs);
                    string symb = sr.ReadLine();
                    double pps = Convert.ToDouble(sr.ReadLine());
                    int numS = Convert.ToInt32(sr.ReadLine());

                    sr.Close();
                    fs.Close();

                    finalObj = new Stock(symb, pps, numS);
                }

            }



            return finalObj;
        }

        public List<Stock> FindAllStocks()
        {

            return listOfStocks;
        }

        public void Clear()
        {
            listOfStocks.Clear();
        }

        public string StockFileName(int number)
        {
            return "stock" + number + ".txt";
        }

        public string StockFileName(Stock number)
        {
            return "stock" + number.Id + ".txt";
        }

    }
}
using System.Collections.Generic;
using System.Collections;

namespace _11_Files
{
    internal interface IStockRepository
    {
        long NextId();
        void SaveStock(Stock stockObj);
        Stock LoadStock(long idNumber);

        List<Stock> FindAllStocks();

        void Clear();
    }
}
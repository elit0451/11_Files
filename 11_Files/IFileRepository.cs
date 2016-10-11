namespace _11_Files
{
    internal interface IFileRepository
    {
        string StockFileName(int number);
        string StockFileName(Stock number);

        void SaveStock(Stock stockObj);
    }
}
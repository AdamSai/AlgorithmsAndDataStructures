using System;

namespace UnionFind
{
    public class Program
    {
        static void Main(string[] args)
        {

        var pathToSmallFile = "/home/adam/Downloads/tinyUF.txt";
        var pathToMediumFile = "/home/adam/Downloads/mediumUF.txt";
        var pathToBigFile = "/home/adam/Downloads/largeUF.txt";
        
        // var qf = new QuickFind(pathToBigFile);
        // qf.ConnectFromTextFile();
        // Console.WriteLine(qf.ToString());
        // qf.Union(8, 1);
        // Console.WriteLine(qf.ToString());
        
        // var qu = new QuickUnion(pathToBigFile);
        // qu.ConnectFromTextFile();
        
        var wqu = new WeightedQuickUnion(pathToBigFile);
        wqu.ConnectFromTextFile();
    }
}

}
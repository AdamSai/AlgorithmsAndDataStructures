using System;

namespace UnionFind
{
    class FirstFind : IUnionFind
    {
        private int count;
        private int[] pointSets;

        public FirstFind(int count)
        {
            this.count = count;
            pointSets = new int[count];
            for (var i = 0; i < count; i++)
            {
                pointSets[i] = i;
            }
        }

        // connect p and q
        public void Union(int p, int q)
        {
            var setOfP = pointSets[p];
            var setOfQ = pointSets[q];
            for (var i = 0; i < pointSets.Length; i++)
            {
                if (pointSets[i] == setOfP) pointSets[i] = setOfQ;
            }

            count--;
        }

        // find nearest node
        public int Find(int p)
        {
            return pointSets[p];
        }

        // see if p and q are connected
        public bool Connected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        // return amount of grids
        public int Count()
        {
            return count;
        }

        public override string ToString()
        {
            var result = "";
            for (var i = 0; i < pointSets.Length; i++)
            {
                result += pointSets[i].ToString();
            }

            return result;
        }

        static void Main(string[] args)
        {
            var ff = new FirstFind(10);
            ff.Union(7, 8);
            Console.WriteLine(ff.ToString());
            ff.Union(5, 6);
            Console.WriteLine(ff.ToString());
            ff.Union(0, 1);
            Console.WriteLine(ff.ToString());
            ff.Union(7, 1);
            Console.WriteLine(ff.ToString());
            ff.Union(7, 8);
            Console.WriteLine(ff.ToString());
   

            Console.ReadLine();
        }
    }
}
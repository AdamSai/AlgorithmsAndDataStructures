using System;

namespace UnionFind
{
    public class WeightedUnion
    {
        private int count;
        private int[] pointSets;
        private int[] treeSize;

        public WeightedUnion(int count)
        {
            this.count = count;
            pointSets = new int[count];
            treeSize = new int[count];
            for (var i = 0; i < count; i++)
            {
                pointSets[i] = i;
                treeSize[0] = 1;
            }
            
        }

        // connect root of p and root of q
        public void Union(int p, int q)
        {
            var rootP = Find(p);
            var rootQ = Find(q);
            if (rootP == rootQ)
                return;
            // Set root of P to root of Q;
            pointSets[rootP] = rootQ;
            count--;
        }

        // find nearest node
        public int Find(int p)
        {
            // Climb up the tree and look at the next value if p does not equal the current pointSet value
            while (p != pointSets[p]) p = pointSets[p];
            return p;
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
            var qf = new QuickFind(10);
            for (int i = 0; i < 9; i++)
            {
                qf.Union(i, i+1);
                Console.WriteLine(qf.Count());
            }
        }
    }
}
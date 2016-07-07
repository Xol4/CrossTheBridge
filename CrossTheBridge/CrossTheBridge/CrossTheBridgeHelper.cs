using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossTheBridge
{
    /// <summary>
    /// A CrossTheBridge osztály privát metódusai a könnyebb tesztelhetőség érdekében itt található. 
    /// </summary>
    public class CrossTheBridgeHelper
    {
        /// <summary>
        /// Ellenőrzi, hogy érvényes-e a CrossTheBridge osztálynak átadott paraméter. Érvényes, ha az átadott összes sebesség nagyobb mint 0 
        /// </summary>
        /// <param name="peoples"></param>
        /// <returns></returns>
        public bool IsValid(List<int> peoples)
        {
            foreach (var person in peoples)
                if (person < 1)
                    return false;
            return true;
        }

        /// <summary>
        /// Ellenőrzi, hogy kész-e a feladat. Kész, ha az A oldalon már nincs több személy.
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        public bool IsDone(int[] part)
        {
            foreach (var person in part)
            {
                if (person >= 1) return false;
            }
            return true;
        }

        /// <summary>
        /// Megkeresi a leggyorsabb személyt az adott parton, és az indexével tér vissza.
        /// </summary>
        /// <param name="part"></param>
        /// <returns></returns>
        public int GetSmallestNumberIndex(int[] part)
        {
            for (int i = part.Length - 1; i > 0; i--)
                if (part[i] > 0)
                    return i;

            return -1;
        }

        /// <summary>
        /// Csökkenő sorba rendezi a paraméterként kapott listát.
        /// </summary>
        /// <param name="peoples"></param>
        /// <returns></returns>
        public List<int> Sort(List<int> peoples)
        {
            var sortedPeople = peoples.OrderByDescending(i => i).ToList();

            return sortedPeople;
        }

        /// <summary>
        /// Átküld két személyt az A partról a B partra. Ha a két leggyorsabb az A parton található, akkor őket. Ha nem akkor a két leglassabb személyt.
        /// </summary>
        /// <param name="APart"></param>
        /// <param name="BPart"></param>
        /// <returns></returns>
        public int SendPair(ref int[] APart, ref int[] BPart)
        {
            int result = 0;
            result = SendSmallestPair(ref APart, ref BPart);
            if (result == 0)
                result = SendLargestPair(ref APart, ref BPart);

            return result;
        }

        /// <summary>
        /// Ha a két leggyorsabb személy az AParton található, akkor átküldi őket az A partról a B partra.
        /// </summary>
        /// <param name="APart"></param>
        /// <param name="BPart"></param>
        /// <returns></returns>
        public int SendSmallestPair(ref int[] APart, ref int[] BPart)
        {
            if (APart[APart.Length - 1] != 0 && APart[APart.Length - 2] != 0)
            {
                BPart[APart.Length - 1] = APart[APart.Length - 1];
                APart[APart.Length - 1] = 0;
                BPart[APart.Length - 2] = APart[APart.Length - 2];
                APart[APart.Length - 2] = 0;
                return BPart[APart.Length - 1] > BPart[APart.Length - 2] ? BPart[APart.Length - 1] : BPart[APart.Length - 2];
            }
            return 0;
        }

        /// <summary>
        /// Átküldi az AParton található két leglassabb személyt a B partra.
        /// </summary>
        /// <param name="APart"></param>
        /// <param name="BPart"></param>
        /// <returns></returns>
        public int SendLargestPair(ref int[] APart, ref int[] BPart)
        {
            for (int i = 0; i < APart.Length; i++)
                if (APart[i] != 0)
                {
                    BPart[i] = APart[i];
                    APart[i] = 0;

                    for (int j = i + 1; j < APart.Length; j++)
                    {
                        if (APart[j] != 0)
                        {
                            BPart[j] = APart[j];
                            APart[j] = 0;
                            return BPart[i] > BPart[j] ? BPart[i] : BPart[j];
                        }
                    }
                }
            return 0;
        }

        /// <summary>
        /// Visszaküldi a leggyorsabb személyt a B partról az A partra.
        /// </summary>
        /// <param name="APart"></param>
        /// <param name="BPart"></param>
        /// <returns></returns>
        public int SendBack(ref int[] APart, ref int[] BPart)
        {
            int result = BPart[GetSmallestNumberIndex(BPart)];

            APart[GetSmallestNumberIndex(BPart)] = BPart[GetSmallestNumberIndex(BPart)];
            BPart[GetSmallestNumberIndex(BPart)] = 0;

            return result;
        }
    }
}

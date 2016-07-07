using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossTheBridge
{
    /*
    A megoldásom, hogy ha a paraméterként kapott sebességek közül a két leggyorsabb személy az A parton van, akkor ők mennek át a B partra. 
    Ha a két leggyorsabb közül valamelyik nincs az A parton, akkor az A parton lévő két leglassabb megy át, a lámpát pedig a B oldalon lévő leggyorsabb személy viszi vissza.  

       De visszalépéses algoritmussal is meglehetett volna csinálni, csak lassú lett volna.
    */


    public class CrossTheBridge : ICrossTheBridge
    {
        private int _result = 0;
        private int[] _APart, _BPart;
        private bool _isValid = true;
        CrossTheBridgeHelper _helper;

        /// <summary>
        /// Paraméterként a személyek sebességét várja
        /// /// </summary>
        /// <param name="peoples"></param>
        public CrossTheBridge(List<int> peoples)
        {
            this._helper = new CrossTheBridgeHelper();

            if (this._helper.IsValid(peoples))
            {
                var tempPeople = this._helper.Sort(peoples);

                this._APart = new int[peoples.Count];
                this._BPart = new int[peoples.Count];

                for (int i = 0; i < tempPeople.Count; i++)
                {
                    this._APart[i] = tempPeople[i];
                    this._BPart[i] = 0;
                }
            }
            else
                this._isValid = false;
        }

        /// <summary>
        /// Megadja a legoptimálisabb megoldást.
        /// </summary>
        public void Solve()
        {
            if (this._isValid)
            {
                while (!this._helper.IsDone(this._APart))
                {
                    this._result += this._helper.SendPair(ref this._APart, ref this._BPart);

                    if (!this._helper.IsDone(this._APart)) //Ha az A oldalon már nincs senki, akkor a B oldalról ne küldjön mást vissza
                        this._result += this._helper.SendBack(ref this._APart, ref this._BPart);
                }
            }
        }

        /// <summary>
        /// Visszatér az eredménnyel. 
        /// </summary>
        /// <returns></returns>
        public string GetResult()
        {
            if (this._isValid)
                return this._result.ToString();
            else
                return "Nem megfelelő paraméter! Egy személynek legalább 1 percbe telik átkelni a hídon!";
        }

    }
}

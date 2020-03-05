using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tpe_manager
{
    public class Manager
    {
        private readonly double _montant;
        public Manager(double montant)
        {
            _montant = montant;
        }

        public Change GetChange()
        {
            var result = TryGetCombinaisonsFor(_montant);
            result.Sort((a, b) => (a.Billet10 + a.Billet5 + a.Coin2) - (b.Billet10 + b.Billet5 + b.Coin2));
            return result.FirstOrDefault();
        }

        public List<Change> GetChangesForIteration(double chiffre, IEnumerable<int> possibleValues)
        {
            var result = new List<Change>();
            foreach (var item in possibleValues)
            {
                double rest = 0;
                var monnaie = TryMakeDivisionBy(chiffre, item, out rest);
                if (monnaie > 0 && rest == 0)
                {
                    var change = new Change();
                    SetMonnaie(change, item, monnaie);
                    result.Add(change);
                }

                if (monnaie > 0 && rest > 0)
                {
                    var res = GetChangesForIteration(rest, possibleValues.Except(possibleValues.Where(m=>m == item)));
                    res.ForEach(i => SetMonnaie(i, item, monnaie));
                    result.AddRange(res);
                }
            }
            return result;
        }

        public void SetMonnaie(Change change, int type, int monnaie)
        {
            switch (type)
            {
                case 2:
                    change.Coin2 = monnaie;
                    break;
                case 5:
                    change.Billet5 = monnaie;
                    break;
                case 10:
                    change.Billet10 = monnaie;
                    break;
            }
        }

        public List<Change> TryGetCombinaisonsFor(double chiffre)
        {
            var result = new List<Change>();

            var possibleMonnaies = new int[] { 2, 5, 10 };
            result.AddRange(GetChangesForIteration(_montant, possibleMonnaies.ToList()));

            return result;
        }

        public int TryMakeDivisionBy(double chiffre, int division, out double rest)
        {
            var res = chiffre / division;
            rest = chiffre % division;
            return (int)res;
        }
    }
}

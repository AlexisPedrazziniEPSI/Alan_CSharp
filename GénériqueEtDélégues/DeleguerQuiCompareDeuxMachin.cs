using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GénériqueEtDélégues
{
    /// <summary>
    /// Permet de comparer deux machins et de renvoyer un booléen
    /// pour coder la comparaison que l'on veut
    /// </summary>
    /// <typeparam name="TypeDeMachin"></typeparam>
    /// <param name="machin1"></param>
    /// <param name="machin2"></param>
    /// <returns>Résultat de la comparaison (booléen)</returns>
    public delegate bool DeleguerQuiCompareDeuxMachin<TypeDeMachin>(TypeDeMachin machin1, TypeDeMachin machin2); // délégué générique qui compare deux objets de type TypeDeMachin (de nimpeorte quel type)
}

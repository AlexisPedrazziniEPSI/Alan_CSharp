using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rappel_cours
{
    internal static class Outils // classe statique qui contient des méthodes statiques
    {

        /// <summary>
        /// Méthode d'extension qui met la première lettre de chaque mot en majuscule
        /// nottez l'utilisation du mot clé this devant le premier paramètre
        /// qui indique que cette méthode est une méthode d'extension du type string
        /// </summary>
        /// <param name="phrases"></param>
        /// <returns></returns>
        public static string MajusculeAuDebutDesMots(this string phrases) // méthode d'extension qui prend une chaine de caractère et renvoi une chaine de caractère
        {
            var mots = phrases.Split(' '); // on découpe la chaine de caractère en mots
            for (int i = 0; i < mots.Length; i++) // pour chaque mot
            {
                if (mots[i].Length > 0) // si le mot n'est pas vide
                {
                    mots[i] = char.ToUpper(mots[i][0]) + mots[i].Substring(1); // on met la première lettre en majuscule
                }
            }
            return string.Join(" ", mots); // on renvoi la chaine de caractère recomposée
        }

    }
}

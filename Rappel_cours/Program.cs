// See https://aka.ms/new-console-template for more information
using Rappel_cours;

Console.WriteLine("Hello, World!");

// // pour commentaire

/*
 * 
 *  commentaire sur plusieur lignes
 * 
 */

// déclaration de variable
int a = 0; // int
string nomDeVariable = "camelCasing";
int b; // création de la variable
b = 0; // définition de la variable séparé de sa création

int c = a + b;

// infférence de type
var d = 5; // var est un raccourcie qui va déduire le type
// on peux pas séparé la création de la définition de la variable en utilisant un var

var e = new InvalidCastException();
InvalidCastException f = new ();

// type anonyme
var voiture = new { Marque = "Renault", Modele = "Clio2" };
Console.WriteLine(voiture.Modele);

// type nullable
int? g = null;
bool? bb = null;

string? str = null; // un string est par défaut un nullablee

//tableau
int[] tableau = new int[5]; // tableau de 5 éléments
tableau[0] = 1;
int[] tableau2 = { 1, 2, 3, 4, 5 }; // tableau de 5 éléments

//tableau multidimensionnel
int[,] tableau3 = new int[2, 3]; // tableau de 2 lignes et 3 colonnes
tableau3[0, 0] = 1;
//tableau de tableau
int[][] tableau4 = new int[2][];
tableau4[0] = new int[3];
tableau4[0][0] = 1;
tableau4[0][1] = 2;

//Liste
List<int> liste = new List<int>();
liste.Add(1);
//Syntaxe rapide d'affectation
List<int> liste2 = new List<int> { 1, 2, 3, 4, 5 };

// Méthode d'extension
// On ajoute une méthode d'extension sans la modifier
var chaine = "Une chaine de caractère sans intérêt";
Console.WriteLine(chaine.MajusculeAuDebutDesMots());

// LINQ
// Language INtegrated Query
// c'est un ensemble de méthodes d'extensions sur IEnumerable<T>
// ça permet de manipuler les listes, tableau, etc...
// de manière plus simple et plus lisible
var ListeDEntiers = new List<int>() { 1,2,3,4,5,6,9,-4 };
// on veut les entiers positifs
// foreach (var entier in ListeDEntiers)
// {
//     if (entier > 0)
//     {
//         lespositifs.Add(entier)
//     }
// }
var lesPositifs = from i in ListeDEntiers
                  where i > 0
                  select i; // oui ça ressemble à du SQL
// alternative
var lesPositifs2 = ListeDEntiers.Where(i => i > 0).ToList();

var uneAutreListe = new List<int>() { 6,8,3,-2,9,7 };

// je cherche les élément  commun
var entierCommun = ListeDEntiers.Intersect(uneAutreListe).ToList();
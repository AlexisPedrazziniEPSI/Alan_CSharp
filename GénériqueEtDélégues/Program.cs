using GénériqueEtDélégues;

var liste = new Liste<int> {};
liste.Ajouter(1);
liste.Ajouter(2);
liste.Ajouter(3);

foreach (var item in liste)
{
    Console.WriteLine(item);
}
Console.WriteLine("--------------");
for (int i = 0; i < liste.Count; i++)
{
    Console.WriteLine(liste[i]);
}
Console.WriteLine("--------------");

liste.Trier((a, b) => a > b);
foreach (var item in liste)
{
    Console.WriteLine("Après tri : ");
    Console.WriteLine(item);
}
Console.WriteLine("--------------");

var listestring = new Liste<string> { };
listestring.Ajouter("un");
listestring.Ajouter("deux");
listestring.Ajouter("trois");

foreach (var item in listestring)
{
    Console.WriteLine(item);
}
Console.WriteLine("--------------");
listestring.Trier((a, b) => a.CompareTo(b) > 0);
foreach (var item in listestring)
{
    Console.WriteLine("Après tri : ");
    Console.WriteLine(item);
}
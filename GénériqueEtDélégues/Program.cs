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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GénériqueEtDélégues
{
    internal class Liste<T> : IEnumerable<T>
    {
        private readonly ArrayList list;
        public int Count => list.Count;
        public T this[int index] => (T)list[index];
        public Liste()
        {
            list = new ArrayList();
        }
        public void Ajouter(T element)
        {
            list.Add(element);
        }

        public IEnumerator<T> GetEnumerator() => list.GetEnumerator() as IEnumerator<T>;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Trier()
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if ((int)list[i] > (int)list[j])
                    {
                        var temp = list[i];
                        list[i] = list[j];
                        list[j] = temp;
                    }
                }
            }
        }
    }
}

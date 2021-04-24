using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Collection_lab
{
    public class CollectionType<T> : IEnumerable<T> where T : Human
    {
      
        private readonly List<T> container;
    
        public CollectionType()
        {
            container = new List<T>();
        }

        ~CollectionType(){

            Console.WriteLine("(-_-)");
        }
       
             
        public int Count{get { return container.Count; }}
       
      
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) 

                    throw new IndexOutOfRangeException();
                return container[index];
            }
            set
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                container[index] = value;
            }
        }
       
      
        public T GetByName(string name)
        {
            return container.FirstOrDefault( h => string.Compare(h.FirstName, name,StringComparison.InvariantCultureIgnoreCase) == 0);
        }
        public void Add(T human)
        {
            container.Add(human);
        }

        public T Remove(T human)
        {
            var element = container.FirstOrDefault(h => h == human);
            if (element != null)
            {
                container.Remove(element);
                return element;
            }
            throw new NullReferenceException();
        }
        public void Sort()
        {
            container.Sort();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return container.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();

        }
    

    }
}

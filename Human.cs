using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_lab
{
    public class Human : IHuman, IComparable<Human>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Height { get; set; }
        public double Weight { get; set; }
        public string FullName
        {
            get { return string.Format($"[{FirstName} {LastName}]");}
        }
    
        public int CompareTo(Human other)
        {
            return string.Compare(other.FullName, FullName,StringComparison.InvariantCultureIgnoreCase);
        }
        public override string ToString()
        {
            return string.Format($"[Class Human: \n FullName: {FullName}, Height: {Height}, Width: {Weight}]");
        }
      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_lab
{
    public class Worker : Human
    {
      
        public double Salary { get; set; }

        public override string ToString()
        {
            return string.Format($"[Class Worker: \n FullName: {FullName}, Height: {Height}, Width: {Weight}, Salary: {Salary}]\n");
        }
      
    }
}

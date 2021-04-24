using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collection_lab
{
    public class Student : Human
    {
        public string University { get; set; }
      
        public override string ToString()
        {
            return string.Format($"[Class Student: \n FullName: {FullName}, Height: {Height}, Width: {Weight}, University:{University}]\n");
        }
    }
}

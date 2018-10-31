using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEST_3010
{
   public class NewList
    {
        public int index { get; set; }
        public int value { get; set; }
       public NewList() { }
       public NewList(int index,int value)
        {
            this.index = index;
            this.value = value;
        }
        
    }
}

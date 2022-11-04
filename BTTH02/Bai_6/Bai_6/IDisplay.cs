using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai_6
{
    public interface IDisplay
    {
        string name { get; }
    }

    public class Cat : IDisplay
    {
        string _name;
        public Cat(string ten)
        {
            _name = ten;
        }
        public string name {
            //get { return "meo trang"; }
            get { return _name; }
            set { _name = value; } 
        }    
    }
    
    public class Dog : IDisplay
    {
        string _name;
        public Dog(string ten)
        {
            _name = ten;
        }
        public string name { 
            //get { return "cho_vang"; }
            get { return _name; }
            set { _name = value; }
        }
    }
    
}

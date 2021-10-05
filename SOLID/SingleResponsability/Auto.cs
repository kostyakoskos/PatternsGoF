using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Так плохо делать, не соблюдается принцип единой ответственности.
namespace SingleResponsability
{
    class Auto
    {
        public void constructor()
        {
            Console.WriteLine("Constructor");
        }
        public void getCarModel(){}
        public void saveCustomerOrder(){}
        public void setCArModel(){}
        public void getCustomerOrder(){}
        public void removeCustomerOrder(){}
        public void updateCarSet(){}
    }
}

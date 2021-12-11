using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Project1
{
    public class ChickenOrder
    {
        int quantity;
        int slice=0; 

        public ChickenOrder (int Quantity)
        {
            quantity = Quantity;
        }

        public ChickenOrder Clone()
        {
            var copy = this;
            copy.slice = 0;
            return copy;
        }

        public string Name()
        {
            return "Chicken";
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public void CutUp()
        {
            if (slice >= quantity)
                throw new Exception("Enough");
            slice++; 
        }

        public void Cook()
        {
            if (slice  < quantity)
                throw new Exception("Slice not equal quantity");
        }
    }
}



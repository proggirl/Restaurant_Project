using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Project1
{
    public class Employee
    {
        public static int numberOfOrder;
        public static dynamic lastOrder;

        public Employee()
        {

        }

        public dynamic NewRequest(int quantity, string foodName)
        {
            numberOfOrder++;
            if (numberOfOrder % 3 == 0)
            {
                foodName = (foodName == "Chicken") ? "Egg" : "Chicken";
            }

            if (foodName == "Chicken")
            {
                lastOrder = new ChickenOrder(quantity);
                return lastOrder;
            }
            else
            {
                lastOrder = new EggOrder(quantity);
                return lastOrder;
            }
        }

        public dynamic CopyRequest()
        {
            if (lastOrder == null)
                return new Exception("There is no any orders for copy");
            numberOfOrder++;
            lastOrder = lastOrder.Clone();
            return lastOrder;
        }

        public object Inspect()
        {
            if (lastOrder == null)
            {
                return new Exception("There is no any orders for copy");
            }

            return "#" + numberOfOrder + " Order: " + lastOrder.Name() + " quantity: " + lastOrder.GetQuantity();
        }

        public String PrepareFood()
        {
            try
            {
                var name = lastOrder?.Name();

                if (name == "Chicken")
                {
                    for (int i = 0; i < lastOrder.GetQuantity(); i++)
                        lastOrder.CutUp();
                    lastOrder.Cook();
                    return "Your order is prepared: " + name + " quantity: " + lastOrder.GetQuantity();

                }
                if (name == "Egg")
                {
                    for (int i = 0; i < lastOrder.GetQuantity(); i++)
                        lastOrder.Crack();
                    for (int i = 0; i < lastOrder.GetQuantity(); i++)
                        lastOrder.DiscardShell();
                    lastOrder.Cook();
                    return "You order prepared: " + name + " quantity: " + lastOrder.GetQuantity();
                }
            }catch(Exception ex)
            {
                return ex.Message;
            }
            return "There is no any order to prepare!";
        }

    }
}


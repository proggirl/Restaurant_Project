using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Project1
{
    public class EggOrder
    {
        int quantity;
        public static int numberOfOrder = 0;
        int quality;
        int crackCount = 0;
        int DiscardCount = 0;

        public EggOrder(int quantity)
        {
            this.quantity = quantity;
            numberOfOrder++;
            Random rand = new Random();
            quality = rand.Next(101);

        }

        public EggOrder Clone()
        {
            numberOfOrder++;
            var copy = this;
            copy.crackCount = 0;
            copy.DiscardCount = 0;
            return copy;
        }

        public string Name()
        {
            return "Egg";
        }

        public int GetQuantity()
        {
            return quantity;
        }

        public int? GetQuality()
        {
            if (numberOfOrder % 2 == 1)
            {
                return quality;
            }
            return null;
        }

        public void Crack()
        {
            if (quality <= 25)
            {
                throw new Exception("This simulates a rotten egg");
            }

            if (crackCount >= quantity)
                throw new Exception("Stop to crack eggs!");
            crackCount++;
        }

        public void DiscardShell()
        {
            if (DiscardCount >= quantity)
                throw new Exception("Stop to DiscardShell !");

            if (crackCount <= DiscardCount)
            {
                throw new Exception("You did't crack the eggs, that's why you couldn't throw the discardshell !");
            }

            DiscardCount++;
        }

        public void Cook()
        {
            if (crackCount < quantity)
                throw new Exception("Please crack all eggs!");
            if (DiscardCount < quantity)
                throw new Exception("Please throw all discardShell");
        }
    }
}


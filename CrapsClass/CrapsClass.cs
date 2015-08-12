using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrapsClass
{
    class CrapsClass
    {
        // Member Fields
        private char Phase; // "C" = come out, "P" = point
        private double PLBet; // pass line bet
        private double PLOdds; // pass line odds

        private bool HardFour;
        private bool HardSix;
        private bool HardEight;
        private bool HardTen;


        // Properties
        public char CurPhase
        {
            get { return Phase; }
            set { Phase = value; }
        }
        public double PassLineBet
        {
            get { return PLBet; }
            set { PLBet = value; }
        }
        public double PassLineOdds
        {
            get { return PLOdds; }
            set { PLOdds = value; }
        }
        public bool BetHardFour
        {
            get { return HardFour; }
            set { HardFour = value; }
        }
        public bool BetHardSix
        {
            get { return HardSix; }
            set { HardSix = value; }
        }
        public bool BetHardEight
        {
            get { return HardEight; }
            set { HardEight = value; }
        }
        public bool BetHardTen
        {
            get { return HardTen; }
            set { HardTen = value; }
        }

        // Methods
        public int Roll()
        {
            Random rnd = new Random();

            return (rnd.Next(1, 6));
        }
        public int Roll(int sides) // Not sure how you'd play craps with something other than a d6, but w/e...
        {
            Random rnd = new Random();

            return (rnd.Next(1, sides));
        }



    }
}

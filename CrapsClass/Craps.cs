using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace CrapsClass
{
    class Craps
    {
        // Member Fields
        private char Phase; // "C" = come out, "P" = point
        private double PLBet; // pass line bet
        private double PLOdds; // pass line odds
        private int Point;

        private double CurPLBet; // total current pass line bet
        private double CurOddsBet; // total current odds bry
        private double Bank;
        private bool HardFour;
        private bool HardSix;
        private bool HardEight;
        private bool HardTen;

        // Constructors

        public Craps () // Create a new instance of the game with default values
        {
            Phase = 'C';
            PLBet = 0.00;
            PLOdds = 0.00;
            Point = 0;
            CurPLBet = 0.00;
            CurOddsBet = 0.00;
            Bank = 5000.00;
            HardFour = false;
            HardSix = false;
            HardEight = false;
            HardTen = false;
        }

        // Properties

        public double CurBank
        {
            get { return Bank; }
            set { Bank = value; }
        }
        public char CurPhase
        {
            get { return Phase; }
            set { Phase = value; }
        }
        public int CurPoint
        {
            get { return Point; }
            set { Point = value; }
        }
        public double PassLineBet
        {
            get { return PLBet; }
           // set { PLBet = value; }  -- this needs additional logic 'n shit
        }
        public double PassLineOdds
        {
            get { return PLOdds; }
            //set { PLOdds = value; } -- this needs additional logic 'n shit
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



        private bool TestBet(double Bet) // internal function to test if user entered a valid bet
        {
            bool test;
            if (Bet + CurPLBet + CurOddsBet <= Bank)
                test = true;
            else
            {
                test = false;
                MessageBox.Show("Invalid Bet.", "Invalid Bet");
            }
            return test;
        }

        public void PlacePLBet (double Bet)
        {
            if (TestBet(Bet))
            {
                PLBet = Bet;

                if (CurPLBet == 0)
                    Bank -= CurPLBet;
                else
                    Bank = Bet;

                CurPLBet = Bet;

            }
        }


        public double GetPassLineResult(int DieOne, int DieTwo)
        {
            double dblResultMultiplier = 0;
            int DieSum = DieOne + DieTwo;

            if (Phase == 'C')
            {
                if (DieSum == 7 || DieSum == 11)
                    dblResultMultiplier = 1;
                else if (DieSum == 2 || DieSum == 3 || DieSum == 12)
                    dblResultMultiplier = 0;
                else
                {
                    Phase = 'P';
                    Point = DieSum;
                }
            }
            else
            {
                if (DieSum == 7)
                {
                    dblResultMultiplier = 0;
                    Phase = 'C';
                }
                else if (DieSum == Point)
                {
                    dblResultMultiplier = 1;
                    Phase = 'C';
                }

            }
            return dblResultMultiplier;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversi_PO
{
    public class Block
    {
        public bool? State;
        public Dictionary<string, short> Data=new Dictionary<string,short>();

        //public Block(){
        //    State = null;
        //    Data.Add("N", 0);
        //    Data.Add("NE", 0);
        //    Data.Add("E", 0);
        //    Data.Add("SE", 0);
        //    Data.Add("S", 0);
        //    Data.Add("SW", 0);
        //    Data.Add("W", 0);
        //    Data.Add("NW", 0);
        //}

        public Block(char C)
        {
            switch (C) 
            {
                case 'W': State = true;
                    break;
                case 'B': State = false;
                    break;
                case 'N': State = null;
                    break;
            }
            Data.Add("N", 0);
            Data.Add("NE", 0);
            Data.Add("E", 0);
            Data.Add("SE", 0);
            Data.Add("S", 0);
            Data.Add("SW", 0);
            Data.Add("W", 0);
            Data.Add("NW", 0);
        }
        public void ClearDict()
        {
            Data["N"] = 0;
            Data["NE"]=0;
            Data["E"]=0;
            Data["SE"]=0;
            Data["S"]=0;
            Data["SW"]=0;
            Data["W"]=0;
            Data["NW"]=0;
        }

        public void Place(char C)
        {
            switch (C) 
            {
                case 'W':State = true;
                    break;
                case 'B':State = false;
                    break;
                case 'N':State = null;
                    break;
            }
        }

        public void Flip()
        {
            if (State == null) return;
            if (State == true) State = false;
            else State = true;
        }
    }
}

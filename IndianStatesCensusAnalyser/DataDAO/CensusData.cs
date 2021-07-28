using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesCensusAnalyser.DataDAO
{
    public class CensusData
    {
        //Instance varaibles
        public string state;
        public string population;
        public long area;
        public long density;

        //Paramaterized constructor
        public CensusData(string state, string population, string area, string density)
        {
            this.state = state;
            this.population = population;
            this.area = Convert.ToUInt32(area);
            this.density = Convert.ToUInt32(density);
        }
    }
}

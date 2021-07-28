using System;
using System.Collections.Generic;
using System.Text;

namespace IndianStatesCensusAnalyser.DataDAO
{
    public class FullCensusData
    {
        //Instance varaibles
        public string state;
        public string population;
        public long area;
        public long density;
        public int serialNum;
        public string stateName;
        public int stateCode;

        //Parameterized constructor for statedata
        public FullCensusData(StateData stateData)
        {
            this.serialNum = stateData.serialNum;
            this.stateName = stateData.stateName;
            this.stateCode = stateData.stateCode;
        }
        //parameterized constructor for censusdata
        public FullCensusData(CensusData censusData)
        {
            this.state = censusData.state;
            this.population = censusData.population;
            this.area = censusData.area;
            this.density = censusData.density;
        }
    }
}

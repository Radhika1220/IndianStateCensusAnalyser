using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IndianStatesCensusAnalyser.DataDAO;
namespace IndianStatesCensusAnalyser
{
    public class IndianCensusAdapter : GetCensusAdapter
    {
        string[] censusData;
        //Creating a dictionary to store the indiancensusdata;
        Dictionary<string, FullCensusData> dataDic;

        //LOADCENSUSDATA METHOD
        public Dictionary<string,FullCensusData> LoadCensusData(string csvFilePath,string headers)
        {
            try
            {
                dataDic = new Dictionary<string, FullCensusData>();
                //Calling the getcensusdata method--->It returns the string array
                censusData = GetCensusData(csvFilePath, headers);
                //Skip the headers
                foreach (string data in censusData.Skip(1))
                {
                    //Delimiter is--> (,)..If not if condition will get executed
                    if (!data.Contains(","))
                    {
                        throw new CensusAnalyserException("Wrong delimiter", CensusAnalyserException.ExceptionType.INVALID_DELIMITER);
                    }
                    //Data seperated by comma and store in array
                    string[] col = data.Split(',');
                    //IndiaStateCode data
                    if (csvFilePath.Contains("IndiaStateCode.csv"))
                    {
                        dataDic.Add(col[0], new FullCensusData(new StateData(col[0], col[1], col[2])));
                    }
                    //IndiaStateCensusData
                    if (csvFilePath.Contains("IndiaStateCensusData.csv"))
                    {
                        dataDic.Add(col[0], new FullCensusData(new CensusData(col[0], col[1], col[2], col[3])));
                    }
                }
                return dataDic;
            }
            catch(CensusAnalyserException ex)
            {
                throw ex;
            }
        }
    }
}

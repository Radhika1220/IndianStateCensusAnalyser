using System;
using System.Collections.Generic;
using System.Text;
using IndianStatesCensusAnalyser.DataDAO;
namespace IndianStatesCensusAnalyser
{
    public class CsvAdapterFactory
    {
        //LOADCSVDATA METHOD
        public Dictionary<string, FullCensusData> LoadCsvData(CensusAnalyser.Country country,string csvFilePath,string headers)
        {
            try
            {
                //Checking the country 
                switch (country)
                {
                    case (CensusAnalyser.Country.INDIA):
                        {
                            return new IndianCensusAdapter().LoadCensusData(csvFilePath, headers);
                        }
                    default:
                        {
                            throw new CensusAnalyserException("NO SUCH COUNTRY", CensusAnalyserException.ExceptionType.NO_SUCH_COUNTRY);
                        }
                }
            }
            catch(CensusAnalyserException ex)
            {
                throw ex;
            }

        }
    }
}

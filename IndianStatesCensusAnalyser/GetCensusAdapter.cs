using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IndianStatesCensusAnalyser
{
    public class GetCensusAdapter
    {
        //GETCENSUSDATA METHOD
        public string[] GetCensusData(string csvFilePath, string headers)
        {
            try
            {
                string[] censusData;
                //Checking file is exists or not
                if (!File.Exists(csvFilePath))
                {
                    throw new CensusAnalyserException("File Not Found", CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
                }
                //Checking the path if it is csv extension or not
                if (Path.GetExtension(csvFilePath) != ".csv")
                {
                    throw new CensusAnalyserException("Invalid File Extension", CensusAnalyserException.ExceptionType.INVALID_FILE_EXTENSION);
                }
                //Read the data in specified path and store in censusdata
                censusData = File.ReadAllLines(csvFilePath);
                //checking the headers which is seperated by comma or not.
                if (censusData[0] != headers)
                {
                    throw new CensusAnalyserException("Invalid Headers", CensusAnalyserException.ExceptionType.INVALID_HEADERS);
                }
                return censusData;

            }
            catch (CensusAnalyserException ex)
            {
                throw ex;
            }

        }
    }
}

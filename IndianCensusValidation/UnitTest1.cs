using IndianStatesCensusAnalyser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using IndianStatesCensusAnalyser.DataDAO;
namespace IndianCensusValidation
{
    [TestClass]
    public class UnitTest1
    {
        //Initializing the path 
        string stateCensusDataPath = @"C:\Users\Radhika\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaStateCensusData.csv";
        string wrongstateCensusDataPath = @"C:\Users\Radhika\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaStateCensusD.csv";
        string wrongstateCensusDataCSVPath = @"C:\Users\Radhika\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaStateCensusData.txt";
        string wrongDelimiterstateCensusDataCSVPath = @"C:\Users\Radhika\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\WrongDelimiterIndiaStateCensusData.csv";
        string wrongHeaderstateCensusDataCSVPath = @"C:\Users\Radhika\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\WrongHeaderIndiaStateCensusData.csv";
        string stateCodeDataPath = @"C:\Users\Radhika\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaStateCode.csv";
        string wrongStateCodeDataPath = @"C:\Users\Radhika\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\IndiaStateC.csv";
        string wrongStateCodeDataCSVPath = @"C:\Users\Radhika\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\WrongStateCodeDataCSVPath.txt";
        string wrongDelimiterStateCodeDataPath = @"C:\Users\Radhika\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\WrongDelimiterStateCodeDataPath.csv";
        string wrongHeaderStateCodeDataPath = @"C:\Users\Radhika\source\repos\IndianStatesCensusAnalyser\IndianStatesCensusAnalyser\WrongHeaderStateCodeDataPath.csv";
        CsvAdapterFactory csv = null;
        Dictionary<string, FullCensusData> totalRecords;
        Dictionary<string, FullCensusData> stateRecords;

        [TestInitialize]
        //Initialize the record value
        public void Setup()
        {

            csv = new CsvAdapterFactory();
            totalRecords = new Dictionary<string, FullCensusData>();
            stateRecords = new Dictionary<string, FullCensusData>();
        }
        /// <summary>
        /// UC1-TC1.1--->Returns the count of records present in IndianstateCensusData
        /// </summary>
        [TestMethod]
        public void Given_State_Census_Return_CountOf_Records()
        {
            stateRecords = csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCensusDataPath, "State,Population,AreaInSqKm,Density");
            Assert.AreEqual(9, stateRecords.Count);

        }
        /// <summary>
        /// UC1-TC1.2--->Handle the file not found custom exception
        /// </summary>
        [TestMethod]
        public void Incorrect_File_Return_CustomException()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongstateCensusDataPath, "State,Population,AreaInSqKm,Density"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customEx.exception);
        }
        /// <summary>
        /// UC1-TC1.3--->Handle the wrong file extension path using custom exception
        /// </summary>
        [TestMethod]
        public void Incorrect_File_Extension_Return_CustomException()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongstateCensusDataCSVPath, "State,Population,AreaInSqKm,Density"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_EXTENSION, customEx.exception);
        }
        /// <summary>
        /// UC1-TC1.4--->Wrong delimiter in csvfile and handling the custom exception
        /// </summary>
        [TestMethod]
        public void Incorrect_Delimiter_In_CSVFile_Return_CustomException()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongDelimiterstateCensusDataCSVPath, "State,Population,AreaInSqKm,Density"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, customEx.exception);
        }
        /// <summary>
        /// UC1-TC1.5--->Wrong headers in csvfile and handling the custom exception
        /// </summary>
        [TestMethod]

        public void Incorrect_Headers_In_CSVFile_Return_CustomException()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderstateCensusDataCSVPath, "State,Population,AreaInSqKm,Density"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, customEx.exception);
        }
        /// <summary>
        /// UC2-TC1.1--->Returns the count of state code data in csv file
        /// </summary>
        [TestMethod]
        public void State_Code_Return_CountOf_Records()
        {
            var totalRecords=csv.LoadCsvData(CensusAnalyser.Country.INDIA, stateCodeDataPath, "SerailNo,StateName,StateCode");
            Assert.AreEqual(16, totalRecords.Count);
        }
        /// <summary>
        /// UC2-TC1.2--->Handle the file not found custom exception
        /// </summary>
        [TestMethod]
        public void Incorrect_File_Return_CustomException_State_Code()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeDataPath, "SerailNo,StateName,StateCode"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customEx.exception);
        }
        /// <summary>
        /// UC2-TC1.3--->Handle the wrong file extension path using custom exception
        /// </summary>
        [TestMethod]
        public void Incorrect_File_Extension_Return_CustomException_For_StateCode()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongStateCodeDataCSVPath, "SerailNo,StateName,StateCode"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_EXTENSION, customEx.exception);
        }
        /// <summary>
        /// UC2-TC1.4--->Wrong delimiter in csvfile and handling the custom exception
        /// </summary>
        [TestMethod]
        public void Incorrect_Delimiter_In_CSVFile_Return_CustomException_For_StateCode()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongDelimiterStateCodeDataPath, "SerailNo,StateName,StateCode"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_DELIMITER, customEx.exception);
        }
        /// <summary>
        /// UC2-TC1.5--->Wrong headers in csvfile and handling the custom exception
        /// </summary>
        [TestMethod]

        public void Incorrect_Headers_In_CSVFile_Return_CustomException_For_StateCode()
        {
            var customEx = Assert.ThrowsException<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCodeDataPath,"State,Population,AreaInSqKm,Density"));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_HEADERS, customEx.exception);
        }
    }
}

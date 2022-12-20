using NUnit.Framework;
using System.Collections.Generic;
using System;
using IndianStateCensus;
using IndianStateCensus.DataDAO;

namespace IndianStateCensusNunitTest
{
    public class Tests
    {
        //state census paths
        string stateCensusPath = @"C:\Users\HP\Desktop\RFP222\IndianStateCensus\IndianStateCensus\CSVFiles\IndiaStateCensusData.csv";
        string delimiterStateCensusPath = @"C:\Users\HP\Desktop\RFP222\IndianStateCensus\IndianStateCensus\CSVFiles\DelimiterIndiaStateCensusData.csv";

        //state code paths
        string stateCodePath = @"C:\Users\HP\Desktop\RFP222\IndianStateCensus\IndianStateCensus\CSVFiles\IndiaStateCode.csv";
        string delimiterStateCodePath = @"C:\Users\HP\Desktop\RFP222\IndianStateCensus\IndianStateCensus\CSVFiles\DelimiterIndiaStateCode.csv";

        //wrong state census paths
        string wrongCensusPath = @"C:\Users\HP\Desktop\RFP222\IndianStateCensus\IndianStateCensus\CSVFiles\IndiaStateData.csv";
        string wrongHeaderStateCensusPath = @"C:\Users\HP\Desktop\RFP222\IndianStateCensus\IndianStateCensus\CSVFiles\WrongIndiaStateCensusData.csv";


        //wrong state code paths
        string wrongStateCodePath = @"C:\Users\HP\Desktop\RFP222\IndianStateCensus\IndianStateCensus\CSVFiles\IndiaCode.csv";
        string wrongTypeStateCodePath = @"C:\Users\HP\Desktop\RFP222\IndianStateCensus\IndianStateCensus\CSVFiles\IndiaStateCode.txt";
        string wrongHeaderStateCodePath = @"C:\Users\HP\Desktop\RFP222\IndianStateCensus\IndianStateCensus\CSVFiles\WrongIndiaStateCode.csv";

        IndianStateCensus.CSVAdapterFactory csv = null;
        //Dictionary<string, CensusDTO> totalRecords;
        Dictionary<string, CensusDataDAO> stateRecords;

        [SetUp]
        public void SetUp()
        {
            csv = new IndianStateCensus.CSVAdapterFactory();
            // totalRecords = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDataDAO>();
        }
        /// TC 1.1
        /// Giving the correct path it should return the total count from the census
        [Test]
        public void GivenStateCensusCSVShouldReturnRecords()
        {
            stateRecords = csv.LoadCsvData(IndianStateCensus.CensusAnalyser.Country.INDIA, stateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, stateRecords.Count);
        }
        /// TC 1.2
        /// Giving incorrect path should return file not found custom exception
        [Test]
        public void GivenIncorrectFileShouldThrowCustomException()
        {
            try
            {
                var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
                //total no of rows excluding header are 29 in indian state census data.
                //Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, customException.exception);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
            //Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.FILE_NOT_FOUND);
        }
        /// TC 1.3
        /// Giving wrong type of path should return invalid file type custom exception
        [Test]
        public void GivenWrongTypeReturnsCustomException()
        {
            try
            {
                var customException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongTypeStateCodePath, "SrNo,State Name,TIN,StateCode"));
                Assert.AreEqual(customException.exception, CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// TC 1.4
        /// Giving wrong delimiter should return incorrect delimiter custom exception
        [Test]
        public void GivenWrongDelimeterReturnsCustomException()
        {
            try
            {
                var censusException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, delimiterStateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
                Assert.AreEqual(censusException.exception, CensusAnalyserException.ExceptionType.INCOREECT_DELIMITER);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        /// TC 1.5
        /// Giving wrong header type should return incorrect header type custom exception
        [Test]
        public void GivenWrongHeaderReturnsCustomException()
        {
            try
            {
                var censusException = Assert.Throws<CensusAnalyserException>(() => csv.LoadCsvData(CensusAnalyser.Country.INDIA, wrongHeaderStateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm"));
                Assert.AreEqual(censusException.exception, CensusAnalyserException.ExceptionType.INCORRECT_HEADER);
            }
            catch (CensusAnalyserException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
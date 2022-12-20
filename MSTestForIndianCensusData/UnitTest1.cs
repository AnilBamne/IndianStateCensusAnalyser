using IndianStateCensus.DataDAO;
using IndianStateCensus.DTO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Collections.Generic;
using Assert = NUnit.Framework.Assert;

namespace MSTestForIndianCensusData
{
    [TestClass]
    public class UnitTest1
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

        [SetCulture]
        public void SetUp()
        {
            csv = new IndiaCensusDataDemo.CSVAdapterFactory();
            // totalRecords = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDataDAO>();
        }

        /// TC 1.1
        /// Giving the correct path it should return the total count from the census
        [TestMethod]
        public void GivenStateCensusCSVShouldReturnRecords()
        {
            stateRecords = csv.LoadCsvData(IndianStateCensus.CensusAnalyser.Country.INDIA, stateCensusPath, "State,Population,AreaInSqKm,DensityPerSqKm");
            Assert.AreEqual(29, stateRecords.Count);
        }
    }
}

using ProcessorShared;
using MobileRaterProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServiceTestManager.Models;

namespace TestCaseService
{
    /// <summary>
    /// The content processor factory responsible for generating all processors
    /// </summary>
    public static class ProcessorFactory
    {
        /// <summary>
        /// Get a processor based on content type, let the processor handle the response from the server.
        /// </summary>
        /// <param name="responseFromServer">The content (before parse to type) that the server sent back as a response</param>
        /// <param name="contentType">The content type that will determine the processor</param>
        /// <param name="expectedValues">The list (can be one item) of expected values to compare the co</param>
        /// <returns>A processor based on content type.</returns>
        public static IProcessor Processor(string responseFromServer, ProcessorType processorType, List<ExpectedValue> expectedValues)
        {
            if(string.IsNullOrEmpty(responseFromServer))
                throw new ArgumentNullException(responseFromServer, "The response from the server can not be null");

            switch (processorType)
            {
                case ProcessorType.MobileRater:
                    return new Processor(responseFromServer, expectedValues);
                default:
                    throw new NotImplementedException($"The processor type {processorType} is not supported");
            }

        }
    }
}

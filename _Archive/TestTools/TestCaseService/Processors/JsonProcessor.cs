//using Newtonsoft.Json;
//using Newtonsoft.Json.Linq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WebServiceTestManager.Models;

//namespace TestCaseService
//{
//    public class JsonProcessor : IProcessor
//    {
//        #region Private Members
//        /// <summary>
//        /// A base object to use in the process method
//        /// </summary>
//        private JArray _jArray;

//        /// <summary>
//        /// A list of expected values to compare to the json content we get on construction of the class
//        /// </summary>
//        private List<ExpectedValue> _expectedValues;
//        #endregion

//        public JsonProcessor(string jsonContent, List<ExpectedValue> expectedResults)
//        {
//            var array = jsonContent[0] == '[';
//            _jArray = JArray.Parse(jsonContent);
//            _expectedValues = expectedResults;
//        }

//        public ProcessorResult Process()
//        {
//            var errorList = new List<string>();
//            if (_jArray == null)
//                throw new ArgumentNullException("_jObject", "Can not have a null jobject");

//            //Console.WriteLine(_jArray);

//            //foreach (var item in _expectedValues)
//            //{
//            //    Console.WriteLine($"name: {item.PropertyName} value: {item.ExpectedResult}");
//            //}

//            try
//            {
//                foreach (var item in _expectedValues)
//                {
//                    bool found = false;

//                    foreach (var response in _jArray)
//                    {
//                        dynamic key = response.SelectToken("ProductName");
//                        dynamic value = response.SelectToken("Rate");
//                        value = Convert.ChangeType(value, value.GetType());
//                        if (item.PropertyName == key.Value && item.ExpectedResult.Equals(value))//value.Value)
//                        {
//                            found = true;
//                        }
//                    }

//                    if (!found)
//                        errorList.Add($"Unable to find { item.PropertyName} with a value of {item.ExpectedResult}");
//                }
//            }
//            catch (Exception ex)
//            {
//                errorList.Add($"Encountered an error. {ex.Message}");
//            }

//            return new ProcessorResult(){ Pass = errorList.Count == 0, ErrorList = errorList};
//        }
//    }
//}

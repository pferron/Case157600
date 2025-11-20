using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProcessorShared;
using System;
using System.Collections.Generic;
using WebServiceTestManager.Models;

namespace MobileRaterProcessor
{
    public enum Types
    {
        Integer = 0,
        Decimal = 1,
        Text = 2,
        Boolean = 3
    }
    public class Processor : IProcessor
    {
        private List<ExpectedValue> _expectedValues;
        private List<RateResponseModel> _response;
        private JArray _jArray;
        public Processor(string json, List<ExpectedValue> expectedValues)
        {
            _response = JsonConvert.DeserializeObject<List<RateResponseModel>>(json);
            _expectedValues = expectedValues;
            _jArray = JArray.Parse(json);
        }

        /// <summary>
        /// Process all Mobile rater requests
        /// </summary>
        /// <returns>A <see cref="ProcessorResult"/></returns>
        public ProcessorResult Process()
        {
            var errors = new List<string>();
            try
            {
                foreach (var item in _expectedValues)
                {
                    bool found = false;

                    foreach (var response in _jArray)
                    {
                        //convert the value and the expected value to the correct types.
                        dynamic value = response.SelectToken(item.PropertyName);
                        value = Convert.ChangeType(value, SwitchType((Types)item.Type));
                        dynamic expectedValue = Convert.ChangeType(item.ExpectedResult, SwitchType((Types)item.Type));


                        if (value == expectedValue)
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                        errors.Add("Unable to find");
                }
                return new ProcessorResult { Pass = errors.Count == 0, ErrorList = errors };
            }
            catch (Exception)
            {
                errors.Add("An unknown error occured");
                return new ProcessorResult { Pass = false, ErrorList = errors };
            }
        }

        /// <summary>
        /// Switch the type of a given ExpectedValue based on the Types enum
        /// </summary>
        /// <param name="types">the type of primitave data type we want to handle the cast to</param>
        /// <returns>The respective type f</returns>
        public Type SwitchType(Types types)
        {
            switch (types)
            {
                case Types.Integer:
                    return typeof(int);
                case Types.Decimal:
                    return typeof(decimal);
                case Types.Text:
                    return typeof(string);
                case Types.Boolean:
                    return typeof(bool);
                default:
                    throw new ArgumentOutOfRangeException(nameof(types));
            }
        }
    }
}

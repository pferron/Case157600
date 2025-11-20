
using System;
using System.Collections.Generic;
using System.Linq;
namespace WOW.FipUtilities
{
    /// <summary>
    /// Simple class for converting state codes and state names to abbreviations.
    /// </summary>
    static class StateHelper
    {
        private static List<StateInfo> states = new List<StateInfo>() { 
            new StateInfo { StateCode = 1, StateAbbreviation = "AL", StateName = "Alabama" },
            new StateInfo { StateCode = 2, StateAbbreviation = "AZ", StateName = "Arizona" },
            new StateInfo { StateCode = 3, StateAbbreviation = "AR", StateName = "Arkansas" },
            new StateInfo { StateCode = 4, StateAbbreviation = "CA", StateName = "California" },
            new StateInfo { StateCode = 5, StateAbbreviation = "CO", StateName = "Colorado" },
            new StateInfo { StateCode = 6, StateAbbreviation = "CT", StateName = "Connecticut" },
            new StateInfo { StateCode = 7, StateAbbreviation = "DE", StateName = "Delaware" },
            new StateInfo { StateCode = 8, StateAbbreviation = "DC", StateName = "District Of Columbia" },
            new StateInfo { StateCode = 9, StateAbbreviation = "FL", StateName = "Florida" },
            new StateInfo { StateCode = 10, StateAbbreviation = "GA", StateName = "Georgia" },
            new StateInfo { StateCode = 11, StateAbbreviation = "ID", StateName = "Idaho" },
            new StateInfo { StateCode = 12, StateAbbreviation = "IL", StateName = "Illinois" },
            new StateInfo { StateCode = 13, StateAbbreviation = "IN", StateName = "Indiana" },
            new StateInfo { StateCode = 14, StateAbbreviation = "IA", StateName = "Iowa" },
            new StateInfo { StateCode = 15, StateAbbreviation = "KS", StateName = "Kansas" },
            new StateInfo { StateCode = 16, StateAbbreviation = "KY", StateName = "Kentucky" },
            new StateInfo { StateCode = 17, StateAbbreviation = "LA", StateName = "Louisiana" },
            new StateInfo { StateCode = 18, StateAbbreviation = "ME", StateName = "Maine" },
            new StateInfo { StateCode = 19, StateAbbreviation = "MD", StateName = "Maryland" },
            new StateInfo { StateCode = 20, StateAbbreviation = "MA", StateName = "Massachusetts" },
            new StateInfo { StateCode = 21, StateAbbreviation = "MI", StateName = "Michigan" },
            new StateInfo { StateCode = 22, StateAbbreviation = "MN", StateName = "Minnesota" },
            new StateInfo { StateCode = 23, StateAbbreviation = "MS", StateName = "Mississippi" },
            new StateInfo { StateCode = 24, StateAbbreviation = "MO", StateName = "Missouri" },
            new StateInfo { StateCode = 25, StateAbbreviation = "MT", StateName = "Montana" },
            new StateInfo { StateCode = 26, StateAbbreviation = "NE", StateName = "Nebraska" },
            new StateInfo { StateCode = 27, StateAbbreviation = "NV", StateName = "Nevada" },
            new StateInfo { StateCode = 28, StateAbbreviation = "NH", StateName = "New Hampshire" },
            new StateInfo { StateCode = 29, StateAbbreviation = "NJ", StateName = "New Jersey" },
            new StateInfo { StateCode = 30, StateAbbreviation = "NM", StateName = "New Mexico" },
            new StateInfo { StateCode = 31, StateAbbreviation = "NY", StateName = "New York" },
            new StateInfo { StateCode = 32, StateAbbreviation = "NC", StateName = "North Carolina" },
            new StateInfo { StateCode = 33, StateAbbreviation = "ND", StateName = "North Dakota" },
            new StateInfo { StateCode = 34, StateAbbreviation = "OH", StateName = "Ohio" },
            new StateInfo { StateCode = 35, StateAbbreviation = "OK", StateName = "Oklahoma" },
            new StateInfo { StateCode = 36, StateAbbreviation = "OR", StateName = "Oregon" },
            new StateInfo { StateCode = 37, StateAbbreviation = "PA", StateName = "Pennsylvania" },
            new StateInfo { StateCode = 38, StateAbbreviation = "RI", StateName = "Rhode Island" },
            new StateInfo { StateCode = 39, StateAbbreviation = "SC", StateName = "South Carolina" },
            new StateInfo { StateCode = 40, StateAbbreviation = "SD", StateName = "South Dakota" },
            new StateInfo { StateCode = 41, StateAbbreviation = "TN", StateName = "Tennessee" },
            new StateInfo { StateCode = 42, StateAbbreviation = "TX", StateName = "Texas" },
            new StateInfo { StateCode = 43, StateAbbreviation = "UT", StateName = "Utah" },
            new StateInfo { StateCode = 44, StateAbbreviation = "VA", StateName = "Virginia" },
            new StateInfo { StateCode = 45, StateAbbreviation = "WA", StateName = "Washington" },
            new StateInfo { StateCode = 46, StateAbbreviation = "WV", StateName = "West Virginia" },
            new StateInfo { StateCode = 47, StateAbbreviation = "WI", StateName = "Wisconsin" },
            new StateInfo { StateCode = 48, StateAbbreviation = "WY", StateName = "Wyoming" },
            new StateInfo { StateCode = 49, StateAbbreviation = "VT", StateName = "Vermont" },
            new StateInfo { StateCode = 50, StateAbbreviation = "AK", StateName = "Alaska" },
            new StateInfo { StateCode = 51, StateAbbreviation = "HI", StateName = "Hawaii" },
            new StateInfo { StateCode = 52, StateAbbreviation = "PR", StateName = "PuertoRico" },
            new StateInfo { StateCode = 53, StateAbbreviation = "--", StateName = "Other" }
        };

        /// <summary>
        /// Returns the state abbreviation associated with the provided state ID.
        /// </summary>
        /// <param name="stateId">ID of the state</param>
        /// <returns>2 character abbreviation of the state</returns>
        /// <exception cref="WOW.FipUtilities.StateNotFoundException">The input value was not found in the list of states available.</exception>
        public static string GetStateAbbreviation(int stateId)
        {
            try
            {
                var state = states.Single(s => s.StateCode == stateId);

                return state.StateAbbreviation;
            }
            catch (Exception ex)
            {
                throw new StateNotFoundException(String.Format("Unable to locate a state value using state ID '{0}'.", stateId), ex);
            }

        }

        /// <summary>
        /// Returns the state abbreviation associated with the provided state name.
        /// </summary>
        /// <param name="stateName">Name of state</param>
        /// <returns>2 character abbreviation of the state</returns>
        /// <exception cref="WOW.FipUtilities.StateNotFoundException">The input value was not found in the list of states available.</exception>
        public static string GetStateAbbreviation(string stateName)
        {
            try
            {
                var state = states.Single(s => s.StateName.Equals(stateName, StringComparison.OrdinalIgnoreCase));

                return state.StateAbbreviation;
            }
            catch (Exception ex)
            {
                throw new StateNotFoundException(String.Format("Unable to locate a state abbreviation using state name '{0}'.", stateName), ex);
            }
        }
    }
}

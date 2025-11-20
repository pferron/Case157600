using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wow.IllustrationCommonModels.Request;

namespace Wow.HubIllustrationService.Code
{
    public class StoneRiverClass
    {
        static bool IsPreferred(string rating)
        {
            return rating == "P";
        }
        static bool IsSuperPreferred(string rating)
        {
            return rating == "SP";
        }
        static bool IsNone(string rating)
        {
            return rating == null;
        }
        static bool IsSpecialGroupOne(string EventType)
        {
            if (EventType == "inforce" | EventType == "change")
                return true;
            else
                return false;
        }

        static internal int SetFipClass(ClientPerson client, int headercode, IllustrationRequest policy)
        {
            int AdultAge;
            bool IsNewYork;

            //if (logger.IsDebugEnabled())
            //    logger.DebugFormat(InvariantCulture, "SetFipClass - JobType: {0}, Age: {1}, Class: {2}, NeedsCBS: {3}", _job.JobType.JobName, policy.IssueAge, _Policyclient.RatingClass.Text, _NeedsCostBenefitStatement);

            int IssueAge = policy.IssueAge();
            IsNewYork = (policy.IssueStateCode == "NY");

            if (HeaderCode.IsWorksitePaidUpType(headercode))
                AdultAge = 16;
            else
                AdultAge = 18;

            if (HeaderCode.IsRedType(headercode))
                return 12;
            else if (HeaderCode.IsFixedAnnuityType(headercode))
            {
                return 1;
            }
            else if (IsNewYork && HeaderCode.IsAccumulatedUniversalLifeType(headercode) && IssueAge < AdultAge)
                return 12;
            else if (IsSpecialGroupOne(policy.EventType) && (!HeaderCode.IsFamilyTermType(headercode)))
            {
                if (client.IsSmoker)
                {
                    if (client.Age < AdultAge && !HeaderCode.IsAccumulatedUniversalLifeType(headercode))
                        return 12;
                    else if (client.Age < AdultAge)
                    {
                        if (IsNewYork)
                            return 12;
                        else
                            return 2;
                    }
                    else if (IsPreferred(client.RatingClass))
                        return 3;
                    else
                        return 4;
                }
                else if (client.Age < AdultAge && !HeaderCode.IsAccumulatedUniversalLifeType(headercode))
                    return 12;
                else if (client.Age < AdultAge)
                {
                    if (IsNewYork)
                        return 12;
                    else
                        return 2;
                }
                else if (IsNone(client.RatingClass))
                    return 12;
                else if (IsPreferred(client.RatingClass))
                    return 1;
                else if (IsSuperPreferred(client.RatingClass))
                {
                    if (HeaderCode.IsTermNormalType(headercode) || HeaderCode.IsFamilyTermType(headercode))
                        return 5;
                    else
                        return 14;
                }
                else
                    return 2;
            }
            else if (IsNewYork)
            {
                if (client.IsSmoker)
                {
                    if (IssueAge < AdultAge)
                        return 12;
                    else if (IsPreferred(client.RatingClass))
                        return 3;
                    else
                        return 4;
                }
                else if (IssueAge < AdultAge)
                    return 12;
                else if (IsPreferred(client.RatingClass))
                    return 1;
                else if (IsSuperPreferred(client.RatingClass))
                {
                    if (HeaderCode.IsTermNormalType(headercode) || HeaderCode.IsFamilyTermType(headercode))
                        return 5;
                    else
                        return 14;
                }
                else
                    return 2;
            }
            else if (client.IsSmoker)
            {
                if (IssueAge < AdultAge)
                {
                    if (HeaderCode.IsAccumulatedUniversalLifeType(headercode))
                        return 2;
                    else
                        return 12;
                }
                else if (IsPreferred(client.RatingClass))
                    return 3;
                else
                    return 4;
            }
            else if (IssueAge < AdultAge && !HeaderCode.IsAccumulatedUniversalLifeType(headercode))
                return 12;
            else if (IsPreferred(client.RatingClass))
                return 1;
            else if (IsSuperPreferred(client.RatingClass))
            {
                if (HeaderCode.IsTermNormalType(headercode) || HeaderCode.IsFamilyTermType(headercode))
                    return 5;
                else
                    return 14;
            }
            else
                return 2;

            //if (logger.IsDebugEnabled())
            //    logger.DebugFormat(InvariantCulture, "SetFipClass - FipClass: {0}, NeedsCBS: {1}, plantype.IsFixedAnnuityType: {2}", _FipClass, _NeedsCostBenefitStatement, IsFixedAnnuityType(_plantype));
        }
    }
}
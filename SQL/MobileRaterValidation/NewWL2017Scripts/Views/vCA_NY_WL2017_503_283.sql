USE [MobileRaterService_TEST]
GO

/****** Object:  View [dbo].[vCA_NY_WL2017_503_283]    Script Date: 7/12/2018 2:44:57 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create View [dbo].[vCA_NY_WL2017_503_283]
as (
select *
from (select 283 as HeaderCode) vHeader
cross join (
    select StateGroupId
    from ( values (503, 'CA/NY-WL2017')) as StatesTable(StateGroupId, [Description])) vState
cross join (
    select MinInsuredAge, MaxInsuredAge
    from ( values (0, 15), (16, 17), (18, 37), (38, 55), (56, 64), (65, 65), (66, 69), (70, 74), (75, 79), (80, 80)) as InsuredAgeTable(MinInsuredAge, MaxInsuredAge)) vAge
cross join (
    select IsTobaccoUser
    from ( values (0), (1)) as IsTobaccoUserTable(IsTobaccoUser)) vTobacco
cross join (
    select MinRatingClass, MaxRatingClass
    from ( values (-2, -2, 'Super'), (-1, -1, 'Preferred'), (0, 1, 'Standard to Table 1'), (2, 3, 'Table 2 & 3'), (4, 4, 'Table 4'), 
        (5, 5, 'Table 5'), (6, 6, 'Table 6'), (7, 7, 'Table 7'), (8, 8, 'Table 8'), (9, 10, 'Table 9 & 10'), (11, 12, 'Table 11 & 12'), 
        (13, 14, 'Table 13 & 14'), (15, 16, 'Table 15 & 16')) 
        as RatingClassTable(MinRatingClass, MaxRatingClass, [Description])) vRating
cross join (
    select MinFaceAmount, MaxFaceAmount
    from ( values (25000, 99999), (100000, 2000000000)) as FaceAmountTable(MinFaceAmount, MaxFaceAmount)) vFaceAmount
cross join (
    select Gender
    from ( values ('M'), ('F')) as GenderTable(Gender)) vGender
cross join (
    select IsWorkplace
    from ( values (0)) as IsWorkplaceTable(IsWorkplace)) vWorkplace
cross join (
    select BillingMethod
    from ( values ('P'), ('L'), ('D')) as BillingMethodTable(BillingMethod)) vBillingMethod
cross join (
    select BillingFrequency
    from ( values ('M'), ('Q'), ('S'), ('A')) as BillingFrequencyTable(BillingFrequency)) vBillingFrequency
cross join (
    select IsAIO, MinAIOAmount, MaxAIOAmount
    from ( values (0, null, null, 'No'), (1, 5000, 50000, 'Yes')) as AIOTable(IsAIO, MinAIOAmount, MaxAIOAmount, [Description])) vAIO
cross join (
    select AWPRating, MinPayorAge, MaxPayorAge
    from ( values (0, null, null, 'No'), (1, 16, 55, 'Yes')) as AWPRatingTable(AWPRating, MinPayorAge, MaxPayorAge, [Description])) vAWP
cross join (
    select ADRating
    from ( values (0, 'No'), (1, 'Yes'), (2, '2X'), (3, '3X')) as ADRatingTable(ADRating, [Description])) vAD
cross join (
    select WPRating
    from ( values (0, 'No'), (1, 'Yes'), (2, '2X'), (3, '3X')) as WPRatingTable(WPRating, [Description])) vWP
cross join (
    select WMDRating
    from ( values (null, 'N/A')) as WMDRatingTable(WMDRating, [Description])) vWMD
where (((MinFaceAmount >= 100000 and MaxFaceAmount <= 2000000000 and MinInsuredAge >= 18 and MaxInsuredAge <= 80)
    and ((MinRatingClass = -2 and MaxRatingClass = -2 and IsTobaccoUser = 0)
        or (MinRatingClass = -1 and MaxRatingClass = -1)))
    or (MinRatingClass >= 0 and MaxRatingClass <= 16))
and (BillingMethod != 'D' or BillingFrequency != 'M')
and ((Gender = 'F' and MinRatingClass >= -2 and MaxRatingClass <= 
            case 
                when MinInsuredAge >= 0 and MaxInsuredAge <= 69  then 16
                when MinInsuredAge >= 70 and MaxInsuredAge <= 74 then 12
                when MinInsuredAge >= 75 and MaxInsuredAge <= 79 then 8
                when MinInsuredAge >= 80 and MaxInsuredAge <= 80 then 6
            end) 
    or (Gender = 'M' and MinRatingClass >= -2 and MaxRatingClass <= 
            case 
                when MinInsuredAge >= 0 and MaxInsuredAge <= 64  then 16
                when MinInsuredAge >= 65 and MaxInsuredAge <= 69 then 14
                when MinInsuredAge >= 70 and MaxInsuredAge <= 74 then 10
                when MinInsuredAge >= 75 and MaxInsuredAge <= 79 then 6
                when MinInsuredAge >= 80 and MaxInsuredAge <= 80 then 4
            end))
and (ADRating = 0
    or ((MinInsuredAge >= 0 and MaxInsuredAge <= 65)
        and ((MinRatingClass >= -2 and MaxRatingClass <= 7 and ADRating = 3)
            or (MinRatingClass >= -2 and MaxRatingClass <= 6 and ADRating = 2)
            or (MinRatingClass >= -2 and MaxRatingClass <= 4 and ADRating = 1))))
and (WPRating = 0
    or ((MinInsuredAge >= 16 and MaxInsuredAge <= 55)
        and ((MinRatingClass >= -2 and MaxRatingClass <= 5 and WPRating = 3)
            or (MinRatingClass >= -2 and MaxRatingClass <= 3 and WPRating = 2)
            or (MinRatingClass >= -2 and MaxRatingClass <= 1 and WPRating = 1))))
and ((AWPRating = 0)
    or (AWPRating = 1 and MinInsuredAge >= 0 and MaxInsuredAge <= 15))
and (IsAIO = 0
    or (MinInsuredAge >= 0 and MaxInsuredAge <= 37))
)
GO



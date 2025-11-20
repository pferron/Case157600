Declare @HeaderCode smallint
Declare @StateGroupId smallint
Declare @InsuredAge tinyint
Declare @IsTobaccoUser bit
Declare @FaceAmount int
Declare @BillingMethod char(1)
Declare @BillingFrequency char(1)
Declare @IsWorkplace bit
Declare @Gender char(1)
Declare @ADRating tinyint
Declare @IsAIO bit
Declare @AIOAmount int
Declare @AWPRating tinyint
Declare @PayorAge tinyint
Declare @WPRating tinyint
Declare @WMDRating tinyint
Declare @BaseRating smallint

SET @HeaderCode = 282
SET @StateGroupId = 1014 --Non-MT/NY
SET @InsuredAge = 35
SET @IsTobaccoUser = 0
SET @FaceAmount = 50000
SET @BillingMethod = 'P'  -- PAC
SET @BillingFrequency = 'M'  -- Monthly
SET @IsWorkplace = 0
SET @Gender = 'M'
SET @ADRating = 1 -- Standard
SET @IsAIO = 1
SET @AIOAmount = 35000
SET @AWPRating = 0 -- No
SET @PayorAge = 0
SET @WPRating = 2 -- x2
SET @WMDRating = 0 -- No
SET @BaseRating = 0 -- Standard
;

WITH TempTable
as (
select *
from (select 282 as HeaderCode) vHeader
cross join (
    select StateGroupId
    from ( values (1014, 'Non-MT/NY')) as StatesTable(StateGroupId, [Description])) vState
cross join (
    select MinInsuredAge, MaxInsuredAge
    from ( values (0, 15), (16, 17), (18, 37), (38, 55), (56, 65), (66, 69), (70, 70)) as InsuredAgeTable(MinInsuredAge, MaxInsuredAge)) vAge
cross join (
    select IsTobaccoUser
    from ( values (0), (1)) as IsTobaccoUserTable(IsTobaccoUser)) vTobacco
cross join (
    select MinRatingClass, MaxRatingClass
    from ( values (-2, -2, 'Super'), (-1, -1, 'Preferred'), (0, 1, 'Standard to Table 1'), (2, 3, 'Table 2 & 3'), (4, 4, 'Table 4'), 
        (5, 5, 'Table 5'), (6, 6, 'Table 6'), (7, 7, 'Table 7'), (8, 12, 'Table 8 to 12'), 
        (13, 16, 'Table 13 to 16')) 
        as RatingClassTable(MinRatingClass, MaxRatingClass, [Description])) vRating
cross join (
    select MinFaceAmount, MaxFaceAmount
    from ( values (25000, 99999), (100000, 2000000000)) as FaceAmountTable(MinFaceAmount, MaxFaceAmount)) vFaceAmount
cross join (
    select Gender
    from ( values (null)) as GenderTable(Gender)) vGender
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
where (((MinFaceAmount >= 100000 and MaxFaceAmount <= 2000000000 and MinInsuredAge >= 18 and MaxInsuredAge <= 70)
    and ((MinRatingClass = -2 and MaxRatingClass = -2 and IsTobaccoUser = 0)
        or (MinRatingClass = -1 and MaxRatingClass = -1)))
    or (MinRatingClass >= 0 and MaxRatingClass <= 16))
and (BillingMethod != 'D' or BillingFrequency != 'M')
and (MinRatingClass >= -2 and MaxRatingClass <= 
            case 
                when MinInsuredAge >=  0 and MaxInsuredAge <= 69  then 16
                when MinInsuredAge >= 70 and MaxInsuredAge <= 70 then 12
            end)
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


select *
from TempTable
where @HeaderCode = HeaderCode
and @StateGroupId = StateGroupId -- join with a state groups table to identify code
and @InsuredAge between MinInsuredAge and MaxInsuredAge
and @IsTobaccoUser = ISNULL(IsTobaccoUser, @IsTobaccoUser)
and @FaceAmount between MinFaceAmount and MaxFaceAmount
and @BillingMethod = BillingMethod
and @BillingFrequency = BillingFrequency
and @IsWorkplace = IsWorkplace
and @Gender = ISNULL(Gender, @Gender)
and @ADRating = ISNULL(ADRating, @ADRating)
and @IsAIO = ISNULL(IsAIO, @IsAIO)
and (@IsAIO = 0 or @AIOAmount between ISNULL(MinAIOAmount, @AIOAmount) and ISNULL(MaxAIOAmount, @AIOAmount))
and @AWPRating = ISNULL(AWPRating, @AWPRating)
and (@AWPRating = 0 or @PayorAge between ISNULL(MinPayorAge, @PayorAge) and ISNULL(MaxPayorAge, @PayorAge))
and @WPRating = ISNULL(WPRating, @WPRating)
and @WMDRating = ISNULL(WMDRating, @WMDRating)
and @BaseRating between MinRatingClass and MaxRatingClass



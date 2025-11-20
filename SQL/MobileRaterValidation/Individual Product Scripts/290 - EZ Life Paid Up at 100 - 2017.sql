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

SET @HeaderCode = 290
SET @StateGroupId = 1015 -- Non-MT/OR/NY
SET @InsuredAge = 77
SET @IsTobaccoUser = 0
SET @FaceAmount = 20000
SET @BillingMethod = 'P'  -- PAC
SET @BillingFrequency = 'M'  -- Monthly
SET @IsWorkplace = 0
SET @Gender = 'M'
SET @ADRating = 0 -- Standard
SET @IsAIO = 0
SET @AIOAmount = 0
SET @AWPRating = 0 -- No
SET @PayorAge = 0
SET @WPRating = 0 -- No
SET @WMDRating = 0 -- No
SET @BaseRating = 1 -- Special
;

WITH TempTable
as (
select *
from (select 290 as HeaderCode) vHeader
cross join (
    select StateGroupId
    from ( values (1020, 'Non-MT/OR/MD/NY'), (104, 'OR'), (105, 'MD')) as StatesTable(StateGroupId, [Description])) vState
cross join (
    select MinInsuredAge, MaxInsuredAge
    from ( values (0, 17), (18, 49), (50, 65), (66, 74), (75, 76), (77, 80), (81, 85)) as InsuredAgeTable(MinInsuredAge, MaxInsuredAge)) vAge
cross join (
    select IsTobaccoUser
    from ( values (0), (1)) as IsTobaccoUserTable(IsTobaccoUser)) vTobacco
cross join (
    select MinRatingClass, MaxRatingClass
    from ( values (0, 0, 'Standard'), (1, 1, 'Special')) 
        as RatingClassTable(MinRatingClass, MaxRatingClass, [Description])) vRating
cross join (
    select MinFaceAmount, MaxFaceAmount
    from ( values (5000, 5000), (10000, 10000), (15000, 15000), (20000, 20000)) as FaceAmountTable(MinFaceAmount, MaxFaceAmount)) vFaceAmount
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
    from ( values (null, null, null, 'N/A')) as AIOTable(IsAIO, MinAIOAmount, MaxAIOAmount, [Description])) vAIO
cross join (
    select AWPRating, MinPayorAge, MaxPayorAge
    from ( values (null, null, null, 'N/A')) as AWPRatingTable(AWPRating, MinPayorAge, MaxPayorAge, [Description])) vAWP
cross join (
    select ADRating
    from ( values (0, 'No'), (1, 'Yes'), (3, '3X')) as ADRatingTable(ADRating, [Description])) vAD
cross join (
    select WPRating
    from ( values (null, 'N/A')) as WPRatingTable(WPRating, [Description])) vWP
cross join (
    select WMDRating
    from ( values (null, 'N/A')) as WMDRatingTable(WMDRating, [Description])) vWMD
where 
    ((StateGroupId = 105 and MinInsuredAge >= 18 and MaxInsuredAge <=85) 
    or (StateGroupId = 1020 and MinInsuredAge >= 0 and MaxInsuredAge <=85)
    or (StateGroupId = 104 and MinInsuredAge >= 0 and MaxInsuredAge <=85))
and ((StateGroupId = 105 and MinFaceAmount >= 5000 and MaxFaceAmount <= 5000 and MinInsuredAge >= 50 and MaxInsuredAge <= 80)
    or (StateGroupId = 105 and MinFaceAmount >= 10000 and MaxFaceAmount <= 20000 and MinInsuredAge >= 0 and MaxInsuredAge <= 85 and MinRatingClass >= 0 and MaxRatingClass <= 0)
    or (StateGroupId = 105 and MinFaceAmount >= 10000 and MaxFaceAmount <= 20000 and MinInsuredAge >= 0 and MaxInsuredAge <= 80 and MinRatingClass >= 1 and MaxRatingClass <= 1)
    or (StateGroupId = 1020 and MinFaceAmount >= 5000 and MaxFaceAmount <= 5000 and MinInsuredAge >= 50 and MaxInsuredAge <= 80)
    or (StateGroupId = 1020 and MinFaceAmount >= 10000 and MaxFaceAmount <= 20000 and MinInsuredAge >= 0 and MaxInsuredAge <= 85 and MinRatingClass >= 0 and MaxRatingClass <= 0)
    or (StateGroupId = 1020 and MinFaceAmount >= 10000 and MaxFaceAmount <= 20000 and MinInsuredAge >= 0 and MaxInsuredAge <= 80 and MinRatingClass >= 1 and MaxRatingClass <= 1)
    or (StateGroupId = 104 and MinFaceAmount >= 5000 and MaxFaceAmount <= 5000 and MinInsuredAge >= 50 and MaxInsuredAge <= 76 and MinRatingClass >= 0 and MaxRatingClass <= 0)
    or (StateGroupId = 104 and MinFaceAmount >= 5000 and MaxFaceAmount <= 5000 and MinInsuredAge >= 50 and MaxInsuredAge <= 74 and MinRatingClass >= 1 and MaxRatingClass <= 1)
    or (StateGroupId = 104 and MinFaceAmount >= 10000 and MaxFaceAmount <= 20000 and MinInsuredAge >= 0 and MaxInsuredAge <= 76 and MinRatingClass >= 0 and MaxRatingClass <= 0)
    or (StateGroupId = 104 and MinFaceAmount >= 10000 and MaxFaceAmount <= 20000 and MinInsuredAge >= 0 and MaxInsuredAge <= 74 and MinRatingClass >= 1 and MaxRatingClass <= 1)
    )

and (BillingMethod != 'D' or BillingFrequency != 'M')
and (ADRating = 0 
    or ((MinInsuredAge >= 0 and MaxInsuredAge <= 65)
        and ((ADRating = 1 and MinRatingClass >= 0 and MaxRatingClass <= 0) 
        or (ADRating = 3 and MinRatingClass >= 1 and MaxRatingClass <= 1))))
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



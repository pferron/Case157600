Declare @HeaderCode smallint
Declare @StateGroupId smallint
Declare @InsuredAge tinyint
Declare @IsTobaccoUser bit
Declare @FaceAmount int
Declare @BillingMethod char(1)
Declare @BillingMode char(1)
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

SET @HeaderCode = 123
SET @StateGroupId = 1014 -- Non-MT, NY
SET @InsuredAge = 25
SET @IsTobaccoUser = 0
SET @FaceAmount = 50000
SET @BillingMethod = 'P'  -- PAC
SET @BillingMode = 'M'  -- Monthly
SET @IsWorkplace = 0
SET @Gender = 'M'
SET @ADRating = 1 -- Standard
SET @IsAIO = 0
SET @AIOAmount = 0
SET @AWPRating = 0 -- No
SET @PayorAge = 0
SET @WPRating = 2 -- x2
SET @WMDRating = 0 -- No
SET @BaseRating = 0 -- Standard
;

WITH TempTable
as (
select *
from (select 123 as HeaderCode) vHeader
cross join (
    select StateGroupId
    from ( values (1014, 'Non-MT/NY')) as StatesTable(StateGroupId, [Description])) vState
cross join (
    select MinInsuredAge, MaxInsuredAge
    from ( values (0, 15), (16, 37), (38, 55), (56, 64), (65, 65), (66, 69), (70, 74), (75, 79), (80, 80), (81, 82), (83, 85)) as InsuredAgeTable(MinInsuredAge, MaxInsuredAge)) vAge
cross join (
    select IsTobaccoUser
    from ( values (0), (1)) as IsTobaccoUserTable(IsTobaccoUser)) vTobacco
cross join (
    select MinRatingClass, MaxRatingClass
    from ( values (-2, -2, 'Super'), (-1, -1, 'Preferred'), (0, 1, 'Standard to Table 1'), (2, 3, 'Table 2 & Table 3'), (4, 4, 'Table 4'),
        (5, 5, 'Table 5'), (6, 6, 'Table 6'), (7, 7, 'Table 7'), (8, 8, 'Table 8'), (9, 12, 'Table 9-12'), 
        (13, 16, 'Table 13-16')) 
        as RatingClassTable(MinRatingClass, MaxRatingClass, [Description])) vRating
cross join (
    select MinFaceAmount, MaxFaceAmount
    from ( values (25000, 99999), (100000, 2000000000)) as FaceAmountTable(MinFaceAmount, MaxFaceAmount)) vFaceAmount
cross join (
    select Gender
    from ( values (null)) as GenderTable(Gender)) vGender -- IUL does not care about gender
cross join (
    select IsWorkplace
    from ( values (0)) as IsWorkplaceTable(IsWorkplace)) vWorkplace
cross join (
    select BillingMethod
    from ( values ('P'), ('L'), ('D')) as BillingMethodTable(BillingMethod)) vBillingMethod
cross join (
    select BillingMode
    from ( values ('M'), ('Q'), ('S'), ('A')) as BillingModeTable(BillingMode)) vBillingMode
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
    from ( values (null, 'N/A')) as WPRatingTable(WPRating, [Description])) vWP
cross join (
    select WMDRating
    from ( values (0, 'No'), (1, 'Yes'), (2, '2X'), (3, '3X')) as WMDRatingTable(WMDRating, [Description])) vWMD
where (((MinFaceAmount >= 100000 and MaxFaceAmount <= 2000000000) 
    and ((MinRatingClass = -2 and MaxRatingClass = -2 and IsTobaccoUser = 0)
        or (MinRatingClass = -1 and MaxRatingClass = -1)))
    or (MinRatingClass >= 0 and MaxRatingClass <= 16))
and (BillingMethod != 'D' or BillingMode != 'M')
and (MinRatingClass >= -2 and MaxRatingClass <= 
            case 
                when MinInsuredAge >= 0 and MaxInsuredAge <= 69  then 16
                when MinInsuredAge >= 70 and MaxInsuredAge <= 74 then 12
                when MinInsuredAge >= 75 and MaxInsuredAge <= 79 then 8
                when MinInsuredAge >= 80 and MaxInsuredAge <= 82 then 6
                when MinInsuredAge >= 83 and MaxInsuredAge <= 85 then 4
            end
	)
and (ADRating = 0
    or ((MinInsuredAge >= 0 and MaxInsuredAge <= 65)
        and ((MinRatingClass >= -2 and MaxRatingClass <= 7 and ADRating = 3)
            or (MinRatingClass >= -2 and MaxRatingClass <= 6 and ADRating = 2)
            or (MinRatingClass >= -2 and MaxRatingClass <= 4 and ADRating = 1))))
and (WMDRating = 0
    or ((MinInsuredAge >= 16 and MaxInsuredAge <= 55)
        and ((MinRatingClass >= -2 and MaxRatingClass <= 5 and WMDRating = 3)
            or (MinRatingClass >= -2 and MaxRatingClass <= 3 and WMDRating = 2)
            or (MinRatingClass >= -2 and MaxRatingClass <= 1 and WMDRating = 1))))
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
and @BillingMode = BillingMode
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



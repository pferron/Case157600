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

SET @HeaderCode = 281
SET @StateGroupId = 1009 -- Non-CA/MT/NY
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
Select *
From vCA_NY_WL2017_503_281
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



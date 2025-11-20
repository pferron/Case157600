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

SET @HeaderCode = 293
SET @StateGroupId = 504 -- WA_EXTENSIONS
SET @InsuredAge = 65
SET @IsTobaccoUser = 0
SET @FaceAmount = 20000
SET @BillingMethod = 'P'  -- PAC
SET @BillingFrequency = 'M'  -- Monthly
SET @IsWorkplace = 0
SET @Gender = 'M'
SET @ADRating = 3 -- Special
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
from vWA_WL2017_293_EXTENSIONS
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



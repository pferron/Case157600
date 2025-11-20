select * --2816
from (select 294 as HeaderCode) vHeader
cross join (
    select StateGroupId
    from ( values (1021, 'Non-OR/MD'), (104, 'OR'), (105, 'MD')) as StatesTable(StateGroupId, [Description])) vState
cross join (
    select MinInsuredAge, MaxInsuredAge
    from ( values (16, 17), (18, 49), (50, 65), (66, 70), (71, 76), (77, 80), (81, 85)) as InsuredAgeTable(MinInsuredAge, MaxInsuredAge)) vAge
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
    from ( values (1)) as IsWorkplaceTable(IsWorkplace)) vWorkplace
cross join (
    select BillingMethod
    from ( values ('P'), ('L')) as BillingMethodTable(BillingMethod)) vBillingMethod
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
where (MinInsuredAge > 17 or StateGroupId <> 105) 
and	(
       (StateGroupId in (1021,105) and MinFaceAmount >= 5000 and MaxFaceAmount <= 5000 and MinInsuredAge >= 50 and MaxInsuredAge <= 85 and MinRatingClass >= 0 and MaxRatingClass <= 0)
    or (StateGroupId in (1021,105) and MinFaceAmount >= 5000 and MaxFaceAmount <= 5000 and MinInsuredAge >= 50 and MaxInsuredAge <= 80 and MinRatingClass >= 1 and MaxRatingClass <= 1)
    or (StateGroupId in (1021,105) and MinFaceAmount >= 10000 and MaxFaceAmount <= 20000 and MinInsuredAge >= 16 and MaxInsuredAge <= 85 and MinRatingClass >= 0 and MaxRatingClass <= 0)
    or (StateGroupId in (1021,105) and MinFaceAmount >= 10000 and MaxFaceAmount <= 20000 and MinInsuredAge >= 16 and MaxInsuredAge <= 80 and MinRatingClass >= 1 and MaxRatingClass <= 1)

    or (StateGroupId = 104 and MinFaceAmount >= 5000 and MaxFaceAmount <= 5000 and MinInsuredAge >= 50 and MaxInsuredAge <= 76 and MinRatingClass >= 0 and MaxRatingClass <= 0)
    or (StateGroupId = 104 and MinFaceAmount >= 5000 and MaxFaceAmount <= 5000 and MinInsuredAge >= 50 and MaxInsuredAge <= 70 and MinRatingClass >= 1 and MaxRatingClass <= 1)
    or (StateGroupId = 104 and MinFaceAmount >= 10000 and MaxFaceAmount <= 20000 and MinInsuredAge >= 16 and MaxInsuredAge <= 76 and MinRatingClass >= 0 and MaxRatingClass <= 0)
    or (StateGroupId = 104 and MinFaceAmount >= 10000 and MaxFaceAmount <= 20000 and MinInsuredAge >= 16 and MaxInsuredAge <= 70 and MinRatingClass >= 1 and MaxRatingClass <= 1)
    )
and (ADRating = 0 
    or ((MinInsuredAge >= 16 and MaxInsuredAge <= 65)
        and ((ADRating = 1 and MinRatingClass >= 0 and MaxRatingClass <= 0) 
        or (ADRating = 3 and MinRatingClass >= 1 and MaxRatingClass <= 1))))
Order by StateGroupId

bcp "Select distinct %4 from %2.dbo.%3 where %4 > ''"  queryout %5\%3-%4.csv -c -S %1 -T

using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using WOW.WoodmenReconService.Models;

namespace WOW.WoodmenReconService.Code
{
    public class Metrics
    {
        // MemoryCache is thread safe
        ObjectCache _cache = MemoryCache.Default;
        TimeSpan _cachedObjectExpiration = new TimeSpan(0, 5, 0);

        public Metrics()
        {
            _cachedObjectExpiration = new TimeSpan(0, 5, 0);
        }

        public Metrics(TimeSpan cacheExpiration)
        {
            _cachedObjectExpiration = cacheExpiration.Duration();
        }

        public int DistinctHosts(int days)
        {
            try
            {
                int _result = 0;

                // Make sure input parameter is a negative number
                var _daysBack = -Math.Abs(days);
                var _cacheKey = _daysBack.ToString();
                var periodDate = DateTime.Today.AddDays(_daysBack);

                // Check object cache for existing dataset
                var cacheData = _cache[_cacheKey] as List<ReconReport>;

                if (cacheData == null)
                {
                    CacheItemPolicy policy = new CacheItemPolicy();
                    policy.AbsoluteExpiration = DateTime.Now.Add(_cachedObjectExpiration);

                    using (var ef = new WoodmenReconServiceEntities())
                    {
                        var reconReports = ef.ReconReports.Where(r => r.DateReceived >= periodDate).ToList();
                        _result = reconReports.DistinctBy(r => r.Hostname).Count();
                        _cache.Set(_cacheKey, reconReports, policy);
                    }
                }
                else
                {
                    _result = cacheData.DistinctBy(r => r.Hostname).Count();
                }

                return _result;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public int ReportSubmitted(int days)
        {
            try
            {
                int _result = 0;

                // Make sure input parameter is a negative number
                var _daysBack = -Math.Abs(days);
                var _cacheKey = _daysBack.ToString();
                var periodDate = DateTime.Today.AddDays(_daysBack);

                // Check object cache for existing dataset
                var cacheData = _cache[_cacheKey] as List<ReconReport>;

                if (cacheData == null)
                {
                    CacheItemPolicy policy = new CacheItemPolicy();
                    policy.AbsoluteExpiration = DateTime.Now.Add(_cachedObjectExpiration);

                    using (var ef = new WoodmenReconServiceEntities())
                    {
                        var reconReports = ef.ReconReports.Where(r => r.DateReceived >= periodDate).ToList();
                        _result = reconReports.Count();
                        _cache.Set(_cacheKey, reconReports, policy);
                    }
                }
                else
                {
                    _result = cacheData.Count();
                }

                return _result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
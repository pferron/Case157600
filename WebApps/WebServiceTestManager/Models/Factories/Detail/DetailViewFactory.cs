using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceTestManager.Models
{
    public enum DetailType
    {
        File,
        ExecutedFile
    }
    public static class DetailViewFactory
    {
        /// <summary>
        /// Get a detail view based on guid
        /// </summary>
        /// <param name="detailType"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IDetailView GetDetailView(DetailType detailType, Guid id)
        {
            switch (detailType)
            {
                case DetailType.File:
                    return new FileDetail(id);
                default:
                    throw new ArgumentOutOfRangeException("Detail type is out of range", "Please use the specified detail types.");
            }
        }

        /// <summary>
        /// Get the int based detail view
        /// </summary>
        /// <param name="detailType"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static IDetailView GetDetailView(DetailType detailType, int id)
        {
            switch (detailType)
            {
                case DetailType.ExecutedFile:
                    return new ExecutedFileDetail(id);
                default:
                    throw new ArgumentOutOfRangeException("Detail type is out of range", "Please use the specified detail types.");
            }
        }
    }
}
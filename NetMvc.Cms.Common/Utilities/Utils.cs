using System;
using System.Text;

namespace NetMvc.Cms.Common.Utilities
{
    /// <summary>
    /// Defines the <see cref="Utilities" />
    /// </summary>
    public static class Utilities
    {
        /// <summary>
        /// Calculate Total Pages
        /// </summary>
        /// <param name="numberOfRecords"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public static int CalculateTotalPages(long numberOfRecords, Int32 pageSize)
        {
            long result;
            int totalPages;

            Math.DivRem(numberOfRecords, pageSize, out result);

            if (result > 0)
                totalPages = (int)((numberOfRecords / pageSize)) + 1;
            else
                totalPages = (int)(numberOfRecords / pageSize);

            return totalPages;
        }

        /// <summary>
        /// The CalculateForPagination
        /// </summary>
        /// <param name="pager">The pager<see cref="Pager"/></param>
        /// <returns>The <see cref="Pager"/></returns>
        public static Pager CalculateForPagination(Pager pager)
        {
            pager.TotalPages = CalculateTotalPages(pager.TotalRows, pager.PageSize);
            pager.PrevPageNumber = pager.CurrentPageNumber - 1;
            pager.NextPageNumber = pager.CurrentPageNumber + 1;
            pager.LastPageNumber = pager.TotalPages;
            pager.StartPageNumber = Math.Max(1, pager.CurrentPageNumber - pager.MaxPageDisplayNumber / 2);
            pager.EndPageNumber = Math.Min(pager.TotalPages, pager.CurrentPageNumber + pager.MaxPageDisplayNumber / 2);

            return pager;
        }

        /// <summary>
        /// The CalculateForPagerOfTransaction
        /// </summary>
        /// <param name="transaction">The transaction<see cref="TransactionalInformation"/></param>
        /// <param name="totalRows">The totalRows<see cref="long"/></param>
        /// <param name="pageSize">The pageSize<see cref="int"/></param>
        /// <param name="currentPageNumber">The currentPageNumber<see cref="int"/></param>
        /// <returns>The <see cref="TransactionalInformation"/></returns>
        public static TransactionalInformation CalculateForPagerOfTransaction(TransactionalInformation transaction,
            int totalRows, int pageSize, int currentPageNumber)
        {
            transaction.Pager.TotalRows = totalRows;
            transaction.Pager.PageSize = pageSize;
            transaction.Pager.CurrentPageNumber = currentPageNumber;
            // Calculate for pagination:
            transaction.Pager = CalculateForPagination(transaction.Pager);

            return transaction;
        }

        public static TransactionalInformation CalculateForPagerOfTransaction(TransactionalInformation transaction,
            int totalRows, int pageSize)
        {
            transaction.Pager.TotalRows = totalRows;
            transaction.Pager.PageSize = pageSize;
           
            // Calculate for pagination:
            transaction.Pager = CalculateForPagination(transaction.Pager);

            return transaction;
        }

        /// <summary>
        /// Generate Random Number
        /// </summary>
        /// <param name="max">The max<see cref="int"/></param>
        /// <returns></returns>
        public static int GenerateRandomNumber(int max)
        {
            Random rnd = new Random();
            int randomNumber = rnd.Next(max);
            return randomNumber;
        }

        /// <summary>
        /// Fold first letter of every word to uppercase
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string UppercaseFirstLetter(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }

            StringBuilder output = new StringBuilder();
            string[] words = s.Split(' ');
            foreach (string word in words)
            {
                char[] a = word.ToCharArray();
                a[0] = char.ToUpper(a[0]);
                string b = new string(a);
                output.Append(b + " ");
            }

            return output.ToString().Trim();
        }
    }
}
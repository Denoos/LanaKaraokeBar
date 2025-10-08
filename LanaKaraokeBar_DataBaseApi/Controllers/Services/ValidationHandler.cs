using LanaKaraokeBar_DataBaseApi.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace LanaKaraokeBar_DataBaseApi.Controllers.Services
{
    public class ValidationHandler
    {
        #region Methods

        #region Strings

        public bool CheckStringIsValid(string value)
        {
            var result = false;

            if (
                !string.IsNullOrEmpty(value) &&
                !string.IsNullOrWhiteSpace(value)
                )
                result = true;

            return result;
        }

        public bool CheckAuthFormInputIsValid(string value)
        {
            var result = true;

            if (
                CheckStringIsValid(value) &&
                value.Length >= 4 &&
                !value.Contains('\"') &&
                !value.Contains('\'')
                )
                result = false;

            return result;
        }

        #endregion

        #region Authors

        public bool CheckAuthorIsValid(Author value)
        {
            var result = false;

            if (value != null && CheckStringIsValid(value.NickName))
                result = true;

            return result;
        }

        #endregion

        #region Genres

        public bool CheckGenreIsValid(Genre value)
        {
            var result = false;

            if (value != null && CheckStringIsValid(value.Title))
                result = true;

            return result;
        }

        #endregion

        #region Statuses

        public bool CheckStatusIsValid(Status value)
        {
            var result = false;

            if (value != null && CheckStringIsValid(value.Title))
                result = true;

            return result;
        }

        #endregion

        #region Products

        public bool CheckProductIsValid(Product value)
        {
            var result = false;

            if (value != null && CheckStringIsValid(value.Title) && value.Cost > 0)
                result = true;

            return result;
        }

        #endregion

        #region PaymentType

        public bool CheckPaymentTypeIsValid(Paymenttype value)
        {
            var result = false;

            if (value != null && CheckStringIsValid(value.Title))
                result = true;

            return result;
        }

        #endregion

        #region ReportType

        public bool CheckReportTypeIsValid(Reporttype value)
        {
            var result = false;

            if (value != null && CheckStringIsValid(value.Title))
                result = true;

            return result;
        }

        #endregion

        #endregion
    }
}

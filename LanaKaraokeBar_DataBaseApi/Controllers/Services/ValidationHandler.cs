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

        #region Rate

        public bool CheckRateIsValid(Rate value)
        {
            var result = false;

            if (value != null && CheckStringIsValid(value.Title) && value.CostCoefficient > 0)
                result = true;

            return result;
        }

        #endregion

        #region User

        public bool CheckUserIsValid(User value)
        {
            var result = false;
            bool resultPatronymicIsValid;

            if (!string.IsNullOrEmpty(value.Patronymic))
                resultPatronymicIsValid = CheckStringIsValid(value.Patronymic);
            else
                resultPatronymicIsValid = true;

            if (
                value != null &&
                resultPatronymicIsValid &&
                CheckStringIsValid(value.FirstName) &&
                CheckStringIsValid(value.LastName) &&
                CheckStringIsValid(value.Password) &&
                value.IdRole > 0 &&
                value.BonusesCount >= 0
                )
                result = true;

            return result;
        }

        #endregion

        #region Song

        public bool CheckSongIsValid(Song value)
        {
            var result = false;

            if (
                value != null &&
                CheckStringIsValid(value.Title) &&
                value.IdGenre > 0 &&
                value.IdAuthor > 0 
                )
                result = true;

            return result;
        }

        #endregion

        #region Sell

        public bool CheckSellIsValid(Sell value)
        {
            var result = false;

            if (
                value != null &&
                value.IdBooking > 0 &&
                value.IdPaymenttype > 0 &&
                value.Amount > 0
                )
                result = true;

            return result;
        }

        #endregion

        #region Room

        public bool CheckRoomIsValid(Room value)
        {
            var result = false;

            if (
                value != null &&
                value.IdStatus > 0 &&
                value.MaxPeopleCount > 0 &&
                value.IdRate > 0
                )
                result = true;

            return result;
        }

        #endregion

        #region Report

        public bool CheckReportIsValid(Report value)
        {
            var result = false;

            if (
                value != null &&
                value.IdUser > 0 &&
                value.IdReportType > 0 &&
                CheckStringIsValid(value.Path)
                )
                result = true;

            return result;
        }

        #endregion

        #region ProductList

        public bool CheckProductListIsValid(Productslist value)
        {
            var result = false;

            if (
                value != null &&
                value.IdOrder > 0 &&
                value.IdProduct > 0 &&
                value.ProductCount > 0 
                )
                result = true;

            return result;
        }

        #endregion

        #region Order

        public bool CheckOrderIsValid(Order value)
        {
            var result = false;

            if (
                value != null &&
                value.IdBooking > 0 &&
                value.Cost > 0 
                )
                result = true;

            return result;
        }

        #endregion

        #region Booking

        public bool CheckBookingIsValid(Booking value)
        {
            var result = false;

            if (
                value != null &&
                value.IdRate > 0 &&
                value.IdRoom > 0 &&
                value.IdUser > 0 &&
                value.HoursCount >= 1 
                )
                result = true;

            return result;
        }

        #endregion

        #endregion
    }
}

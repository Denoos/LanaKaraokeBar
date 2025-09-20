namespace LanaKaraokeBar_DataBaseApi.Controllers.Services
{
    public class ValidationHandler
    {
        #region Methods

        #region Strings

        public bool CheckString(string value)
        {
            var result = true;

            if (
                string.IsNullOrEmpty(value) ||
                string.IsNullOrWhiteSpace(value)
                )
                result = false;

            return result;
        }

        public bool CheckAuthFormInput(string value)
        {
            var result = true;

            if (
                value.Length < 4 ||
                value.Contains('"') ||
                value.Contains('\'') ||
                value.Contains(' ')
                )
                result = false;

            return result;
        }

        #endregion

        #endregion
    }
}

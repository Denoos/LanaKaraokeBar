using LanaKaraokeBar_DataBaseApi.Controllers.Services;

namespace LanaKaraokeBar_DataBaseApi.Controllers.Routers
{
    public class AuthRouter
    {
        #region Fields

        private ValidationHandler _validator;
        private DbRequstsHandler _requester;

        #endregion

        #region Constructor

        public AuthRouter()
        {
            _validator = new();
            _requester = DbRequstsHandler.Instance;
        }

        #endregion

        #region Methods

        public string ComposeAuthRoute(string login, string password)
        {
            if (!
                _validator.CheckString(login) &&
                _validator.CheckString(password) &&
                _validator.CheckAuthFormInput(login) &&
                _validator.CheckAuthFormInput(password)
                )
                new Exception("Data has an incorrect format").ToString();


            // В разработке :-) //
            return "";
        }

        #endregion
    }
}

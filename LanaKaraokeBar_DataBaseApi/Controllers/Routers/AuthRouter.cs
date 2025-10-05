using LanaKaraokeBar_DataBaseApi.Controllers.Services;

namespace LanaKaraokeBar_DataBaseApi.Controllers.Routers
{
    public class AuthRouter
    {
        #region Fields

        private ValidationHandler _validator;
        private DbRequstsHandler _requester;
        private EncryptionHandler _encrypter;

        #endregion

        #region Constructor

        public AuthRouter()
        {
            _validator = new();
            _encrypter = new();
            _requester = DbRequstsHandler.Instance;
        }

        #endregion

        #region Methods

        public string ComposeAuthRoute(string login, string password)
        {
            if (!
                _validator.CheckStringIsValid(login) &&
                _validator.CheckStringIsValid(password) &&
                _validator.CheckAuthFormInputIsValid(login) &&
                _validator.CheckAuthFormInputIsValid(password)
                )
                 return new Exception("Data has an incorrect format").ToString();

            password = _encrypter.Encrypt(password);

            return _requester.Authorize(login, password);
        }

        #endregion
    }
}

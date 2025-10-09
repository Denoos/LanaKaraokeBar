using LanaKaraokeBar_DataBaseApi.Controllers.Services;
using LanaKaraokeBar_DataBaseApi.Models;

namespace LanaKaraokeBar_DataBaseApi.Controllers.Routers
{
    public class UserRouter
    {

        #region Fields

        private DbRequstsHandler _requester;
        private ValidationHandler _validator;
        private EncryptionHandler _encryption;
        private bool _invalidValueFlag;

        #endregion

        #region Constructor

        public UserRouter()
        {
            _validator = new();
            _encryption = new();
            _requester = DbRequstsHandler.Instance;
            _invalidValueFlag = false;
        }

        #endregion

        #region Methods

        public List<User> ComposeGetRoute()
        {
            return _requester.GetAllUsers();
        }

        public bool ComposePostRoute(User value)
        {
            if (_validator.CheckUserIsValid(value))
            { 
                value.Password = _encryption.Encrypt(value.Password);

                return _requester.AddUser(value);
            }

            return _invalidValueFlag;
        }

        public bool ComposePutRoute(User value)
        {
            if (_validator.CheckUserIsValid(value))
            {
                value.Password = _encryption.Encrypt(value.Password);

                return _requester.EditUser(value);
            }

            return _invalidValueFlag;
        }

        public bool ComposeDeleteRoute(User value)
        {
            if (_validator.CheckUserIsValid(value))
                return _requester.DeleteUser(value);

            return _invalidValueFlag;
        }

        public bool ComposeBlockRoute(User value)
        {
            if (_validator.CheckUserIsValid(value))
                return _requester.BlockUser(value);

            return _invalidValueFlag;
        }

        public bool ComposeUnBlockRoute(User value)
        {
            if (_validator.CheckUserIsValid(value))
                return _requester.UnBlockUser(value);

            return _invalidValueFlag;
        }

        #endregion
    }
}

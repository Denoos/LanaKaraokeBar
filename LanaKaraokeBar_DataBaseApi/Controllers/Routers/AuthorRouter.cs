using LanaKaraokeBar_DataBaseApi.Controllers.Services;
using LanaKaraokeBar_DataBaseApi.Models;

namespace LanaKaraokeBar_DataBaseApi.Controllers.Routers
{
    public class AuthorRouter
    {
        #region Fields

        private DbRequstsHandler _requester;
        private ValidationHandler _validator;
        private bool _invalidValueFlag;

        #endregion

        #region Constructor

        public AuthorRouter()
        {
            _validator = new();
            _requester = DbRequstsHandler.Instance;
            _invalidValueFlag = false;
        }

        #endregion

        #region Methods

        public List<Author> ComposeGetAuthorRoute()
        {
            return _requester.GetAllAuthors();
        }

        public bool ComposePostAuthorRoute(Author value)
        {
            if (_validator.CheckAuthorIsValid(value))
                return _requester.AddAuthor(value);

            return _invalidValueFlag;
        }

        public bool ComposePutAuthorRoute(Author value)
        {
            if (_validator.CheckAuthorIsValid(value))
                return _requester.EditAuthor(value);

            return _invalidValueFlag;
        }

        public bool ComposeDeleteAuthorRoute(Author value)
        {
            if (_validator.CheckAuthorIsValid(value))
                return _requester.DeleteAuthor(value);

            return _invalidValueFlag;
        }

        #endregion
    }
}

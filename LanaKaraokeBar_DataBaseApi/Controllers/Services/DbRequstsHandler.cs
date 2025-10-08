using LanaKaraokeBar_DataBaseApi.Models;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LanaKaraokeBar_DataBaseApi.Controllers.Services
{
    public class DbRequstsHandler
    {
        #region Fields

        private static DbRequstsHandler _inst;
        private LanaKaraokeBarContext _context;

        #endregion

        #region Properties

        public static DbRequstsHandler Instance { get { return _inst ??= new(); } }

        #endregion

        #region Constructors

        public DbRequstsHandler()
        {
            RefreshContext();
        }

        #endregion

        #region Methods

        #region System

        private void Save()
        {
            _context.SaveChangesAsync();
            Thread.Sleep(800);
        }

        private void RefreshContext()
        {
            _context = new();
            Thread.Sleep(800);
        }

        #endregion

        #region Authorize

        public string Authorize(string login, string password)
        {
            var token = "";
            var preparedLogin = login.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            try
            {
                RefreshContext();

                if (preparedLogin.Length != 3)
                    return token;

                var user = _context.Users.FirstOrDefault(
                    s => s.Password == password &&
                         s.FirstName == preparedLogin[0] &&
                         s.LastName == preparedLogin[1] &&
                         s.Patronymic == preparedLogin[2]);

                if (user == null)
                    return token;

                var claims = new List<Claim>
                {
                    new (ClaimValueTypes.Integer32, user.Id.ToString()),
                    new (ClaimTypes.Role, _context.Roles.First(s => s.Id == user.IdRole).Title)
                };

                var jwt = new JwtSecurityToken(
                       issuer: AuthOptions.ISSUER,
                       audience: AuthOptions.AUDIENCE,
                       claims: claims,
                       expires: DateTime.UtcNow.Add(TimeSpan.FromHours(48)),
                       signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

                token = new JwtSecurityTokenHandler().WriteToken(jwt);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.Beep(100, 300);
            }
            return token;
        }

        #endregion

        #region Authors

        public List<Author> GetAllAuthors()
        {
            RefreshContext();
            List<Author>  result = [.. _context.Authors];

            return result;
        }

        public bool AddAuthor(Author value)
        {
            var result = false;

            RefreshContext();

            if (_context.Authors.FirstOrDefault(v=> v.NickName == value.NickName) != null)
                return result;

            _context.Authors.Add(value);
            Save();

            RefreshContext();
            if(_context.Authors.FirstOrDefault(v=> v.NickName == value.NickName) != null)
                result = true;

            return result;
        }

        public bool EditAuthor(Author value)
        {
            var result = false;

            RefreshContext();

            if (_context.Authors.FirstOrDefault(v => v.NickName == value.NickName) != null)
                return result;

            _context.Authors.Update(_context.Authors.FirstOrDefault(v => v.NickName == value.NickName));
            Save();

            RefreshContext();
            if (_context.Authors.FirstOrDefault(v => v.NickName == value.NickName) != null)
                result = true;

            return result;
        }
        
        public bool DeleteAuthor(Author value)
        {
            var result = false;

            RefreshContext();

            if (_context.Authors.FirstOrDefault(v => v.NickName == value.NickName) == null)
                return result;

            _context.Authors.Remove(_context.Authors.FirstOrDefault(v => v.NickName == value.NickName));
            Save();

            RefreshContext();
            if (_context.Authors.FirstOrDefault(v => v.NickName == value.NickName) == null)
                result = true;

            return result;
        }

        #endregion

        #region Genres

        public List<Genre> GetAllGenres()
        {
            RefreshContext();
            List<Genre> result = [.. _context.Genres];

            return result;
        }

        public bool AddGenre(Genre value)
        {
            var result = false;

            RefreshContext();

            if (_context.Genres.FirstOrDefault(v => v.Title == value.Title) != null)
                return result;

            _context.Genres.Add(value);
            Save();

            RefreshContext();
            if (_context.Genres.FirstOrDefault(v => v.Title == value.Title) != null)
                result = true;

            return result;
        }

        public bool EditGenre(Genre value)
        {
            var result = false;

            RefreshContext();

            if (_context.Genres.FirstOrDefault(v => v.Title == value.Title) != null)
                return result;

            _context.Genres.Update(_context.Genres.FirstOrDefault(v => v.Title == value.Title));
            Save();

            RefreshContext();
            if (_context.Genres.FirstOrDefault(v => v.Title == value.Title) != null)
                result = true;

            return result;
        }

        public bool DeleteGenre(Genre value)
        {
            var result = false;

            RefreshContext();

            if (_context.Genres.FirstOrDefault(v => v.Title == value.Title) == null)
                return result;

            _context.Genres.Remove(_context.Genres.FirstOrDefault(v => v.Title == value.Title));
            Save();

            RefreshContext();
            if (_context.Genres.FirstOrDefault(v => v.Title == value.Title) == null)
                result = true;

            return result;
        }

        #endregion

        #region Statuses

        public List<Status> GetAllStatuses()
        {
            RefreshContext();
            List<Status> result = [.. _context.Statuses];

            return result;
        }

        public bool AddStatus(Status value)
        {
            var result = false;

            RefreshContext();

            if (_context.Statuses.FirstOrDefault(v => v.Title == value.Title) != null)
                return result;

            _context.Statuses.Add(value);
            Save();

            RefreshContext();
            if (_context.Statuses.FirstOrDefault(v => v.Title == value.Title) != null)
                result = true;

            return result;
        }

        public bool EditStatus(Status value)
        {
            var result = false;

            RefreshContext();

            if (_context.Statuses.FirstOrDefault(v => v.Title == value.Title) != null)
                return result;

            _context.Statuses.Update(_context.Statuses.FirstOrDefault(v => v.Title == value.Title));
            Save();

            RefreshContext();
            if (_context.Statuses.FirstOrDefault(v => v.Title == value.Title) != null)
                result = true;

            return result;
        }

        public bool DeleteStatus(Status value)
        {
            var result = false;

            RefreshContext();

            if (_context.Statuses.FirstOrDefault(v => v.Title == value.Title) == null)
                return result;

            _context.Statuses.Remove(_context.Statuses.FirstOrDefault(v => v.Title == value.Title));
            Save();

            RefreshContext();
            if (_context.Statuses.FirstOrDefault(v => v.Title == value.Title) == null)
                result = true;

            return result;
        }

        #endregion

        #region Products

        public List<Product> GetAllProducts()
        {
            RefreshContext();
            List<Product> result = [.. _context.Products];

            return result;
        }

        public bool AddProduct(Product value)
        {
            var result = false;

            RefreshContext();

            if (_context.Products.FirstOrDefault(v => v.Title == value.Title) != null)
                return result;

            _context.Products.Add(value);
            Save();

            RefreshContext();
            if (_context.Products.FirstOrDefault(v => v.Title == value.Title) != null)
                result = true;

            return result;
        }

        public bool EditProduct(Product value)
        {
            var result = false;

            RefreshContext();

            if (_context.Products.FirstOrDefault(v => v.Title == value.Title) != null)
                return result;

            _context.Products.Update(_context.Products.FirstOrDefault(v => v.Title == value.Title));
            Save();

            RefreshContext();
            if (_context.Products.FirstOrDefault(v => v.Title == value.Title) != null)
                result = true;

            return result;
        }

        public bool DeleteProduct(Product value)
        {
            var result = false;

            RefreshContext();

            if (_context.Products.FirstOrDefault(v => v.Title == value.Title) == null)
                return result;

            _context.Products.Remove(_context.Products.FirstOrDefault(v => v.Title == value.Title));
            Save();

            RefreshContext();
            if (_context.Products.FirstOrDefault(v => v.Title == value.Title) == null)
                result = true;

            return result;
        }

        #endregion

        #region PaymentType

        public List<Paymenttype> GetAllPaymentTypes()
        {
            RefreshContext();
            List<Paymenttype> result = [.. _context.Paymenttypes];

            return result;
        }

        public bool AddPaymentType(Paymenttype value)
        {
            var result = false;

            RefreshContext();

            if (_context.Paymenttypes.FirstOrDefault(v => v.Title == value.Title) != null)
                return result;

            _context.Paymenttypes.Add(value);
            Save();

            RefreshContext();
            if (_context.Paymenttypes.FirstOrDefault(v => v.Title == value.Title) != null)
                result = true;

            return result;
        }

        public bool EditPaymentType(Paymenttype value)
        {
            var result = false;

            RefreshContext();

            if (_context.Paymenttypes.FirstOrDefault(v => v.Title == value.Title) != null)
                return result;

            _context.Paymenttypes.Update(_context.Paymenttypes.FirstOrDefault(v => v.Title == value.Title));
            Save();

            RefreshContext();
            if (_context.Paymenttypes.FirstOrDefault(v => v.Title == value.Title) != null)
                result = true;

            return result;
        }

        public bool DeletePaymentType(Paymenttype value)
        {
            var result = false;

            RefreshContext();

            if (_context.Paymenttypes.FirstOrDefault(v => v.Title == value.Title) == null)
                return result;

            _context.Paymenttypes.Remove(_context.Paymenttypes.FirstOrDefault(v => v.Title == value.Title));
            Save();

            RefreshContext();
            if (_context.Paymenttypes.FirstOrDefault(v => v.Title == value.Title) == null)
                result = true;

            return result;
        }

        #endregion

        #region ReportType

        public List<Reporttype> GetAllReportTypes()
        {
            RefreshContext();
            List<Reporttype> result = [.. _context.Reporttypes];

            return result;
        }

        public bool AddReportType(Reporttype value)
        {
            var result = false;

            RefreshContext();

            if (_context.Reporttypes.FirstOrDefault(v => v.Title == value.Title) != null)
                return result;

            _context.Reporttypes.Add(value);
            Save();

            RefreshContext();
            if (_context.Reporttypes.FirstOrDefault(v => v.Title == value.Title) != null)
                result = true;

            return result;
        }

        public bool EditReportType(Reporttype value)
        {
            var result = false;

            RefreshContext();

            if (_context.Reporttypes.FirstOrDefault(v => v.Title == value.Title) != null)
                return result;

            _context.Reporttypes.Update(_context.Reporttypes.FirstOrDefault(v => v.Title == value.Title));
            Save();

            RefreshContext();
            if (_context.Reporttypes.FirstOrDefault(v => v.Title == value.Title) != null)
                result = true;

            return result;
        }

        public bool DeleteReportType(Reporttype value)
        {
            var result = false;

            RefreshContext();

            if (_context.Reporttypes.FirstOrDefault(v => v.Title == value.Title) == null)
                return result;

            _context.Reporttypes.Remove(_context.Reporttypes.FirstOrDefault(v => v.Title == value.Title));
            Save();

            RefreshContext();
            if (_context.Reporttypes.FirstOrDefault(v => v.Title == value.Title) == null)
                result = true;

            return result;
        }

        #endregion

        #region Rate

        public List<Rate> GetAllRates()
        {
            RefreshContext();
            List<Rate> result = [.. _context.Rates];

            return result;
        }

        public bool AddRate(Rate value)
        {
            var result = false;

            RefreshContext();

            if (_context.Rates.FirstOrDefault(v => v.Title == value.Title) != null)
                return result;

            _context.Rates.Add(value);
            Save();

            RefreshContext();
            if (_context.Rates.FirstOrDefault(v => v.Title == value.Title) != null)
                result = true;

            return result;
        }

        public bool EditRate(Rate value)
        {
            var result = false;

            RefreshContext();

            if (_context.Rates.FirstOrDefault(v => v.Title == value.Title) != null)
                return result;

            _context.Rates.Update(_context.Rates.FirstOrDefault(v => v.Title == value.Title));
            Save();

            RefreshContext();
            if (_context.Rates.FirstOrDefault(v => v.Title == value.Title) != null)
                result = true;

            return result;
        }

        public bool DeleteRate(Rate value)
        {
            var result = false;

            RefreshContext();

            if (_context.Rates.FirstOrDefault(v => v.Title == value.Title) == null)
                return result;

            _context.Rates.Remove(_context.Rates.FirstOrDefault(v => v.Title == value.Title));
            Save();

            RefreshContext();
            if (_context.Rates.FirstOrDefault(v => v.Title == value.Title) == null)
                result = true;

            return result;
        }

        #endregion

        #endregion
    }
}

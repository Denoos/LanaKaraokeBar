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

        #endregion
    }
}

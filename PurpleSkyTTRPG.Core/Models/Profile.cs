using PurpleSkyTTRPG.Core.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace PurpleSkyTTRPG.Core.Models
{
    public class Profile
    {
        private Profile(Guid id, string login, string passwordHash, string profileJson)
        {
            Id = id;
            Login = login;
            PasswordHash = passwordHash;
            ProfileJson = profileJson;
        }

        public Guid Id { get; }
        public string Login { get; }
        public string PasswordHash { get; }
        public string ProfileJson { get; }

        public static (Profile Profile, string Error) Create(Guid id, string login, string passwordHash, string profileJson = "{}")
        {
            var error = string.Empty;

            if (string.IsNullOrWhiteSpace(login))
            {
                error = "Login cannot be empty";
            }
            else if (login.Length > EntityConstraints.MAX_LOGIN_LENGTH)
            {
                error = $"Login cannot be longer than {EntityConstraints.MAX_LOGIN_LENGTH} characters";
            }

            var profile = new Profile(id, login, passwordHash, profileJson);

            return (profile, error);
        }
    }
}

using AutoMapper;
using ProcessInfo.DB.Models;
using ProcessInfo.Web.Models.DTOs.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProcessInfo.Web.AutoMapperProfiles.RequestDTOs
{
    public class SaveUserRequestDTOProfile: Profile
    {
        public SaveUserRequestDTOProfile()
        {
            var salt = GenerateSalt();
            CreateMap<SaveUserRequestDTO, User>()
              .ForMember(m => m.PasswordSalt, map => map.MapFrom(s => salt))
              .ForMember(m => m.PasswordHash, map => map.MapFrom(s => HashPassword(s.Password, salt)));
        }

        public static string GenerateSalt()
        {
            // Define min and max salt sizes.
            var minSaltSize = 32;
            var maxSaltSize = 64;

            // Generate a random number for the size of the salt.
            var random = new Random();
            var saltSize = random.Next(minSaltSize, maxSaltSize);

            // Allocate a byte array, which will hold the salt.
            var saltBytes = new byte[saltSize];

            // Initialize a random number generator.
            var rng = RandomNumberGenerator.Create();

            // Fill the salt with cryptographically strong byte values.
            //rng.GetNonZeroBytes(saltBytes);
            rng.GetBytes(saltBytes);

            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string passwordSalt)
        {
            using (var hash = SHA512.Create())
            {
                var saltedPlainTextBytes = Encoding.UTF8.GetBytes(password).Concat(Convert.FromBase64String(passwordSalt)).ToArray();
                var hashedBytes = hash.ComputeHash(saltedPlainTextBytes);
                return Convert.ToBase64String(hashedBytes);
            }
        }

    }
}

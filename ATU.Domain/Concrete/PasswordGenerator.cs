using System;
using ATU.Domain.Abstract;

namespace ATU.Domain.Concrete
{
    public class PasswordGenerator : IPasswordGenerator
    {
        private readonly IConfigurationService _configuration;

        public PasswordGenerator(IConfigurationService configuration)
        {
            _configuration = configuration;
        }

        public string GeneratePassword()
        {
            return _configuration.GenerateSimplePassword ? "aaaaaaaa" : Guid.NewGuid().ToString().Replace("-", string.Empty).Substring(10, 8);
        }
    }
}
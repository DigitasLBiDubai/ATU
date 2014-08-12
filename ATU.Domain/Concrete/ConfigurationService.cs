using System.Configuration;
using ATU.Domain.Abstract;

namespace ATU.Domain.Concrete
{
    public class ConfigurationService : IConfigurationService
    {
        public string GoogleMapsApiUrl
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("google.maps.api.url");
            }
        }

        public string GoogleMapsApiResponseFormat
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("google.maps.api.response.format");
            }
        }
        
        public string GoogleMapsApiSensor
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("google.maps.api.sensor");
            }
        }

        public bool GenerateSimplePassword
        {
            get
            {
                var value = ConfigurationManager.AppSettings.Get("GenerateSimplePassword");

                if (string.IsNullOrEmpty(value) || string.Equals(value, bool.FalseString)) return false;

                return string.Equals(value, bool.TrueString);
            }
        }

        public bool SendGridActive
        {
            get
            {
                var value = ConfigurationManager.AppSettings.Get("SendGridActive");

                if (string.IsNullOrEmpty(value) || string.Equals(value, bool.FalseString)) return false;

                return string.Equals(value, bool.TrueString);
            }
        }

        public string SendGridUsername
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("SendGridUsername");
            }
        }

        public string SendGridPassword
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("SendGridPassword");
            }
        }

        public string DAMUrl
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("DAMUrl");
            }
        }

        public string DAMAssetsPath
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("DAMAssetsPath");
            }
        }

        public string DAMImageControllerPath
        {
            get
            {
                return ConfigurationManager.AppSettings.Get("DAMImageControllerPath");
            }
        }
    }
}
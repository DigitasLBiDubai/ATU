namespace ATU.Domain.Abstract
{
    public interface IConfigurationService
    {
        string GoogleMapsApiUrl { get; }
        string GoogleMapsApiResponseFormat { get; }
        string GoogleMapsApiSensor { get; }
        bool GenerateSimplePassword { get; }
        bool SendGridActive { get; }
        string SendGridUsername { get; }
        string SendGridPassword { get; }
        string DAMUrl { get; }
        string DAMAssetsPath { get; }
        string DAMImageControllerPath { get; }
    }
}
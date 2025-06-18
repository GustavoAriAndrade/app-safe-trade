namespace api_safe_trade.Application.Interfaces
{
    public interface IVideoCaptureService
    {
        void StartCapture(string cameraIp);
        void StopCapture();
    }
}
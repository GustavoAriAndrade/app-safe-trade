using api_safe_trade.Application.Interfaces;
using Emgu.CV;
using Emgu.CV.CvEnum;

namespace api_safe_trade.Application.Services
{
    public class VideoCaptureService : IVideoCaptureService
    {
        private VideoCapture? _capture;
        private bool _isCapturing = false;

        public void StartCapture(string cameraIp)
        {
            if (_isCapturing) return;

            try
            {
                string rtspUrl = $"rtsp://{cameraIp}";

                _capture = new VideoCapture(rtspUrl, VideoCapture.API.Ffmpeg);
                _capture.ImageGrabbed += ProcessFrame;
                _capture.Start();
                _isCapturing = true;

                Console.WriteLine("Captura iniciada com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao iniciar captura: {ex.Message}");
            }
        }

        public void StopCapture()
        {
            if (!_isCapturing || _capture == null) return;

            _capture.Stop();
            _capture.Dispose();
            _capture = null;
            _isCapturing = false;

            Console.WriteLine("Captura finalizada.");
        }

        private void ProcessFrame(object? sender, EventArgs e)
        {
            if (_capture == null || !_capture.Ptr.Equals(IntPtr.Zero)) return;

            using var frame = new Mat();

            _capture.Retrieve(frame);

            if (!frame.IsEmpty)
            {
                var basePath = Path.Combine(Directory.GetCurrentDirectory(), "Captures");

                Directory.CreateDirectory(basePath);

                string fileName = $"frame_{DateTime.Now:yyyyMMdd_HHmmss_fff}.jpg";

                string filePath = Path.Combine(basePath, fileName);

                frame.Save(filePath);

                Console.WriteLine($"Frame salvo em: {filePath}");
            }
        }
    }
}
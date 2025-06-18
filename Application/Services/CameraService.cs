using api_safe_trade.Application.Interfaces;
using api_safe_trade.Domain.Entities;
using api_safe_trade.Infrastructure.Data;

namespace api_safe_trade.Application.Services
{
    public class CameraService : ICameraService
    {
        private readonly AppDbContext _context;

        public CameraService(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Camera input)
        {
            _context.Cameras.Add(input);

            await _context.SaveChangesAsync();
        }

        public async Task<List<Camera>> GetListAsync()
        {
            return await _context.Cameras.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Camera> GetByIdAsync(int id)
        {
            return await _context.Cameras.FirstOrDefault(x => x.Id == id);
        }

        public async Task UpdateAsync(Camera input)
        {
            var existingCamera = await _context.Cameras.FirstOrDefault(x = x => x.Id == input.Id);

            if (existingCamera is null)
                throw new Exception("Câmera não existe");

            _context.Cameras.Entry(existingCamera).CurrentValues.SetValues(input);

            await _context.SaveChangesAsync();
        }
    }
}
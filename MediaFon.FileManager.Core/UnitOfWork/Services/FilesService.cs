﻿using MediaFon.FileManager.Core.Interfaces;
using MediaFon.FileManager.Core.Repositories;
using MediaFon.FileManager.Infrastructure.Data;
 

namespace MediaFon.FileManager.Core.UnitOfWork.Services
{
    public class FilesService : IUnitOfWork 
    {
        private readonly ApplicationDbContext _context;

        public FilesRepository Files { get; private set; }

        public FilesService(ApplicationDbContext context)
        {
            _context = context;
            Files = new FilesRepository(_context);
             
            
        }



        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

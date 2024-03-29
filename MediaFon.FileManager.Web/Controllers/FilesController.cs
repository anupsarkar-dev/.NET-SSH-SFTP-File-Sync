﻿using MediaFon.FileManager.Core.Interfaces;
using MediaFon.FileManager.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Directory = MediaFon.FileManager.Domain.Entity.Directory;
using File = MediaFon.FileManager.Domain.Entity.File;


namespace MediaFon.FileManager.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {        
        IFilesInfoServiceUnitOfWork filesService;
       
        public FilesController(IFilesInfoServiceUnitOfWork filesInfoDbService) => filesService = filesInfoDbService;


        [HttpGet()]
        [Route("GetAllSFTPEventLogs")]
        [SwaggerOperation(Summary = "Get All SFTP Background Jobs Event Logs")]
        public async Task<IEnumerable<EventLogs>> GetAllSFTPEventLogs() =>  await filesService.EventLogs.GetAllAsync();


        [HttpGet()]
        [Route("GetAllFilesInfo")]
        [SwaggerOperation(Summary = "Get All Files Info from Database")]
        public async Task<IEnumerable<File>> GetAllFiles() => await filesService.Files.GetAllAsync();


        [HttpGet()]
        [Route("AllDirectoriesInfo")]
        [SwaggerOperation(Summary = "Get All Files Directories Info from Database")]
        public async  Task<IEnumerable<Directory>> GetAllDirectories() => await filesService.Directories.GetAllAsync();

    }
}

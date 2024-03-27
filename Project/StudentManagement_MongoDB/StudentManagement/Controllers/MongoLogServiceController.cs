using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Services;

namespace StudentManagement.Controllers
{
    [Route("api/mongoManagement")]
    [ApiController]
    public class MongoLogServiceController : ControllerBase
    {
        private readonly IMongoLogService _mongoDbLogService;

        public MongoLogServiceController(IMongoLogService mongoDbLogService)
        {
            _mongoDbLogService = mongoDbLogService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("databaseInfo")]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDatabasesName()
        {
            try
            {
                var getDatabaseName = await _mongoDbLogService.GetDatabasesNameAsync();
                return Ok(getDatabaseName);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("collectionInfo")]
        [ProducesResponseType(typeof(List<string>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCollectionsName(string databaseName)
        {
            try
            {
                var getCollectionName = await _mongoDbLogService.GetCollectionsNameAsync(databaseName);
                return Ok(getCollectionName);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseName"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("documentInfo")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDocuments(string databaseName, string collectionName)
        {
            try
            {
                var getDocuments = await _mongoDbLogService.GetDocumentsAsync(databaseName, collectionName);
                return Ok(getDocuments);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseName"></param>
        /// <param name="collectionName"></param>
        /// <param name="uniTranId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("documentByUniTranId")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetDocumentByUniTranId(string databaseName, string collectionName, string uniTranId)
        {
            try
            {
                var getDocuments = await _mongoDbLogService.GetDocumentByUniTranIdAsync(databaseName, collectionName, uniTranId);
                return Ok(getDocuments);
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseName"></param>
        /// <param name="collectionName"></param>
        /// <param name="uniTranId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("removeDocumentByUniTranId")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<ActionResult> DeleteDocumentByUniTranId(string databaseName, string collectionName, string uniTranId)
        {
            try
            {
                var isDelete = await _mongoDbLogService.DeleteDocumentByUniTranIdAsync(databaseName, collectionName, uniTranId);
                if (isDelete == true)
                    return Ok($"Succesfully delete UniqueTranId: {uniTranId}");
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                return NotFound($"Failed to delete UniqueTranId: {uniTranId}");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formData"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("uploadDocument")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public async Task<ActionResult> UploadDocument(IFormCollection formData)
        {
            try
            {
                string databaseName = formData["databaseName"], collectionName = formData["collectionName"];
                var file = formData.Files["file"];

                var isUpload = await _mongoDbLogService.UploadDocumentAsync(databaseName, collectionName, file);
                if (isUpload == true)
                    return NoContent();
                else
                    throw new Exception();
            }
            catch (Exception)
            {
                return NotFound($"Upload Failed.");
            }
        }
    }
}

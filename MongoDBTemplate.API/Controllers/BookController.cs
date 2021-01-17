using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDBTemplate.Core.Models.Common;
using MongoDBTemplate.Core.Models.Entities;
using MongoDBTemplate.Infrastructure.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBTemplate.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private IRepository _repository;

        public BookController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("Add")]
        public async Task<Result> Add([FromBody] Book book)
        {
            Result rslt = new Result();

            try
            {
                await _repository.Add(book);
                rslt.Status = 1;
                rslt.Message = "Success";
            }
            catch (Exception ex)
            {
                rslt.Status = 0;
                rslt.Message = ex.Message;
            }

            return rslt;
        }

        [HttpDelete("Remove")]
        public async Task<Result> Remove(string id)
        {
            Result rslt = new Result();

            try
            {

                rslt.Data = await _repository.Delete(id);

                rslt.Status = 1;
                rslt.Message = "Success";
            }
            catch (Exception ex)
            {
                rslt.Status = 0;
                rslt.Message = ex.Message;
            }

            return rslt;
        }

        [HttpGet("Get")]
        public async Task<Result> Get(string id)
        {
            Result rslt = new Result();

            try
            {
                rslt.Data = await _repository.GetBook(id);
                rslt.Status = 1;
                rslt.Message = "Success";
            }
            catch (Exception ex)
            {
                rslt.Status = 0;
                rslt.Message = ex.Message;
            }

            return rslt;
        }

        [HttpGet("GetAll")]
        public async Task<Result> GetAll()
        {
            Result rslt = new Result();

            try
            {
                rslt.Data = await _repository.GetBooks();
                rslt.Status = 1;
                rslt.Message = "Success";
            }
            catch (Exception ex)
            {
                rslt.Status = 0;
                rslt.Message = ex.Message;
            }

            return rslt;
        }

        [HttpPut("Update")]
        public async Task<Result> Update([FromBody]Book book)
        {
            Result rslt = new Result();

            try
            {
                rslt.Data = await _repository.Update(book);
                rslt.Status = 1;
                rslt.Message = "Success";
            }
            catch (Exception ex)
            {
                rslt.Status = 0;
                rslt.Message = ex.Message;
            }

            return rslt;
        }
    }
}

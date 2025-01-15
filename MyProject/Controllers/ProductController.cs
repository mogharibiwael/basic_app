using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS_Lib.CQRS.Commands;
using CQRS_Lib.CQRS.Queries;
using CQRS_Lib.Data.Models;
using CQRS_Lib.Repo;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
      

        public ProductController(IitemRepo iitemRepo,IMediator mediator) 
        {
            _repo = iitemRepo;
            _mediator = mediator;

        }
        private readonly IitemRepo _repo;
        private readonly IMediator _mediator;
        // GET: api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            //return Ok(_repo.GetProducts());

            var result = await _mediator.Send(new GetAllItemsQuery());

            return  Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {

            return  _repo.GetProduct(id);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            var result = await _mediator.Send(new InsertItemCommand(product));
            return Ok(result);




        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]string value)
        {
            var product=_repo.GetProduct(id);
            _repo.UpdateProduct(product);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}


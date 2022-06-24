using Microsoft.AspNetCore.Mvc;
using Pharmacy_Management1.Repository;
using Pharmacy_Management1.Models;
using Pharmacy_Management1.Dto;
using System.Threading.Tasks;



namespace Pharmacy_Management1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        private readonly IDrugRepository _drugRepository;



        public DrugController(IDrugRepository drugRepository)
        {
            _drugRepository = drugRepository;
        }
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var drug = await _drugRepository.GetAll();
            return Ok(drug);



        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                throw new InvalidException("Invalid Id");
            }
            var supplier = _drugRepository.GetDrug(id);
            if (supplier == null)
            {
                throw new InvalidException("Invalid Id");
            }
            return new OkObjectResult(supplier);
        }
        [HttpGet("Drugs/{drugName}")]
        public IActionResult GetDrugName(string drugName)
        {
            var drug = _drugRepository.GetDrugName(drugName);
            return new OkObjectResult(drug);
        }
        [HttpPost]
        public IActionResult Post(DrugDto drugDto)
        {
            var drug = new DrugDetail
            {

                DrugId = drugDto.DrugId,
                DrugName = drugDto.DrugName,
                Quantity = drugDto.Quantity,
                ExpiryDate = drugDto.ExpiryDate,
                Price = drugDto.Price,
                SupplierId = drugDto.SupplierId,
            };
            var newSupplier = _drugRepository.Create(drug);
            return Created("Sucess", newSupplier);



        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, DrugDto drugDto)
        {
            var drug = new DrugDetail
            {
                DrugId = drugDto.DrugId,
                DrugName = drugDto.DrugName,
                Quantity = drugDto.Quantity,
                Price = drugDto.Price,
                SupplierId = drugDto.SupplierId,
            };



            _drugRepository.UpdateDrug(drug);
            return new OkResult();



        }



        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _drugRepository.DeleteDrug(id);
            return Ok();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Pharmacy_Management1.Models;
using Pharmacy_Management1.Repository;
using Pharmacy_Management1.Dto;
using System;


namespace Pharmacy_Management1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly ISuplierRepository _suplierRepository;
        public SupplierController(ISuplierRepository suplierRepository)
        {
            _suplierRepository = suplierRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {

            var supplier = _suplierRepository.GetAll();
            return Ok(supplier);


        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                throw new InvalidException("Invalid Id");
            }
            var supplier = _suplierRepository.GetSupplier(id);
            if (supplier == null)
            {
                throw new InvalidException("Invalid Id");
            }
            return new OkObjectResult(supplier);
        }
        [HttpPost]
        public IActionResult Post(CreateSupplierDto createSupplier)
        {
            var supplier = new SupplierDetail
            {
                SupplierName = createSupplier.SupplierName,
                SupplierContact = createSupplier.SupplierContact,
                SupplierEmail = createSupplier.SupplierEmail,
            };
            var newSupplier = _suplierRepository.Create(supplier);
            return Created("Sucess", newSupplier);

        }
        #region supplier      
        [HttpPut("{id}")]
        public IActionResult Put(int id, CreateSupplierDto createSupplier)
        {
            try
            {
                var supplier = new SupplierDetail
                {
                    SupplierId = createSupplier.SupplierId,
                    SupplierName = createSupplier.SupplierName,
                    SupplierContact = createSupplier.SupplierContact,
                    SupplierEmail = createSupplier.SupplierEmail,
                };
                _suplierRepository.UpdateSupplier(supplier);
                return new OkResult();
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }
        #endregion supplier
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _suplierRepository.DeleteSupplier(id);
            return Ok();
        }

    }
}
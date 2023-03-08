using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DrugManagementAPI.Models;

namespace DrugManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private static List<Supplier> suppliers = new List<Supplier>()
        {
            new Supplier
            {
                 Name = "John",
                 SupplierId = 101,
                 Address = "Mysore",
                 Company = "xyz"
            },
            new Supplier
            {
                 Name = "Mathew",
                 SupplierId = 201,
                 Address = "Banglore",
                 Company = "uvw"
            }
        };

        [HttpGet("GetAllSuppliers")]
        public List<Supplier> GetAllSuppliers()
        {
            return suppliers;
        }

        [HttpPost("AddSupplier")]
        public void AddSupplier(Supplier supplier)
        {
            suppliers.Add(supplier);
        }

        [HttpDelete("DeleteSupplier/{SupplierId:int}")]
        public void DeleteSupplier(int SupplierId)
        {
            var SupplierToBeDeleted = suppliers.Where(s => s.SupplierId == SupplierId).FirstOrDefault();
            suppliers.Remove(SupplierToBeDeleted);
        }

        [HttpGet("RetriewSupplier/{SupplierId:int}")]
        public Supplier RetriewSupplier(int SupplierId)
        {
            var SupplierToBeDisplayed = suppliers.Where(s => s.SupplierId == SupplierId).FirstOrDefault();
            return SupplierToBeDisplayed;
        }
    }
}

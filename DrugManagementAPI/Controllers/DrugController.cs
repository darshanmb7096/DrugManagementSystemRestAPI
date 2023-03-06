using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DrugManagementAPI.Models;

namespace DrugManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        

        private static List<Drug> DrugList = new List<Drug>()
        {
           new Drug
           {
               Name="Dolo360",
               Id=123,
               SerialNumber = "ABC123",
               ManufacturedDate= new DateTime(2023,01,01),
               ExpiredDate= new DateTime(2025,01,01),
           },
           new Drug
           {
               Name="Aspirin",
               Id=456,
               SerialNumber = "DEF456",
               ManufacturedDate= new DateTime(2023,01,01),
               ExpiredDate= new DateTime(2025,01,01),
           },
           new Drug
           {
               Name="HyglymG1",
               Id=789,
               SerialNumber = "GHI789",
               ManufacturedDate= new DateTime(2023,01,01),
           }

        };
        [HttpGet("GetAllDrugs")]
        public List<Drug> GetAllDrugs()    //Converting c# object to json is called serialization
        {
            return DrugList;
        }

        [HttpPost("AddDrug")]
        public void AddDrug(Drug drug)  //Converting json to c# object is called Deserialization
        {
            DrugList.Add(drug);
        }
        [HttpDelete("DeleteDrug")]
        public void DeleteDrug(int DrugID)
        {
            var DrugToBeDeleted = DrugList.Where(d=>d.Id==DrugID).FirstOrDefault();
            DrugList.Remove(DrugToBeDeleted);

        }
        [HttpGet("DisplayDrug")]        
        
        public Drug DisplayeDrug(int DrugID)
        {
            var DrugToBeDisplayed = DrugList.Where(d => d.Id == DrugID).FirstOrDefault();
            return DrugToBeDisplayed;

        }
    }
} 

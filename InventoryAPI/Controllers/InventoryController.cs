using Inventory.IBL;
using INV =Inventory.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventoryAPI.Controllers
{
    [RoutePrefix("api/Inventory")]
    public class InventoryController : ApiController
    {
        IInventoryRepository _repo;
               
        public InventoryController(IInventoryRepository repository)
        {
            _repo = repository;
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetInventories()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, _repo.GetAllInventory());
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "oop..soemthing went wrong..please contact to Admin..!!");
            }
            
        }

        [Route("{id}")]
        [HttpGet]
        public HttpResponseMessage GetInvById(int id)
        {
            try
            {
                INV.Inventory tempInv = _repo.GetInventoryById(id);
                if (tempInv == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, $"Inventory with id: {id} does not exists.");

                }
                return Request.CreateResponse(HttpStatusCode.OK, tempInv);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "oop..soemthing went wrong..please contact to Admin..!!",ex);
            }
           

            
        }

        [Route("")]
        [HttpPost]
        public HttpResponseMessage AddInventory(INV.Inventory inventory)
        {
            try
            {
                _repo.AddInventory(inventory);
                return Request.CreateResponse(HttpStatusCode.Created, inventory);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "oop..soemthing went wrong..please contact to Admin..!!", ex);   
            }
        }

        [Route("")]
        [HttpPut]
        public HttpResponseMessage UpdateInventory(INV.Inventory inventory)
        {
            try
            {
               var result = _repo.UpdateInventory(inventory);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "oop..soemthing went wrong..please contact to Admin..!!", ex);
            }
             
        }

        [Route("{id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteInventory(int id)
        {
            try
            {
                _repo.DeleteInventory(id);
                var message = Request.CreateResponse(HttpStatusCode.OK);
                return message;
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "oop..soemthing went wrong..please contact to Admin..!!", ex);
            }
            
        }



    }
}

using Amaris.BussinessLogic;
using NLog;
using System.Web.Http;


namespace Amaris.Web.Api.Controllers
{
    public class ClientsController : ApiController
    {
        private IClientsBussinessLogic clientsBusinessLogic { get; set; }
        private string Roles { get; set; }

        public ClientsController(IClientsBussinessLogic _clientsBusinessLogic)
        {
            clientsBusinessLogic = _clientsBusinessLogic;
        }

        /// <summary>
        /// Get user by id 
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        //[Authorization(Roles = "users-admin")]
        [HttpPost, Route("Amaris/Clients/GetById")]
        public IHttpActionResult GetById(string pId)
        {
            try
            {
                Roles = "users;admin";
                var response = clientsBusinessLogic.GetById(pId);

                if (response != null)
                {
                    if (!Roles.ToUpper().Contains(response.role.ToUpper()))
                    {
                        return Content(System.Net.HttpStatusCode.Unauthorized, "Unauthorized");
                    }
                    return Ok(response);
                }
                return Content(System.Net.HttpStatusCode.OK, "The client is not found");
            }
            catch (System.Exception err)
            {
                var logger = LogManager.GetLogger("db");
                logger.Error(err, "Error");
                return Content(System.Net.HttpStatusCode.InternalServerError, "Ha ocurrido un error");
            }
        }

        /// <summary>
        /// /// Get user by name 
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        //[Authorization(Roles = "users-admin")]
        [HttpPost, Route("Amaris/Clients/GetByName")]
        public IHttpActionResult GetByName(string pName)
        {
            try
            {
                Roles = "users;admin";
                var response = clientsBusinessLogic.GetByName(pName);

                if (response != null)
                {
                    if (!Roles.ToUpper().Contains(response.role.ToUpper()))
                    {
                        return Content(System.Net.HttpStatusCode.Unauthorized, "Unauthorized");
                    }
                    return Ok(response);
                }
                return Content(System.Net.HttpStatusCode.OK, "The client is not found");
            }
            catch (System.Exception err)
            {
                var logger = LogManager.GetLogger("db");
                logger.Error(err, "Error");
                return Content(System.Net.HttpStatusCode.InternalServerError, "Ha ocurrido un error");
            }
        }


        /// <summary>
        /// Get user by number policy
        /// </summary>
        /// <param name="pNumberPolicy"></param>
        /// <returns></returns>
        //[Authorization(Roles = "admin")]        
        [HttpPost, Route("Amaris/Clients/GetByNumberPolicy")]
        public IHttpActionResult GetByNumberPolicy(string pNumberPolicy)
        {
            try
            {
                Roles = "admin";
                var response = clientsBusinessLogic.GetByNumberPolicy(pNumberPolicy);

                if (response != null)
                {
                    if (!Roles.ToUpper().Contains(response.role.ToUpper()))
                    {
                        return Content(System.Net.HttpStatusCode.Unauthorized, "Unauthorized");
                    }
                    return Ok(response);
                }
                return Content(System.Net.HttpStatusCode.OK, "The client is not found");
            }
            catch (System.Exception err)
            {
                var logger = LogManager.GetLogger("db");
                logger.Error(err, "Error");
                return Content(System.Net.HttpStatusCode.InternalServerError, "Ha ocurrido un error");
            }
        }

        //[Authorization(Roles = "users-admin")]
        //[HttpGet, Route("Amaris/Clients/GetAll")]
        //public IHttpActionResult GetAll()
        //{
        //    var response = clientsBusinessLogic.GetAll();
        //    if (response != null)
        //    {
        //        return Ok(response);
        //    }
        //    return Content(System.Net.HttpStatusCode.NotFound, "Do not exist clients");
        //}
    }
}

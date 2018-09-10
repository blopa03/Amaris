using Amaris.BussinessLogic;
using NLog;
using System.Web.Http;

namespace Amaris.Web.Api.Controllers
{
    public class PoliciesController : ApiController
    {
        private IPoliciesBussinessLogic policiesBusinessLogic { get; set; }
        private IClientsBussinessLogic clientsBusinessLogic { get; set; }
        private string Roles { get; set; }
        public PoliciesController(IPoliciesBussinessLogic _policiesBusinessLogic, IClientsBussinessLogic _clientsBusinessLogic)
        {
            policiesBusinessLogic = _policiesBusinessLogic;
            clientsBusinessLogic = _clientsBusinessLogic;
        }

        /// <summary>
        /// Get List policies by name client
        /// </summary>
        /// <param name="pNameClient"></param>
        /// <returns></returns>
        //[Authorization(Roles = "admin")]
        [HttpPost, Route("Amaris/Policies/GetByNameClient")]
        public IHttpActionResult GetByNameClient(string pNameClient)
        {
            try
            {
                Roles = "admin";
                var client = clientsBusinessLogic.GetByName(pNameClient);
                if (client != null)
                {
                    if (!Roles.ToUpper().Contains(client.role.ToUpper()))
                    {
                        return Content(System.Net.HttpStatusCode.Unauthorized, "Unauthorized");
                    }
                    var response = policiesBusinessLogic.GetByIdClient(client.id);
                    return Ok(response);
                }
                return Content(System.Net.HttpStatusCode.OK, "The police is not found");
            }
            catch (System.Exception err)
            {
                var logger = LogManager.GetLogger("db");
                logger.Error(err, "Error");
                return Content(System.Net.HttpStatusCode.InternalServerError, "Ha ocurrido un error");
            }
        }

        //[Authorization(Roles = "admin")]
        //[HttpGet, Route("Amaris/Policies/GetAll")]
        //public IHttpActionResult GetAll()
        //{
        //    var response = policiesBusinessLogic.GetAll();
        //    if (response != null)
        //    {
        //        return Ok(response);
        //    }
        //    return Content(System.Net.HttpStatusCode.NotFound, "Do not exist policies ");
        //}



        //[Authorization(Roles = "admin")]
        //[HttpPost, Route("Amaris/Policies/GetByIdClient")]
        //public IHttpActionResult GetByIdClient(string pIdClient)
        //{
        //    var response = policiesBusinessLogic.GetByIdClient(pIdClient);
        //    if (response != null)
        //    {
        //        return Ok(response);
        //    }
        //    return Content(System.Net.HttpStatusCode.NotFound, "Do not exist policies ");
        //}
    }
}

using Interface;
using System.Web.Http;
using TestProject_Framework.Utility;
using Unity;

namespace TestProject_Framework.Controllers
{
    public class IOCController : ApiController
    {
        private IUserService m_userService = null;
        public IOCController(IUserService userService)
        {
            m_userService = userService;
        }
        public string Get(int id)
        {
            IUserService service = ContainerFactory.BuildContainer().Resolve<IUserService>();
            return service.Query(id);
        }
    }
}
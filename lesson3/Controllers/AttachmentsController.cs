using lesson3.Models;
using lesson3.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace lesson3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentsController : ControllerBase
    {
        private readonly IAttachmentsServices _attachmentsServices;

        public AttachmentsController(IAttachmentsServices attachmentsServices)
        {
            _attachmentsServices = attachmentsServices;
        }

        [HttpPost]
        public DataTable Create(Attachments attachments)
        {
            return _attachmentsServices.AddAttachments(attachments);
            
        }


    }
}

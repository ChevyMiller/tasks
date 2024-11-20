using lesson3.Models;
using lesson3.Repositories;
using System.Data;

namespace lesson3.Services
{
    public class AttachmentsServices: IAttachmentsServices
    {
        private readonly IAttachmentsRepository _attachmentsRepository;

        public AttachmentsServices(IAttachmentsRepository attachmentsRepository)
        {
            _attachmentsRepository = attachmentsRepository;
        }
        public DataTable AddAttachments(Attachments attachments)
        {
            return _attachmentsRepository.AddAttachments(attachments);

        }

      
    }
}

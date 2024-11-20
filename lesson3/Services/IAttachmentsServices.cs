using lesson3.Models;
using System.Data;

namespace lesson3.Services
{
    public interface IAttachmentsServices
    {
        DataTable AddAttachments(Attachments attachments);
    }
}

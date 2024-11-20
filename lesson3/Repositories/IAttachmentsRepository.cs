using lesson3.Models;
using System.Data;

namespace lesson3.Repositories
{
    public interface IAttachmentsRepository
    {
        public DataTable AddAttachments(Attachments attachments);
    }
}

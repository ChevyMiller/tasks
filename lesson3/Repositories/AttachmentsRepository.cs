using lesson3.Models;
using Microsoft.Data.SqlClient;
using System.Data;


namespace lesson3.Repositories
{
    public class AttachmentsRepository: IAttachmentsRepository
    {
        string Cnn;

        public AttachmentsRepository(IConfiguration configuration)
        {
            // _configuration = configuration;
            Cnn = configuration.GetConnectionString("DefaultConnection");
        }
        public DataTable AddAttachments(Attachments attachments)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(Cnn))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    //commandtype
                    command.CommandText = "Add_Attachments";
                    command.CommandType = CommandType.StoredProcedure;

                    //paramters
                    SqlParameter sqlParameter = new SqlParameter("@Name", attachments.Name);
                    SqlParameter sqlParameter2 = new SqlParameter("@Path", attachments.Path);
                    SqlParameter sqlParameter3 = new SqlParameter("@Description", attachments.Description);
                    SqlParameter sqlParameter4 = new SqlParameter("@Task_id", attachments.Task_id);

                    command.Parameters.Add(sqlParameter);
                    command.Parameters.Add(sqlParameter2);
                    command.Parameters.Add(sqlParameter3);
                    command.Parameters.Add(sqlParameter4);
                    connection.Open();

                    using (SqlDataAdapter da = new SqlDataAdapter(command))
                    {
                        da.Fill(dt);
                    }

                }
            }

            return dt;
        }

    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class RLfile_Login : System.Web.UI.Page
{
    // Use SqlConnection instead of OleDbConnection for SQL Server
    SqlConnection conn = new SqlConnection(@"Server=DESKTOP-AMIMDNK\SQLEXPRESS;Database=HOTEL;Integrated Security=True;");
    SqlCommand cmd;
    string str;
    SqlDataAdapter daa = new SqlDataAdapter();
    DataTable dtt = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("../RLfile/Registration.aspx");
    }

    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Rlfile/Forgotpass.aspx");
    }

    protected void btn_login_Click(object sender, EventArgs e)
    {
        try
        {
            // Open the SQL Server connection
            conn.Open();

            // Use parameterized queries to prevent SQL injection attacks
            string str1 = "SELECT * FROM RGTBL WHERE uname = @uname AND pass = @pass";
            cmd = new SqlCommand(str1, conn);
            cmd.Parameters.AddWithValue("@uname", txt_login_username.Text);
            cmd.Parameters.AddWithValue("@pass", txt_login_password.Text);

            // Use SqlDataAdapter to execute the query and fill the DataTable
            daa = new SqlDataAdapter(cmd);
            daa.Fill(dtt);

            // Check if any rows were returned (successful login)
            if (dtt.Rows.Count > 0)
            {
                // Redirect the user to the booking page upon successful login
                Response.Redirect("../users/homepage.aspx");
            }
            else
            {
                // Handle invalid login (show a message or redirect to an error page)
                Response.Write("<script>alert('Invalid username or password');</script>");
            }
        }
        catch (Exception ex)
        {
            // Log or display the error message
            Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
        }
        finally
        {
            // Close the connection
            conn.Close();
        }
    }
}

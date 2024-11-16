using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class RLfile_Registration : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Only run on first load, not on postbacks
        if (!IsPostBack)
        {
            

            // Get the next available ID for the new user
            using (SqlConnection con = new SqlConnection(@"Server=DESKTOP-AMIMDNK\SQLEXPRESS;Database=HOTEL;Integrated Security=True;"))
            {
                con.Open();
                int id1 = 1;

                // SQL query to get the max ID
                string str = "SELECT MAX(ID) AS ID FROM RGTBL";
                SqlDataAdapter da = new SqlDataAdapter(str, con);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0 && ds.Tables[0].Rows[0]["ID"] != DBNull.Value)
                {
                    id1 = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString()) + 1;
                }

                lblid.Text = id1.ToString();
            }
        }
    }

    protected void btn_submit_Click(object sender, EventArgs e)
{
    // Validate that all fields are filled
    if (string.IsNullOrEmpty(txt_username.Text) || string.IsNullOrEmpty(txt_mobile.Text) ||
        string.IsNullOrEmpty(txt_email.Text) || string.IsNullOrEmpty(txt_password.Text) ||
        string.IsNullOrEmpty(txt_cpass.Text))
    {
        Response.Write("<script>alert('Please fill all fields correctly.');</script>");
        return;
    }

    // Ensure password and confirm password match
    if (txt_password.Text != txt_cpass.Text)
    {
        Response.Write("<script>alert('Passwords do not match.');</script>");
        return;
    }

    try
    {
        using (SqlConnection con = new SqlConnection(@"Server=DESKTOP-AMIMDNK\SQLEXPRESS;Database=HOTEL;Integrated Security=True;"))
        {
            con.Open();

            // SQL query to insert new user data into the registration table
            string query = "INSERT INTO RGTBL (ID, uname, mobile, email, pass) " +
                           "VALUES (@ID, @Username, @Mobile, @Email, @Password)";

            // Initialize command with the query and connection
            SqlCommand cmd = new SqlCommand(query, con);

            // Generate a new ID for the user
            int newId = 1; // Default to 1 if table is empty
            string idQuery = "SELECT ISNULL(MAX(ID), 0) + 1 FROM RGTBL";
            SqlCommand idCmd = new SqlCommand(idQuery, con);
            newId = (int)idCmd.ExecuteScalar();

            // Set parameters
            cmd.Parameters.AddWithValue("@ID", newId);
            cmd.Parameters.AddWithValue("@Username", txt_username.Text);
            cmd.Parameters.AddWithValue("@Mobile", txt_mobile.Text);
            cmd.Parameters.AddWithValue("@Email", txt_email.Text);
            cmd.Parameters.AddWithValue("@Password", txt_password.Text);

            // Execute the insert query
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Response.Write("<script>alert('Registration Successful'); window.location='Login.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alert('Error occurred during registration.');</script>");
            }
        }
    }
    catch (Exception ex)
    {
        Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
    }
}

}

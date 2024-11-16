using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class RLfile_Forgotpass : System.Web.UI.Page
{
    SqlConnection conn = new SqlConnection(@"Server=DESKTOP-AMIMDNK\SQLEXPRESS;Database=HOTEL;Integrated Security=True;");
    SqlCommand cmd;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_Forgot_password_Click(object sender, EventArgs e)
    {
        string mobile = txt_fpass_mobile.Text.Trim();
        string email = txt_fpasss_email.Text.Trim();
        string newPassword = txt_new_password.Text.Trim();
        string confirmPassword = txt_confirm_password.Text.Trim();

        // Check if passwords match
        if (newPassword != confirmPassword)
        {
            // Show a message indicating the passwords don't match
            Response.Write("<script>alert('Passwords do not match. Please try again.');</script>");
            return;
        }

        try
        {
            // Open the connection
            conn.Open();

            // Query to check if the user exists by mobile and email
            string str = "SELECT * FROM RGTBL WHERE mobile=@mobile AND email=@email";
            cmd = new SqlCommand(str, conn);
            cmd.Parameters.AddWithValue("@mobile", mobile);
            cmd.Parameters.AddWithValue("@email", email);

            SqlDataAdapter daa = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            daa.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                // User found, proceed to update the password
                string updateStr = "UPDATE RGTBL SET pass=@newPassword WHERE mobile=@mobile AND email=@email";
                SqlCommand updateCmd = new SqlCommand(updateStr, conn);
                updateCmd.Parameters.AddWithValue("@newPassword", newPassword);
                updateCmd.Parameters.AddWithValue("@mobile", mobile);
                updateCmd.Parameters.AddWithValue("@email", email);

                updateCmd.ExecuteNonQuery();

                // Show success message and redirect
                Response.Write("<script>alert('Password updated successfully!'); window.location='Login.aspx';</script>");
            }
            else
            {
                // User not found
                Response.Write("<script>alert('No user found with the provided mobile/email.');</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('An error occurred: " + ex.Message + "');</script>");
        }
        finally
        {
            conn.Close();
        }
    }
}

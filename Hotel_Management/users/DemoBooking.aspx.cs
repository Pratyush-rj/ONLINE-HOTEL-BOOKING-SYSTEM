using System;
using System.Data.SqlClient;  // Changed to SQL Server
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_DemoBooking : System.Web.UI.Page
{
    // Updated connection string to SQL Server
    SqlConnection con = new SqlConnection(@"Server=DESKTOP-AMIMDNK\SQLEXPRESS;Database=HOTEL;Integrated Security=True;");
    SqlCommand cmd;
    string str;

    protected void Page_Load(object sender, EventArgs e)
    {
        // If you need to load some data or initialize something, add here.
    }

    protected void Bt_submit_Click(object sender, EventArgs e)
    {
        try
        {
            // SQL Insert Statement (example with parameters)
            str = "INSERT INTO BOOKINGTAB (Column1, Column2, Column3, DateStart, DateEnd, Status, FullName) " +
                  "VALUES (@Column1, @Column2, @Column3, @DateStart, @DateEnd, @Status, @FullName)";

            // Prepare the SQL Command
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@Column1", DropDownList1.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@Column2", DropDownList2.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@Column3", DropDownList3.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@DateStart", datepicker1.Text);
            cmd.Parameters.AddWithValue("@DateEnd", datepicker2.Text);
            cmd.Parameters.AddWithValue("@Status", RadioButtonList1.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@FullName", "Your Full Name");  // Use an actual TextBox here for full name

            // Open the connection to SQL Server
            con.Open();
            cmd.ExecuteNonQuery();  // Execute the command to insert data
            con.Close();  // Close connection

            // Redirect to another page after submission
            Response.Redirect("../RLfile/Login.aspx");
        }
        catch (Exception ex)
        {
            // If error occurs, display message
            Response.Write("<script>alert('Error: " + ex.Message + "')</script>");
        }
    }
}

    using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;  // Changed to SQL Server
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class users_Booking : System.Web.UI.Page
{
    // Updated connection string to SQL Server
    SqlConnection con = new SqlConnection(@"Server=DESKTOP-AMIMDNK\SQLEXPRESS;Database=HOTEL;Integrated Security=True;");
    SqlCommand cmd;
    string str;

    protected void Page_Load(object sender, EventArgs e)
    {
        con.Open();

        int id2 = 0;
        // Using SQL Server query to get max BID
        string str1 = "SELECT MAX(BID) AS BID FROM BOOKINGTAB";
        SqlDataAdapter da = new SqlDataAdapter(str1, con);
        DataSet ds = new DataSet();
        da.Fill(ds);

        // Getting the value from the dataset
        id2 = int.Parse(ds.Tables[0].Rows[0]["BID"].ToString());
        
        // Ensure that id2 is incremented correctly
        id2 = (id2 > 0) ? id2 + 1 : 1;

        lblbid.Text = id2.ToString();
        con.Close();  // Close connection after use
    }

    protected void Bt_submit_Click(object sender, EventArgs e)
    {
        try
        {
            // Updated SQL Server insert statement (parameterized to avoid SQL injection)
            str = "INSERT INTO BOOKINGTAB (BID, ADULT, CHILD, ROOMS, [IN], [OUT], CUISINE, NAME) " +
                  "VALUES (@BID, @Column1, @Column2, @Column3, @DateStart, @DateEnd, @Status, @FullName)";

            // Using SqlCommand to interact with SQL Server
            cmd = new SqlCommand(str, con);
            cmd.Parameters.AddWithValue("@BID", lblbid.Text);
            cmd.Parameters.AddWithValue("@Column1", DropDownList1.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@Column2", DropDownList2.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@Column3", DropDownList3.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@DateStart", datepicker1.Text);
            cmd.Parameters.AddWithValue("@DateEnd", datepicker2.Text);
            cmd.Parameters.AddWithValue("@Status", RadioButtonList1.SelectedValue.ToString());
            cmd.Parameters.AddWithValue("@FullName", txt_fulname.Text);

            // Open connection, execute insert, and close connection
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            // Display success message
            Response.Write("<script>alert('Submitted successfully!')</script>");
        }
        catch (Exception ex)
        {
            // Display error message
            Response.Write("<script>alert('Error: " + ex.Message + "')</script>");
        }
    }

    protected void LinkButton_Logout_Click(object sender, EventArgs e)
    {
        // Redirect to homepage
        Response.Redirect("../users/homepage.aspx");
    }
}

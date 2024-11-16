<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forgotpass.aspx.cs" Inherits="RLfile_Forgotpass" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ForgotPass</title>
    <!-- meta tags -->
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- custom style sheet -->
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <!-- fontawesome css -->
    <link href="css/fontawesome-all.css" rel="stylesheet" />
    <!-- google fonts-->
    <link href="//fonts.googleapis.com/css?family=Raleway:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i"
        rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Online Hotel Booking</h1>
        <div class="w3l-login-form">
            <h2>Forgot Password Here</h2>
            <form action="#" method="POST">
                <div class="w3l-form-group">
                    <label>Mobile:</label>
                    <div class="group">
                        <i class="fas fa-user"></i>
                        <asp:TextBox ID="txt_fpass_mobile" class="form-control" placeholder="Mobile Number" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="w3l-form-group">
                    <label>Email ID:</label>
                    <div class="group">
                        <i class="fas fa-user"></i>
                        <asp:TextBox ID="txt_fpasss_email" class="form-control" placeholder="Email ID" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="w3l-form-group">
                    <label>New Password:</label>
                    <div class="group">
                        <i class="fas fa-unlock"></i>
                        <asp:TextBox ID="txt_new_password" TextMode="Password" class="form-control" placeholder="New Password" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="w3l-form-group">
                    <label>Confirm Password:</label>
                    <div class="group">
                        <i class="fas fa-unlock"></i>
                        <asp:TextBox ID="txt_confirm_password" TextMode="Password" class="form-control" placeholder="Confirm Password" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="forgot">
                    <p>
                        <asp:Button ID="btn_Forgot_password" runat="server" Text="Reset Password" BackColor="Blue" Font-Bold="True" Font-Size="Medium" ForeColor="#FFFFCC" OnClick="btn_Forgot_password_Click" />
                    </p>
                </div>
            </form>
            <p class="w3l-register-p">Sign IN<a href="../RLfile/Login.aspx" class="register"> Login</a></p>
        </div>
        <%--- x<footer>
            <p class="copyright-agileinfo"> &copy; 2022 Login. All Rights Reserved | Design by <a href="#">Pratyush Ranjan Behera</a></p>
        </footer>
        ---%>
    </div>
    </form>
</body>
</html>

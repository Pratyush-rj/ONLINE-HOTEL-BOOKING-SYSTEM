<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="RLfile_Registration" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Registration</title>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="css/style.css" rel="stylesheet" type="text/css" />
    <link href="css/fontawesome-all.css" rel="stylesheet" />
    <link href="//fonts.googleapis.com/css?family=Raleway:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Online Hotel Booking Registration</h1>
            <div class="w3l-login-form">
                <h2>Sign Up Here</h2>

                <div class="w3l-form-group">
                    <label>ID:</label>
                    <div class="group">
                        <i class="fas fa-user"></i>
                        <asp:Label ID="lblid" runat="server" Text="Label"></asp:Label>
                    </div>
                </div>

                <div class="w3l-form-group">
                    <label>Username:</label>
                    <div class="group">
                        <i class="fas fa-user"></i>
                        <asp:TextBox ID="txt_username" class="form-control" placeholder="Username" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="w3l-form-group">
                    <label>Mobile:</label>
                    <div class="group">
                        <i class="fas fa-user"></i>
                        <asp:TextBox ID="txt_mobile" class="form-control" placeholder="Mobile Number" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="w3l-form-group">
                    <label>Email ID:</label>
                    <div class="group">
                        <i class="fas fa-user"></i>
                        <asp:TextBox ID="txt_email" class="form-control" placeholder="Email ID" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="w3l-form-group">
                    <label>Password:</label>
                    <div class="group">
                        <i class="fas fa-unlock"></i>
                        <asp:TextBox ID="txt_password" TextMode="Password" class="form-control" placeholder="Password" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="w3l-form-group">
                    <label>Confirm Password:</label>
                    <div class="group">
                        <i class="fas fa-unlock"></i>
                        <asp:TextBox ID="txt_cpass" TextMode="Password" class="form-control" placeholder="Confirm Password" runat="server"></asp:TextBox>
                    </div>
                </div>

                <div class="forgot">
                    <p><asp:CheckBox ID="CheckBox1" runat="server" /> Remember Me</p>
                </div>

                <asp:Button ID="btn_submit" runat="server" Text="Registration" BackColor="Blue" Font-Bold="True" Font-Size="Medium" ForeColor="#FFFFCC" OnClick="btn_submit_Click" CausesValidation ="false" />
                
                <p class="w3l-register-p">Already have an account? <a href="Login.aspx" class="register">Login</a></p>
            </div>
            <%--- 
            <footer>
                <p class="copyright-agileinfo"> &copy; 2022 Login. All Rights Reserved | Design by <a href="#">Pratyush Ranjan Behera</a></p>
            </footer>
            ---%>
        </div>
    </form>
</body>
</html>

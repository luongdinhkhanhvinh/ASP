<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DoAnVegeFoody.Login1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="main_container" runat="server">
    <div class="col-lg-6">
		<div class="p-5">
			<div class="text-center">
				<h1 class="h4 text-gray-900 mb-4">Welcome Back!</h1>
                <asp:Label ID="txt_Message" runat="server" Text=" "></asp:Label>
			</div>
				<div class="form-group">
                    <asp:TextBox ID="UserName" CssClass="form-control form-control-user" placeholder="UserName." runat="server"></asp:TextBox>
                </div>
				<div class="form-group">
				    <asp:TextBox ID="Password" CssClass="form-control form-control-user" TextMode="password" placeholder="Password" runat="server"></asp:TextBox>
                </div>
				<div class="form-group">
					<div class="custom-control custom-checkbox small">
                        <asp:CheckBox ID="customCheck" CssClass="custom-control-input" runat="server" />
						<label class="custom-control-label" for="customCheck">Remember Me</label>
					</div>
				</div>
                <asp:Button ID="btn_Login" runat="server" CssClass="btn btn-primary btn-user btn-block" Text="Login" OnClick="btn_Login_Click"/>
				<hr>
				<a href="#" class="btn btn-google btn-user btn-block">
					<i class="fab fa-google fa-fw"></i>Login with Google
                    </a>
				<a href="#" class="btn btn-facebook btn-user btn-block">
					<i class="fab fa-facebook-f fa-fw"></i>Login with Facebook
                    </a>

			<hr>
			<div class="text-center">
				<a class="small" href="forgot-password.html">Forgot Password?</a>
			</div>
			<div class="text-center">
				<a class="small" href="register.html">Create an Account!</a>
			</div>
		</div>
	</div>
</asp:Content>

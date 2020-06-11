<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="DoAnVegeFoody.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_container" runat="server">
    <div class="col-lg-12">
		<div class="p-5">
			<div class="text-center">
				<h1 class="h4 text-gray-900 mb-2">Forgot Your Password?</h1>
				<p class="mb-4">We get it, stuff happens. Just enter your email address below and we'll send you a link to reset your password!</p>
			</div>
				<div class="form-group">
					<input type="email" class="form-control form-control-user" id="exampleInputEmail" aria-describedby="emailHelp" placeholder="Enter Email Address...">
				</div>
				<a href="login.html" class="btn btn-primary btn-user btn-block">Reset Password
                    </a>
			<hr>
			<div class="text-center">
				<a class="small" href="register.html">Create an Account!</a>
			</div>
			<div class="text-center">
				<a class="small" href="login.html">Already have an account? Login!</a>
			</div>
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>

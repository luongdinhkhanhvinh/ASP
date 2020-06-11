<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="DoAnVegeFoody.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_container" runat="server">
    <div class="col-lg-12">
		<div class="p-5">
			<div class="text-center">
				<h1 class="h4 text-gray-900 mb-4">Create an Account!</h1>
			</div>
			<div class="form-group row">
				<div class="col-lg-4 col-sm-3 mb-3 mb-sm-0">
					<%--<input type="text" class="form-control form-control-user" id="exampleFirstName" placeholder="User Name">--%>
					<asp:TextBox ID="exampleFirstName" CssClass="form-control form-control-user" placeholder="User Name" runat="server"></asp:TextBox>
				</div>
				<div class="col-lg-4 col-sm-3 mb-sm-0">
					<%--<input type="text" class="form-control form-control-user" id="exampleLastName" placeholder="Name">--%>
					<asp:TextBox ID="exampleLastName" CssClass="form-control form-control-user" placeholder="Name" runat="server"></asp:TextBox>
				</div>
				<div class="col-lg-4 col-sm-3 mb-sm-0">
					<%--<input type="email" class="form-control form-control-user" id="exampleInputEmail" placeholder="Email Address">--%>
					<asp:TextBox ID="exampleInputEmail" CssClass="form-control form-control-user" placeholder="Email Address" runat="server"></asp:TextBox>
				</div>
			</div>
			<div class="form-group row">
				<div class="col-lg-4 col-sm-3 mb-3 mb-sm-0">
					<%--<input type="password" class="form-control form-control-user" id="exampleInputPassword" placeholder="Password">--%>
					<asp:TextBox ID="exampleInputPassword" CssClass="form-control form-control-user" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
				</div>
				<div class="col-lg-4 col-sm-3 mb-3 mb-sm-0">
					<%--<input type="password" class="form-control form-control-user" id="exampleRepeatPassword" placeholder="Repeat Password">--%>
					<asp:TextBox ID="exampleRepeatPassword" CssClass="form-control form-control-user" placeholder="Repeat Password" TextMode="Password" runat="server"></asp:TextBox>
				</div>
				<div class="col-lg-4 col-sm-3 mb-3 mb-sm-0">
					<%--<input type="text" class="form-control form-control-user" id="exampleNumber" placeholder="Number">--%>
					<asp:TextBox ID="exampleNumber" CssClass="form-control form-control-user" placeholder="Number" runat="server"></asp:TextBox>
				</div>
			</div>
			<a href="#" class="btn btn-primary btn-user btn-block">Register Account
                </a>
			<hr>
			<a href="#" class="btn btn-google btn-user btn-block">
				<i class="fab fa-google fa-fw"></i>Register with Google
                </a>
			<a href="#" class="btn btn-facebook btn-user btn-block">
				<i class="fab fa-facebook-f fa-fw"></i>Register with Facebook
                </a>
		</div>
		<hr>
		<div class="text-center">
			<a class="small" href="forgot-password.html">Forgot Password?</a>
		</div>
		<div class="text-center">
			<a class="small" href="login.aspx">Already have an account? Login!</a>
		</div>
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="DoAnVegeFoody.Member" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_container" runat="server">
    <div class="row">
        <div class="col-lg-5 d-none d-lg-block bg-register-image"></div>
        <div class="col-lg-12">
            <div class="p-5">
                <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Create an Account</h1>
                </div>
                <div runat="server" id="txtResult"></div>
                <div class="form-group row">
                    <div class="col-lg-4 col-sm-6 mb-3 mb-sm-0">
                        <asp:TextBox ID="exampleUserName" CssClass="form-control form-control-user" placeholder="User Name" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_us" runat="server" ErrorMessage="Tên người dùng không được để trống." ControlToValidate="exampleUserName"></asp:RequiredFieldValidator>
                        <asp:Label ID="txt_username" runat="server" Text=""></asp:Label>
                    </div>
                    <div class=" col-lg-4 col-sm-6">
                        <asp:TextBox ID="exampleName" CssClass="form-control form-control-user" placeholder="Name" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_name" runat="server" ErrorMessage="Tên không được để trống." ControlToValidate="exampleName" ></asp:RequiredFieldValidator>
                    </div>
                    <div class=" col-lg-4 col-sm-6">
                        <asp:TextBox ID="exampleInputEmail" CssClass="form-control form-control-user" placeholder="Email" runat="server" TextMode="Email"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev_exampleInputEmail" runat="server" ErrorMessage="Email không hợp lệ" ValidateRequestMode="Enabled" ControlToValidate="exampleInputEmail" ValidationExpression="\S+@\S+\.\S+"></asp:RegularExpressionValidator>
                    </div>
                </div>

                <div class="form-group row">
                    <div class=" col-lg-4 col-sm-6 mb-3 mb-sm-0">
                        <asp:TextBox ID="exampleInputPassword" CssClass="form-control form-control-user" placeholder="Password" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev_pass" runat="server" ErrorMessage="Mật khẩu từ 6-32 ký tự." ValidationExpression="[a-zA-Z]\w{3,9}" ControlToValidate="exampleInputPassword"></asp:RegularExpressionValidator>
                    </div>
                    <div class=" col-lg-4 col-sm-6">
                        <asp:TextBox ID="exampleRepeatPassword" CssClass="form-control form-control-user" placeholder="Repeat Password" TextMode="Password" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="cv_repass" runat="server" ErrorMessage="Nhập lại mật khẩu không chính xác" ControlToCompare="exampleInputPassword" ControlToValidate="exampleRepeatPassword"></asp:CompareValidator>
                    </div>
                    <div class=" col-lg-4 col-sm-6">
                        <asp:TextBox ID="examplePhone" CssClass="form-control form-control-user" placeholder="Phone"  runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="rev_phone" runat="server" ErrorMessage="Số điện thoại phải đủ 10 số !" 
                         ValidationExpression="\S{10,10}"
                            ControlToValidate="examplePhone"></asp:RegularExpressionValidator>
                    </div>
                </div>
                <div class="form-group row">
                    <div class=" col-lg-4 col-sm-6">
                      <asp:Label ID="Label2" runat="server" Text="Label">Status:</asp:Label>  <asp:DropDownList CssClass="form-control form-control-user" ID="exampleStatus" runat="server">
                          <asp:ListItem Text="Đang hoạt động" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Khóa" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class=" col-lg-4 col-sm-6">
                        
                        <asp:Label ID="Label1" runat="server" Text="Label">Role:</asp:Label>   <asp:DropDownList CssClass="form-control form-control-user" ID="exampleRole"  runat="server">
                          
                          <asp:ListItem Value="1">Admin</asp:ListItem>
                          <asp:ListItem Value="2">Editor</asp:ListItem>
                      
                        </asp:DropDownList>
                        <br />
                    </div>
                </div>
                    <asp:Button ID="register" runat="server" Text="Đăng ký" CssClass="btn btn-primary btn-user btn-block" OnClick="register_Click" />
                <hr>
                <div class="text-center">
                    <a class="small" href="forgot-password.html">Forgot Password?</a>
                </div>
                <div class="text-center">
                    <a class="small" href="login.html">Already have an account? Login!</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>

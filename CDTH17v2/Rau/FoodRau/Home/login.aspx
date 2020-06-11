<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="FoodRau.Home.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">
    <div class="container">
            <div class="row">
                <div class="col-lg-12">
                    <div class="p-5">
                        <div class="text-center">
                            <h1 class="h4 text-gray-900 mb-4">Welcome Back!</h1>
                        </div>
                        <div class="user">
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control form-control-user" ID="txtUserName" runat="server" placeholder="Tên Tài Khoản.."></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Không được bỏ trống" ControlToValidate="txtUserName" ForeColor="red"></asp:RequiredFieldValidator>
                               
                            </div>
                            <div class="form-group">
                                <asp:TextBox TextMode="Password" CssClass="form-control form-control-user" ID="txtPassword" runat="server" placeholder="Mật Khẩu.."></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Không được bỏ trống" ControlToValidate="txtPassword" ForeColor="red"></asp:RequiredFieldValidator>
                            </div>
                            <asp:Button CssClass="btn btn-primary btn-user btn-block" ID="btnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" />
                            <hr />
                            <div class="text-center">
                            <a class="small" href="register.aspx">Create an Account!</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade" id="myModal" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">Thông báo</h4>
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="red"></asp:Label>
                </div>
                <div class="modal-footer">
                  
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_js" runat="server">
</asp:Content>

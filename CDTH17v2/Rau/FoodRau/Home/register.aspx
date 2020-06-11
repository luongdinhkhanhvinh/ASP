<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="FoodRau.Home.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">
    <div class="container">
        <div class="text-center">
            <h1 class="h4 text-gray-900 mb-4">Register Back!</h1>
        </div>
        <div class="user">
            <div class="form-group row">
                <div class="col-sm-6 mb-3 mb-sm-0">
                    <asp:TextBox ID="txtUserName" CssClass="form-control form-control-user" runat="server" placeholder="UserName"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn chưa nhập" ForeColor="Red" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server"  ID="revUserName" ErrorMessage="Không dấu và Phải từ 3 đến 20 kí tự" ValidationExpression="[\w]{3,20}" ControlToValidate="txtUserName" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
               
                </div>
                <div class="col-sm-6">
                 
                     <asp:TextBox ID="txtName" CssClass="form-control form-control-user" runat="server" placeholder="Name"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Bạn chưa nhập" ForeColor="Red" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="form-group">
                 <asp:TextBox ID="txtEmail" CssClass="form-control form-control-user" runat="server" placeholder="Email"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Bạn chưa nhập" ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rev_email" runat="server" ErrorMessage="Sai định dạng" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ForeColor="Red"></asp:RegularExpressionValidator>
            </div>
            <div class="form-group row">
                <div class="col-sm-6 mb-3 mb-sm-0">
                     <asp:TextBox ID="txtPhone" TextMode="Number" CssClass="form-control form-control-user" runat="server" placeholder="Phone"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Bạn chưa nhập" ForeColor="Red" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
                  
                </div>
                <div class="col-sm-6">
                     <asp:TextBox ID="txtAddress" CssClass="form-control form-control-user" runat="server" placeholder="Address"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Bạn chưa nhập" ForeColor="Red" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
               
                </div>
            </div>
            <div class="form-group row">
                <div class="col-sm-6 mb-3 mb-sm-0">
                    <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control form-control-user" runat="server" placeholder="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Bạn chưa nhập" ForeColor="Red" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                </div>
                <div class="col-sm-6">
                     <asp:TextBox ID="txtRepass" TextMode="Password" CssClass="form-control form-control-user" runat="server" placeholder="Re: Password"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Bạn chưa nhập" ForeColor="Red" ControlToValidate="txtRepass"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cvRepass" runat="server" ErrorMessage="Mật Khẩu xác thực không khớp" ControlToCompare="txtPassword" ControlToValidate="txtRepass" Type="String" ForeColor="Red" SetFocusOnError="True"></asp:CompareValidator>
                </div>
            </div>
            <asp:Button ID="btn" CssClass="btn btn-primary btn-user btn-block" runat="server" Text="Register Account" OnClick="btn_Click" />

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
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                        <asp:HiddenField ID="hfUserNameConfirm" runat="server" />
                    </div>
                    <div class="modal-footer">
                       
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_js" runat="server">
</asp:Content>

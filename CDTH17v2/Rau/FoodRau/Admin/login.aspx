<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="FoodRau.Admin.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="<%=Page.ResolveUrl("~") %>Admin/vendor/fontawesome-free/css/all.min.css" rel="stylesheet" type="text/css" />
    <!-- Custom styles for this template-->
    <link href="<%=Page.ResolveUrl("~") %>Admin/css/sb-admin-2.min.css" rel="stylesheet" />
    <link href="<%=Page.ResolveUrl("~") %>Admin/css/custom.css" rel="stylesheet" />
    <!-- Bootstrap core JavaScript-->
    <script src="<%=Page.ResolveUrl("~") %>Admin/vendor/jquery/jquery.min.js"></script>
    <script src="<%=Page.ResolveUrl("~") %>Admin/vendor/bootstrap/js/bootstrap.bundle.min.js"></script>
    <script>
        //modal
        function showModal() {
            $("#myModal").modal('show');
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>

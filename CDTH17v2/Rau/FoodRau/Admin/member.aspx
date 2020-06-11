<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="member.aspx.cs" Inherits="FoodRau.Admin.member" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
    <!-- Custom styles for this page -->
    <link href="<%=Page.ResolveUrl("~") %>Admin/vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">
  <div class="row" id="chon">
        <div class="col-lg-12">
            <div class="user">
                <div class="text-center">
                    <h1>Thành Viên</h1>
                </div>
                <div class="user">
                    <div class="form-group row">
                        <div class="col-sm-4">
                            <asp:TextBox placeholder="Tên Đăng nhập..." ID="txtUserName" runat="server" CssClass="txtUser form-control form-control-user" AutoPostBack="false" ValidationGroup="vsNotification" onfocusout="existUserName();"></asp:TextBox>
                            <asp:HiddenField ID="hfUserName" runat="server"/>
                            <asp:Label ID="lblErrorUserName" CssClass="tbError" runat="server" Text=""></asp:Label>
                            <asp:RequiredFieldValidator ID="rfvUserName" runat="server" ValidationGroup="vsNotification" ErrorMessage="Bạn chưa nhập" ControlToValidate="txtUserName" ForeColor="Red"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator runat="server" ValidationGroup="vsNotification" ID="revUserName" ErrorMessage="Không dấu và Phải từ 3 đến 20 kí tự" ValidationExpression="[\w]{3,20}" ControlToValidate="txtUserName" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        </div>

                        <div class="col-sm-4">
                            <asp:TextBox placeholder="Họ & Tên..." ID="txtName" runat="server" CssClass="form-control form-control-user" AutoPostBack="false" ValidationGroup="vsNotification"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="vsNotification" ID="rfvName" runat="server" ErrorMessage="Bạn chưa nhập" ControlToValidate="txtName" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox AutoPostBack="false" ValidationGroup="vsNotification" placeholder="Email..." ID="txtEmail" runat="server" TextMode="email" CssClass="txtEmail form-control form-control-user" onfocusout="existEmail();"></asp:TextBox>
                            <asp:Label ID="lblErrorEmail" CssClass="tbError" runat="server" Text=""></asp:Label>
                            <asp:RequiredFieldValidator ValidationGroup="vsNotification" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn chưa nhập email" ControlToValidate="txtEmail" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ID="rev_email" runat="server" ErrorMessage="Sai định dạng" ValidationGroup="vsNotification" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ForeColor="Red"></asp:RegularExpressionValidator>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-4 mb-3 mb-sm-0">
                            <asp:TextBox placeholder="Mật Khẩu..." AutoPostBack="false" ValidationGroup="vsNotification" ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ValidationGroup="vsNotification" ID="rvPass" runat="server" ErrorMessage="Bạn chưa nhập mật khẩu" ControlToValidate="txtPassword" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <br />
                            <asp:RegularExpressionValidator ValidationGroup="vsNotification" ID="revPassword" runat="server" ErrorMessage="từ 3 đến 10 kí tự" ControlToValidate="txtPassword" ValidationExpression="[A-Za-z0-9]{3,10}" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        </div>
                        <div class="col-sm-4  mb-3 mb-sm-0">
                            <asp:TextBox placeholder="Nhập Lại Mật Khẩu..." ID="txtRepass" runat="server" TextMode="password" CssClass="form-control form-control-user"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvRepass" runat="server" ErrorMessage="Mật khẩu xác thực không được để trống" ControlToValidate="txtRepass" ValidationGroup="vsNotification" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                            <asp:CompareValidator ValidationGroup="vsNotification" ID="cvRepass" runat="server" ErrorMessage="Mật Khẩu xác thực không khớp" ControlToCompare="txtPassword" ControlToValidate="txtRepass" Type="String" ForeColor="Red" SetFocusOnError="True"></asp:CompareValidator>
                            <br />

                        </div>
                        <div class="col-sm-4  mb-3 mb-sm-0">
                            <asp:TextBox AutoPostBack="false" ValidationGroup="vsNotification" placeholder="Số Điện Thoại..." ID="txtPhone" runat="server" TextMode="Number" CssClass="txtSDT form-control form-control-user" onfocusout="existSDT();"></asp:TextBox>
                            <asp:Label ID="lblErrorSDT" runat="server" Text="" CssClass="tbError"></asp:Label>
                            <asp:RequiredFieldValidator ValidationGroup="vsNotification" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Bạn chưa nhập Số điện thoại" ControlToValidate="txtPhone" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator><br />
                            <asp:RegularExpressionValidator ValidationGroup="vsNotification" ID="revPhone" runat="server" ErrorMessage="Sai định dạng" ControlToValidate="txtPhone" ValidationExpression="0[0-9]{9}" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        </div>

                    </div>
                    <div class="form-group row">
                        <div class="col-sm-4  mb-3 mb-sm-0">
                            <asp:DropDownList AutoPostBack="false" ValidationGroup="vsNotification" ID="ddlRole" runat="server" CssClass="form-control">
                                <asp:ListItem Enabled="true" Value="-1">--Role--</asp:ListItem>
                                <asp:ListItem Value="1">Admin</asp:ListItem>
                                <asp:ListItem Value="0">User</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ForeColor="Red" InitialValue="-1" ID="Req_ID" Display="Dynamic"
                                ValidationGroup="vsNotification" runat="server" ControlToValidate="ddlRole"
                                ErrorMessage="Bạn chưa chọn" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-4  mb-3 mb-sm-0">
                            <asp:DropDownList AutoPostBack="false" ValidationGroup="vsNotification" ID="ddlStatus" runat="server" CssClass="form-control">
                                <asp:ListItem Enabled="true" Value="-1">--Status--</asp:ListItem>
                                <asp:ListItem Value="1">Đang Hoạt Động</asp:ListItem>
                                <asp:ListItem Value="0">Ngưng Hoạt Động</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ForeColor="Red" ID="RequiredFieldValidator2" ValidationGroup="vsNotification" runat="server" ErrorMessage="Bạn chưa chọn" ControlToValidate="ddlStatus" InitialValue="-1" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </div>
                    </div>

                    <div class="form-group row">
                        <div class="col-sm-4  mb-3 mb-sm-0">
                            <i class="fas fa-fw fa-cog"></i>
                            <asp:Button ValidationGroup="vsNotification" ID="btn_register" runat="server" Text="Đăng kí" CssClass="btn btn-primary btn-user btn-block" OnClick="Btn_register_Click" OnClientClick="return Valid();" />
                        </div>
                        <div class="col-sm-4  mb-3 mb-sm-0">
                            <i class="fas fa-fw fa-cog"></i>
                            <asp:Button ValidationGroup="vsNotification" ID="btn_update" runat="server" Text="Cập Nhật" CssClass="btn btn-primary btn-user btn-block" OnClick="Btn_update_Click" />
                        </div>
                        <div class="col-sm-4  mb-3 mb-sm-0">
                            <i class="fas fa-fw fa-cog"></i>
                            <asp:Button ID="btn_cancel" runat="server" Text="Hủy" CssClass="btn btn-primary btn-user btn-block" OnClick="Btn_cancel_Click" />
                        </div>
                        <hr>
                    </div>

                </div>
                <hr>
            </div>
        </div>
    </div>

    <!-- Page Heading -->
    <h1 class="h3 mb-2 text-gray-800">Danh Sách Thành Viên</h1>
    <!-- DataTales Example -->
  <div class="card shadow mb-4">
        <div class="card-header py-3">
            <h6 class="m-0 font-weight-bold text-primary">Danh Sách Thành Viên</h6>
            <div class="form-group col-md-4">
                <input class="txtSearch form-control" onkeydown="if (event.keyCode == 13) return false;" type="text" onfocusout="search(1);" placeholder="Search..." />
            </div>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <table class="table table-bordered" id="dataTable1">
                    <thead>
                        <tr>
                            <th>Tài Khoản</th>
                            <th>Tên</th>
                            <th>Email</th>
                            <th>Phone</th>
                            <th>Quyền Admin</th>
                            <th>Status</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tfoot>
                        <tr>
                            <th>Tài Khoản</th>
                            <th>Tên</th>
                            <th>Email</th>
                            <th>Phone</th>
                            <th>Quyền</th>
                            <th>Status</th>
                            <th></th>
                        </tr>
                    </tfoot>
                    <tbody class="rptDS">
                    </tbody>
                </table>
                <div class="dataTables_paginate paging_simple_numbers">
                    <ul class="record pagination">
                    </ul>
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
                        <asp:Label ID="lblMessage" runat="server" ForeColor="Green" Font-Bold="true"></asp:Label>
                        <asp:HiddenField ID="hfUserNameConfirm" runat="server" />
                    </div>
                    <div class="modal-footer">
                        <div class="btnConfỉrm btn btn-danger" onclick="xacNhanXoa();">
                            Có
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
  
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="js" runat="server">
    <script src="js/ajax/member.js"></script>
</asp:Content>

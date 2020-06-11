<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="customer.aspx.cs" Inherits="FoodRau.Admin.customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">
       <!-- Collapsable Card Example -->
    <div class="card shadow mb-4">
        <!-- Card Header - Accordion -->
        <a href="#collapseCardExample" class="d-block card-header py-3" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample">
            <h6 class="m-0 font-weight-bold text-primary">Viết Bài mới</h6>
        </a>
        <!-- Card Content - Collapse -->
        <div class="collapse show" id="collapseCardExample">
            <div class="form-group row">
                <div class="col-sm-12 mb-12 mb-sm-0">
                    <asp:TextBox ID="txtUserName" Enabled="false" placeholder="Tên tài Khoản..." runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="f_t" ForeColor="Red" ID="rfvName" runat="server" ErrorMessage="Không được bỏ trống" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator runat="server" ValidationGroup="f_t" ID="revUserName" ErrorMessage="Không dấu và Phải từ 3 đến 20 kí tự" ValidationExpression="[\w]{3,20}" ControlToValidate="txtUserName" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:TextBox ID="txtName" placeholder="Tên Khách hàng..." runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="f_t" ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Không được bỏ trống" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                    </div>
                     <div class="form-group">
                        <asp:TextBox ID="txtPhone" placeholder="Số điện Thoại..." runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="f_t" ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Không được bỏ trống" ControlToValidate="txtPhone"></asp:RequiredFieldValidator>
                          <asp:RegularExpressionValidator ValidationGroup="f_t" ID="revPhone" runat="server" ErrorMessage="Sai định dạng" ControlToValidate="txtPhone" ValidationExpression="0[0-9]{9}" ForeColor="Red" SetFocusOnError="True"></asp:RegularExpressionValidator>
                    </div>
                    
                    <div class="form-group">
                        <asp:DropDownList CssClass="form-control form-control-user" ID="ddlStatus" runat="server">
                                <asp:ListItem Value="-1">--Status--</asp:ListItem>
                                <asp:ListItem Value="1">Hoạt động</asp:ListItem>
                                <asp:ListItem Value="0">Không hoạt động</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator InitialValue="-1" ValidationGroup="f_t" ForeColor="Red" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Không được bỏ trống" ControlToValidate="ddlStatus"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="col-md-6">
                   <div class="form-group">
                        <asp:TextBox ID="txtEmail" placeholder="Email..." runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="f_t" ForeColor="Red" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Không được bỏ trống" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                       <asp:RegularExpressionValidator ID="rev_email" runat="server" ErrorMessage="Sai định dạng" ValidationGroup="f_t" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ForeColor="Red"></asp:RegularExpressionValidator>
                    </div>
                    <div class="form-group">
                        <asp:TextBox ID="txtAddress" placeholder="Địa Chỉ..." runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="f_t" ForeColor="Red" ID="RequiredFieldValidator8" runat="server" ErrorMessage="Không được bỏ trống" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
          
           
            <div class="row">
                <div class="col-md-12">
                   <asp:Button ValidationGroup="f_t" ID="btnCapNhat" OnClick="BtnCapNhat_Click" CssClass="btn btn-primary col-md-12" runat="server" Text="Cập Nhật" />
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
                                <asp:Label ID="lblMessage" runat="server"></asp:Label>
                                .Bạn có muốn quay về...
                                <asp:HiddenField ID="hfUserNameConfirm" runat="server" />
                            </div>
                            <div class="modal-footer">
                                <a class="btn btn-primary" href="lst_customer.aspx">Có</a>
                                <a class="btnConfirm btn btn-danger" href='<%if (Request["username"] != null) Response.Write("customer.aspx?username=" + Request["username"]); else Response.Write("lst_customer.aspx"); %>'>Không</a>
                            </div>
                        </div>
                    </div>
                </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="js" runat="server">
</asp:Content>

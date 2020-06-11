<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="food_type.aspx.cs" Inherits="FoodRau.Admin.food_type" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
    <!-- Custom styles for this page -->
    <link href="<%=Page.ResolveUrl("~") %>Admin/vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">
    <!-- Page Heading -->
    <div class="row" id="chon">
        <div class="col-lg-12">
            <div class="text-center">
                <h1 class="h4 text-gray-900 mb-4">Thêm Loại Sản Phẩm</h1>
            </div>
            <div class="user">
                <div class="row">
                    <div class="col-md-6">
                        <div class="form-group row">
                            <div class="col-sm-12">
                                <asp:TextBox ID="txtName" CssClass="txtName form-control form-control-user" runat="server" placeholder="Tên loại" ValidationGroup="vsNotification" onfocusout="existName();"></asp:TextBox>
                                <asp:Label ID="lblErrorName" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hfTypeID" runat="server" />
                                <br />
                                <asp:RequiredFieldValidator ValidationGroup="vsNotification" ControlToValidate="txtName" ID="rfvName" runat="server" ForeColor="Red" ErrorMessage="Bạn chưa nhập"></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator runat="server" ValidationGroup="vsNotification" ID="revUserName" ErrorMessage="Không chưa kí tự đặt biệt và phải 2 đến 20 kí tự" ValidationExpression="[\S\s]{2,50}" ControlToValidate="txtName" ForeColor="Red"></asp:RegularExpressionValidator>
                            </div>

                            <div class="col-sm-12">
                                <asp:TextBox ID="txtPost" TextMode="Number" CssClass="form-control form-control-user" runat="server" placeholder="Vị Trí Trang..." step="1" min="1"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ForeColor="Red" ValidationGroup="vsNotification" ControlToValidate="txtPost" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Bạn chưa nhập "></asp:RequiredFieldValidator>
                                <br />
                                <asp:RegularExpressionValidator ForeColor="Red" runat="server" ValidationGroup="vsNotification" ID="RegularExpressionValidator1" ErrorMessage="từ 1 -> 3 kí tự" ValidationExpression="[0-9]{1,3}" ControlToValidate="txtPost"></asp:RegularExpressionValidator>
                            </div>
              
                            <div class="col-sm-12">
                                <br />
                                <asp:DropDownList ID="ddlStatus" placeholder="Trạng Thái" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="-1">--Trạng Thái--</asp:ListItem>
                                    <asp:ListItem Value="1">Còn Hàng</asp:ListItem>
                                    <asp:ListItem Value="0">Hết Hàng</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ValidationGroup="vsNotification" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn chưa chọn trạng thái" InitialValue="-1" ControlToValidate="ddlStatus" ForeColor="Red"></asp:RequiredFieldValidator>
                                <br />
                            </div>
                        </div>
                    </div>
                    <div class="col-md-6">
                        <div class="form-group">
                             <div class="col-md-6">
                    <table>
                        <tr>
                           <td>
                             
                              <asp:Image ID="imgReview" CssClass="img" runat="server" ImageUrl="../Uploads/Images/10.jpg" Width="300" Height="250" /></td>
                            <asp:HiddenField ClientIDMode="Static" ID="hfImgReview" runat="server" Value="../Uploads/Images/10.jpg" />
                            
                        </tr>
                        <tr>
                            <td>
                                <input id="cmdSelect" class="cmdSelect btn btn-primary " type="button" value="Upload" />
                            </td>
                        </tr>
                    </table>
                </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-4">
                                <asp:Button ID="btnThem" CssClass="btn btn-primary btn-user btn-block" runat="server" Text="Thêm" ValidationGroup="vsNotification" OnClick="BtnThem_Click" OnClientClick="return Valid();" />
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="btnCapNhat" CssClass="btn btn-primary btn-user btn-block" runat="server" Text="Cập Nhật" ValidationGroup="vsNotification" OnClick="Btn_update_Click" />
                            </div>
                            <div class="col-md-4">
                                <asp:Button ID="vsNotification" CssClass="btn btn-primary btn-user btn-block" runat="server" Text="Hủy" OnClick="Btn_cancel_Click" />
                            </div>
                        </div>
                    </div>
                </div>

            </div>

            <hr />
            <!-- Page Heading -->
            <h1 class="h3 mb-2 text-gray-800">Danh Sách Loại Sản Phẩm</h1>
            <!-- DataTales Example -->
            <div class="card shadow mb-4">
                <div class="card-header py-3">
                    <h6 class="m-0 font-weight-bold text-primary">Tìm Kiếm</h6>
                    <div class="form-group col-md-4">
                        <input class="txtSearch form-control" onkeydown="if (event.keyCode == 13) return false;" type="text" onfocusout="search(1);" placeholder="Search..." />
                    </div>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <table class="table table-bordered" id="dataTable1">
                            <thead>
                                <tr>
                                    <th>ID</th>
                                    <th>Tên Loại</th>
                                    <th>Vị Trí Trang</th>
                                    <th>Hình ảnh</th>
                                    <th>Status</th>
                                    <th>Ngày Cập Nhật</th>
                                    <th></th>
                                </tr>
                            </thead>
                            <tfoot>
                                <tr>
                                    <th>ID</th>
                                    <th>Tên Loại</th>
                                    <th>Vị Trí Trang</th>
                                    <th>Hình ảnh</th>
                                    <th>Status</th>
                                    <th>Ngày Cập Nhật</th>
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
                                <asp:Label ID="lblMessage" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label>
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
        </div>

    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="js" runat="server">
    <script src="<%=Page.ResolveUrl("~") %>Admin/js/ajax/food_type.js"></script>
    <script src="<%=Page.ResolveUrl("~") %>ckfinder/ckfinder.js"></script>
    <script>
        var finder = new CKFinder();
        $(".cmdSelect").click(function () {
            finder.selectActionFunction = function (fileUrl) {
                $(".img").attr("src", fileUrl);
                $(<%=hfImgReview.ClientID%>).val(fileUrl);
            };
            finder.popup();
        });
    </script>
</asp:Content>

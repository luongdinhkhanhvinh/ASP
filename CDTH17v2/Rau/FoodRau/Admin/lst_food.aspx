<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="lst_food.aspx.cs" Inherits="FoodRau.Admin.lst_food" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
    <!-- Custom styles for this page -->
    <link href="<%=Page.ResolveUrl("~") %>Admin/vendor/datatables/dataTables.bootstrap4.min.css" rel="stylesheet">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">
    <!-- Page Heading -->
    <div class="row">
        <div class="col-lg-12">
            <hr />
            <div class="col-lg-12">
                <!-- DataTales Example -->
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <h6 class="m-0 font-weight-bold text-primary">Danh Sách</h6>
                        <div class="row">
                            <div class="col-md-3">
                                <a class="form-control" href="<%=Page.ResolveUrl("~") %>Admin/food.aspx">Thêm Sản Phẩm</a>
                            </div>
                        </div>
                    </div>
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
                                        <th>Tên</th>
                                        <th>Mô Tả</th>
                                        <th>Giá</th>
                                        <th>Giá Khuyến Mãi</th>
                                        <th>Hình Thumb </th>
                                        <th>Hình ảnh Sản Phẩm</th>
                                        <th>Đơn Vị Tính</th>
                                        <th>Rating</th>
                                        <th>Đã Bán</th>
                                        <th>Điểm</th>
                                        <th>Thuộc Loại</th>
                                        <th>Trạng Thái</th>
                                        <th>Người Lập</th>
                                        <th>Ngày Cập Nhật</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <th>ID</th>
                                        <th>Tên</th>
                                        <th>Mô Tả</th>
                                        <th>Giá</th>
                                        <th>Giá Khuyến Mãi</th>
                                        <th>Hình Thumb </th>
                                        <th>Hình ảnh Sản Phẩm</th>
                                        <th>Đơn Vị Tính</th>
                                        <th>Rating</th>
                                        <th>Đã Bán</th>
                                        <th>Điểm</th>
                                        <th>Thuộc Loại</th>
                                        <th>Trạng Thái</th>
                                        <th>Người Lập</th>
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
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="js" runat="server">
    <script src="js/ajax/lst_food.js"></script>
</asp:Content>


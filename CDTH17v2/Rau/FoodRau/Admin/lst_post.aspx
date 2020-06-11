<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="lst_post.aspx.cs" Inherits="FoodRau.Admin.lst_post" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">
    <!-- Collapsable Card Example -->
    <div class="card shadow mb-4">
        <!-- Card Header - Accordion -->
        <a href="#collapseCardExample" class="d-block card-header py-3" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample">
            <h6 class="m-0 font-weight-bold text-primary">Danh sách bài viết</h6>
        </a>
        <!-- Card Content - Collapse -->
        <div class="collapse show" id="collapseCardExample">
             <!-- DataTales Example -->
                <div class="card shadow mb-4">
                    <div class="card-header py-3">
                        <div class="row">
                            <div class="col-md-3">
                                <a class="form-control" href="<%=Page.ResolveUrl("~") %>Admin/post.aspx">Viết Bài Mới</a>
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
                                        <th>Tiêu Đề</th>
                                        <th>Mô Tả Ngắn</th>
                                        <th>Chuyên Mục</th>
                                        <th></th>
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <th>ID</th>
                                        <th>Tiêu Đề</th>
                                        <th>Mô Tả Ngắn</th>
                                        <th>Chuyên Mục</th>
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
    <script src="js/ajax/lst_post.js"></script>
</asp:Content>

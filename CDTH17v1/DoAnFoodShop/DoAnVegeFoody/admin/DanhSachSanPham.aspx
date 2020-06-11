<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DanhSachSanPham.aspx.cs" Inherits="DoAnVegeFoody.admin.DanhSachSanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_container" runat="server">
    <div class="container-fluid">
        <div class="form-group form-inline">
            <div class="col-lg-8 col-sm-6 mb-3 mb-sm-0">
                <asp:Label ID="Label1" runat="server" Text="Nhập tên sản phẩm:" ForeColor="Black"></asp:Label>
                <asp:TextBox ID="txtkey" CssClass="form-control" runat="server">           
                </asp:TextBox>
                <asp:Button ID="btnSearch" CssClass="btn btn-outline-success" runat="server" Text="Tìm Kiếm" OnClick="btnSearch_Click" />
            </div>
        </div>
        <!-- Page Heading -->
        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h1 class="m-0 font-weight-bold text-primary">Danh sách thực phẩm</h1>
            </div>
            <div runat="server" id="txtResult"></div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                        <thead>
                            <tr>
                                <th>Tên thực phẩm</th>
                                <th>Giá</th>
                                <th>Giá giảm</th>
                                <th>Ảnh thumb</th>
                                <th>Ảnh</th>
                                <th>Đơn vị</th>
                                <th>Phần trăm giảm giá</th>
                                <th>Loại</th>
                                <th>Trạng thái</th>
                                <th>Người thêm</th>
                                <th>Ngày chỉnh sửa</th>
                                <th>Mô tả</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:Repeater ID="rpt_food" runat="server" OnItemCommand="rpt_food_ItemCommand">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("name") %></td>
                                        <td><%# Eval("price") %></td>
                                        <td><%# Eval("price_promo") %></td>
                                        <td>
                                            <img src='../Admin/img/<%# Eval("thumb") %>' style="width: 50px; height: 50px;" /></td>
                                        <td>
                                            <img src='../Admin/img/<%# Eval("img") %>' style="width: 50px; height: 50px;" /></td>
                                        <td><%# Eval("unit") %></td>
                                        <td><%# Eval("percent_promo") %></td>
                                        <td><%# Eval("type") %></td>
                                        <td><%# Eval("status") %></td>
                                        <td><%# Eval("username") %></td>
                                        <td><%# Eval("modified") %></td>
                                        <td><%# Eval("description") %></td>
                                        <td>
                                            <asp:LinkButton ID="linkbtn_Sua" runat="server" CommandName="sua" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-outline-primary">Sửa</asp:LinkButton>
                                            <asp:LinkButton ID="linkbtn_Xoa" runat="server" CommandName="xoa" CommandArgument='<%# Eval("id")%>' CssClass="btn btn-outline-primary" >Xoá</asp:LinkButton>
                                            <%--data-toggle="modal" data-target="#myModal"--%>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
        <asp:Repeater ID="Repeater2" runat="server">
            <ItemTemplate>
                <a href="?page=<%#Eval("index")%> <%if (Request["key"] != null)
                                                        Response.Write("&key=" + Request["key"]); %>
                          <% if (Request["id"] != null) Response.Write("&id=" + Request["id"]); %>"
                    style="background-color: blue <%# (Eval("active").ToString()=="1"?"blue":"white")%>"><%#Eval("index") %></a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
     <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
</asp:Content>

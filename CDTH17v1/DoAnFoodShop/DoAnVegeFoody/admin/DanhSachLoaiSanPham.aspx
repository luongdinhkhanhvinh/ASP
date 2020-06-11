<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DanhSachLoaiSanPham.aspx.cs" Inherits="DoAnVegeFoody.admin.DanhSachLoaiSanPham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_container" runat="server">
    <div>
        <div class="form-group form-inline">
            <div class="col-lg-8 col-sm-6 mb-3 mb-sm-0">
                <asp:Label ID="Label1" runat="server" Text="Nhập tên sản phẩm:" ForeColor="Black"></asp:Label>
                <asp:TextBox ID="txtkey" CssClass="form-control" runat="server">           
                </asp:TextBox>
                <asp:Button ID="btnSearch" type="button" CssClass="btn btn-outline-success" runat="server" Text="Tìm Kiếm" OnClick="btnSearch_Click" />
            </div>
        </div>
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Danh sách loại sản phẩm</h1>
        <div runat="server" id="txtResult"></div>
        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Danh sách loại sản phẩm</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                        <thead>
                            <tr>
                                <th>Tên loại</th>
                                <th>Hình ảnh</th>
                                <th>Trạng thái</th>
                                <th>Vị trí</th>
                                <th>Người thêm</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>Tên loại</th>
                                <th>Hình ảnh</th>
                                <th>Trạng thái</th>
                                <th>Vị trí</th>
                                <th>Người thêm</th>
                                <th></th>
                            </tr>

                        </tfoot>
                        <tbody>
                            <asp:Repeater ID="Repeater_Foodtype" OnItemCommand="Repeater_Foodtype_ItemCommand" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("type_name") %></td>
                                        <td>
                                            <img src="img/<%#Eval("type_img") %>" style="width: 100px; height: 100px" alt="Không có ảnh" />
                                        </td>
                                        <td><%# Eval("status") %></td>
                                        <td><%# Eval("type_pos") %></td>
                                        <td><%# Eval("username") %></td>
                                        <td>
                                            <asp:LinkButton ID="linkbtn_Sua" runat="server" CommandName="sua" CommandArgument='<%# Eval("type_id") %>'>Sửa</asp:LinkButton>
                                            <asp:LinkButton ID="linkbtn_Xoa" runat="server" CommandName="xoa" CommandArgument='<%# Eval("type_id")%>'>Xoá</asp:LinkButton>
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
    <script type="text/javascript">
        $(document).ready(function()
        {      
            //Sử dụng phương thức Ajax.
            $.ajax({
                type : 'POST', //Sử dụng kiểu gửi dữ liệu POST
                url : 'DanhSachLoaiSanPham.aspx/GETDATA', //gửi dữ liệu sang trang data.php
                data : data, //dữ liệu sẽ được gửi
                success : function(data)  // Hàm thực thi khi nhận dữ liệu được từ server
                { 
                    if(data == 'false') 
                    {
                        alert('Không có người dùng');
                    }else{
                        $('#content').html(data); //dữ liệu HTML trả về sẽ được chèn vào trong thẻ có id content
                    }
                }
            });
            return false;
        });
        });
    </script>
</asp:Content>

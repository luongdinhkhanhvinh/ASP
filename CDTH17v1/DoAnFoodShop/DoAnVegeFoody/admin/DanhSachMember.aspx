<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="DanhSachMember.aspx.cs" Inherits="DoAnVegeFoody.admin.DanhSachMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_container" runat="server">
    <div>
        <div class="form-group form-inline">
            <div class="col-lg-8 col-sm-6 mb-3 mb-sm-0">
                <asp:Label ID="Label1" runat="server" Text="Nhập tên member:" ForeColor="Black"></asp:Label>
                <asp:TextBox ID="txtkey" CssClass="form-control" runat="server">           
                </asp:TextBox>
                <asp:Button ID="btnSearch" CssClass="btn btn-outline-success" runat="server" Text="Tìm Kiếm" OnClick="btnSearch_Click" />
            </div>
        </div>
        <!-- Page Heading -->
        <h1 class="h3 mb-2 text-gray-800">Danh sách thành viên</h1>
        <div  runat="server" id="txtResult"></div>
        <!-- DataTales Example -->
        <div class="card shadow mb-4">
            <div class="card-header py-3">
                <h6 class="m-0 font-weight-bold text-primary">Danh sách thành viên</h6>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <table class="table table-bordered" id="dataTable" width="100%" cellspacing="0">
                        <thead>
                            <tr>
                                <th>Tài khoản</th>
                                <th>Tên thành viên</th>
                                <th>Số điện thoại</th>
                                <th>Email</th>
                                <th>Quyền</th>
                                <th>Trạng thái</th>
                                <th></th>
                            </tr>
                        </thead>
                        <tfoot>
                            <tr>
                                <th>Tài khoản</th>
                                <th>Tên thành viên</th>
                                <th>Số điện thoại</th>
                                <th>Email</th>
                                <th>Quyền</th>
                                <th>Trạng thái</th>
                                <th></th>
                            </tr>

                        </tfoot>
                        <tbody>
                            <asp:Repeater ID="Repeater_Member" OnItemCommand="Repeater_Member_ItemCommand" runat="server">
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("username") %></td>
                                        <td><%# Eval("name") %></td>
                                        <td><%# Eval("phone") %></td>
                                        <td><%# Eval("email") %></td>
                                        <td><%# Eval("role") %></td>
                                        <td><%# Eval("status") %></td>
                                        <td>
                                            <asp:LinkButton ID="linkbtn_Sua" runat="server" CommandName="sua" CommandArgument='<%# Eval("id") %>'>Sửa</asp:LinkButton>
                                            <asp:LinkButton ID="linkbtn_Xoa" runat="server" CommandName="xoa" CommandArgument='<%# Eval("id") %>'>Xoá</asp:LinkButton>
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
</asp:Content>

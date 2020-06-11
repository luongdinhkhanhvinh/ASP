<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FoodRau.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">
     <!-- Collapsable Card Example -->
    <div class="card shadow mb-4">
        <!-- Card Header - Accordion -->
        <a href="#collapseCardExample" class="d-block card-header py-3" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample">
            <h6 class="m-0 font-weight-bold text-primary">Thông báo</h6>
        </a>
        <!-- Card Content - Collapse -->
        <div class="collapse show" id="collapseCardExample">
            <div class="card-body">
                Chào mừng bạn đã vào trang quản trị. <strong>Hãy nhìn sang bên trái</strong> Bạn có thể chọn chức năng bên đó
                 
            </div>
        </div>
    </div>
     <!-- Collapsable Card Example -->
    <div class="card shadow mb-4">
        <!-- Card Header - Accordion -->
        <a href="#collapseCardExample1" class="d-block card-header py-3" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample1">
            <h6 class="m-0 font-weight-bold text-primary">Khác</h6>
        </a>
        <!-- Card Content - Collapse -->
        <div class="collapse show" id="collapseCardExample1">
            <div class="card-body">
                Chào mừng bạn đã vào trang quản trị. Hãy Nhấp vào đây <strong><a href="Home/index.aspx">Home Rau</a></strong> Bạn có thể xem view trang chủ
                 
            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="js" runat="server">
    <asp:DataList ID="DataList1" runat="server" DataSourceID="SqlDataSource1"></asp:DataList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
</asp:Content>

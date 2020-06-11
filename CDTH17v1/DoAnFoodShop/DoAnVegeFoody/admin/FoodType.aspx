<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="FoodType.aspx.cs" Inherits="DoAnVegeFoody.admin.FoodType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_container" runat="server">
    <div class="row">
        <div class="col-lg-5 d-none d-lg-block bg-register-image"></div>
        <div class="col-lg-12">
            <div class="p-5">
                <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Create an Foodtype</h1>
                </div>
                <div runat="server" id="txtResult"></div>
                <div class="form-group row">
                    <div class="col-lg-4 col-sm-6 mb-3 mb-sm-0">
                        <asp:Label ID="Label1" runat="server" Text="Type Name"></asp:Label>
                        <asp:TextBox ID="txt_Type_Name" CssClass="form-control form-control-user" placeholder="Type Name" runat="server"></asp:TextBox>
                    </div>
                    <div class=" col-lg-4 col-sm-6">
                        <asp:Label ID="Label3" runat="server" Text="Pos"></asp:Label>
                        <asp:TextBox ID="txt_Pos" CssClass="form-control form-control-user" placeholder="Pos" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group row">
                    <div class=" col-lg-4 col-sm-6">
                        <asp:Label ID="Label2" runat="server" Text="Label">Status:</asp:Label>
                        <asp:DropDownList CssClass="form-control form-control-user" ID="DdlStatus" runat="server">
                            <asp:ListItem Text="Còn hàng" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Hết hàng" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class=" col-lg-4 col-sm-6">
                        <asp:FileUpload ID="img_Foodtype" runat="server" />
                        <asp:Image ID="img_img" runat="server" Height="60px" Width="60px" Visible="False" />
                        <asp:Button ID="themmoi" runat="server" Text="Thêm mới" CssClass="btn btn-primary btn-user btn-block" OnClick="themmoi_Click" />
                        <hr>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
</asp:Content>

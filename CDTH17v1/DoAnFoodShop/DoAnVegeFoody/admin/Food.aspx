<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Food.aspx.cs" Inherits="DoAnVegeFoody.admin.Food" %>
<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="main_container" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <div class="p-5">
                <div class="text-center">
                    <h1 class="h4 text-gray-900 mb-4">Thêm mới sản phẩm</h1>
                    <div class="form-group row">

                        <div class="col-lg-4 col-sm-6 mb-3 mb-sm-0">
                            <asp:TextBox type="text" CssClass="form-control form-control-user" ID="txtName" placeholder="Name" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ref_name" runat="server" ErrorMessage="Tên sản phẩm không được để trống" ForeColor="Red" ControlToValidate="txtName"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-4 col-sm-6 mb-3 mb-sm-0">
                            <asp:TextBox type="text" CssClass="form-control form-control-user" ID="txtPrice" placeholder="Price" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ref_price" runat="server" ControlToValidate="txtPrice" ErrorMessage="Giá không được để trống" ForeColor="Red"> </asp:RequiredFieldValidator>
                        </div>
                        <div class="col-lg-4 col-sm-6 mb-3 mb-sm-0">
                            <asp:TextBox CssClass="form-control form-control-user" ID="txtPricePromo" placeholder="Price promo" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-lg-4 col-sm-6 mb-3 mb-sm-0">
                            <asp:FileUpload ID="ful_thumb" runat="server" />
                            <asp:Image ID="img_thumb" runat="server" Height="60px" Width="60px" Visible="False" />
                        </div>
                        <div class="col-lg-4 col-sm-6 mb-3 mb-sm-0">
                            <asp:FileUpload ID="ful_img" runat="server" />
                            <asp:Image ID="img_img" runat="server" Height="60px" Width="60px" Visible="False" />
                        </div>
                        <div class="col-lg-4 col-sm-6 mb-3 mb-sm-0">
                            <asp:TextBox type="text" CssClass="form-control form-control-user" ID="txtUnit" placeholder="Unit" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ref_unit" runat="server" ErrorMessage="Đơn vị không được để trống" ForeColor="Red" ControlToValidate="txtUnit"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group row">
                        <div class="col-lg-4 col-sm-6 mb-3 mb-sm-0">
                            <asp:TextBox type="text" CssClass="form-control form-control-user" ID="txtPercentPromo" placeholder="Percent Promo" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-lg-4 col-sm-6 mb-3 mb-sm-0">
                            <asp:DropDownList CssClass="form-control form-control-user" ID="ddType" runat="server" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>

                        <div class="col-lg-4 col-sm-6 mb-3 mb-sm-0">
                            <asp:DropDownList CssClass="form-control form-control-user" ID="ddStatus" runat="server">
                                <asp:ListItem Selected="true" Value="1">Còn hàng</asp:ListItem>
                                <asp:ListItem Value="0">Hết hàng</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                    </div>
                    <div class="form-group row">
                        <div class="col-lg-4 col-sm-6 mb-3 mb-sm-0">
                            <asp:TextBox type="text" CssClass="form-control form-control-user" ID="txtDes" placeholder="Description" runat="server"></asp:TextBox>
                        </div>
                        <asp:LinkButton CssClass="btn btn-primary btn-user btn-block" ID="btn_add" runat="server" OnClick="ThemFood">Thêm thực phẩm</asp:LinkButton>
                        <div runat="server" id="txtResult"  role="alert">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
      <!-- DELETE MODAL -->
    <div id="myModal" class="modal fade" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
            <div class="modal-content">
                <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Thông Báo</h4>
                </div>
                <div class="modal-body">
                   Bạn có muốn xóa  <label class="food-delete" data-name=""></label>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-danger btn_Xoa" >Xoá</button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Đóng</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="script" runat="server">
     <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
</asp:Content>

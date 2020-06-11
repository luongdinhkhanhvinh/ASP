<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="overview.aspx.cs" Inherits="FoodRau.Admin.overview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">
    <!-- Collapsable Card Example -->
    <div class="card shadow mb-4">
        <!-- Card Header - Accordion -->
        <a href="#collapseCardExample" class="d-block card-header py-3" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample">
            <h6 class="m-0 font-weight-bold text-primary">Cài Đặt</h6>
        </a>
        <!-- Card Content - Collapse -->
        <div class="collapse show" id="collapseCardExample">
            <table style="width: 75%">
                <asp:Repeater ID="rptDS" runat="server" OnItemCommand="rptDS_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td class="form-control form-control-user">
                                <asp:Label ID="lblDes" runat="server" Text='<%#Eval("des") %>'></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox TextMode="Number" CssClass="form-control form-control-user" ID="txtRecord" runat="server" step="1" min="1" max="50" Text='<%#Eval("value") %>'></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Không được để trống" ControlToValidate="txtRecord" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Save" CommandArgument='<%#Eval("IdSetting") %>' CommandName="s" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>

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
                    .Bạn có muốn quay về...
                     <asp:HiddenField ID="hfUserNameConfirm" runat="server" />
                </div>
                <div class="modal-footer">
                    <a class="btn btn-primary" href="overview.aspx">Có</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="js" runat="server">
</asp:Content>

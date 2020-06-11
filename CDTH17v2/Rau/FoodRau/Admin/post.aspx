<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="post.aspx.cs" Inherits="FoodRau.Admin.post" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>


<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">

    <!-- Collapsable Card Example -->
    <div class="card shadow mb-4">
        <!-- Card Header - Accordion -->
        <a href="#collapseCardExample" class="d-block card-header py-3" data-toggle="collapse" role="button" aria-expanded="true" aria-controls="collapseCardExample">
            <h6 class="m-0 font-weight-bold text-primary">Viết Bài mới</h6>
        </a>
        <!-- Card Content - Collapse -->
        <div class="collapse show" id="collapseCardExample">
            <div class="form-group row">
                <div class="col-sm-12 mb-12 mb-sm-0">
                    <asp:TextBox ID="txtTile" placeholder="Title Bài viết..." runat="server" CssClass="form-control form-control-user"></asp:TextBox>
                    <asp:RequiredFieldValidator ValidationGroup="f_t" ForeColor="Red" ID="rfvName" runat="server" ErrorMessage="Không được bỏ trống" ControlToValidate="txtTile"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <div class="form-group">
                        <asp:TextBox TextMode="MultiLine" ID="txtShortDes" placeholder="Mô Tả Ngắn..." runat="server" CssClass="form-control form-control-user" Style="resize: none;" Rows="4"></asp:TextBox>
                        <asp:RequiredFieldValidator ValidationGroup="f_t" ForeColor="Red" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Không được bỏ trống" ControlToValidate="txtShortDes"></asp:RequiredFieldValidator>
                    </div>
                    <div class="form-group row">
                        <div class="col-sm-6  mb-6 mb-sm-6">
                            <asp:DropDownList CssClass="form-control form-control-user" ID="ddlStatus" runat="server">
                                <asp:ListItem Value="-1">--Status--</asp:ListItem>
                                <asp:ListItem Value="1">Hoạt động</asp:ListItem>
                                <asp:ListItem Value="0">Không hoạt động</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator InitialValue="-1" ValidationGroup="f_t" ForeColor="Red" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Không được bỏ trống" ControlToValidate="ddlStatus"></asp:RequiredFieldValidator>
                        </div>
                        <div class="col-sm-6  mb-6 mb-sm-6">
                            <asp:DropDownList CssClass="form-control form-control-user" ID="ddlType" runat="server">

                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ValidationGroup="f_t" ForeColor="Red" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Không được bỏ trống" ControlToValidate="ddlType"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="col-md-6">
                    <table>
                        <tr>
                           <td>
                              <asp:Image ID="imgReview" CssClass="img" runat="server" ImageUrl="../Uploads/Images/10.jpg" Width="300" Height="150" /></td>
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
            <p class="font-weight-bold text-primary">Mô Tả bài viết</p>
            <!-- DataTales Example -->
            <div class="card shadow mb-4">
                <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" BasePath="/ckeditor/" Height="400px" ResizeEnabled="False"></CKEditor:CKEditorControl>
               <asp:RequiredFieldValidator ValidationGroup="f_t" ForeColor="Red" ID="RequiredFieldValidator3" runat="server" ErrorMessage="Không được bỏ trống" ControlToValidate="CKEditorControl1"></asp:RequiredFieldValidator>
            </div>
            <div class="row">
                <div class="col-md-12">
                   <asp:Button ValidationGroup="f_t" ID="btnThem" OnClick="BtnThem_Click" CssClass="btn btn-primary col-md-12" runat="server" Text="Thêm" />
                   <asp:Button ValidationGroup="f_t" ID="btnCapNhat" OnClick="BtnCapNhat_Click" CssClass="btn btn-primary col-md-12" runat="server" Text="Cập Nhật" />
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
                                .Bạn có muốn quay về...
                                <asp:HiddenField ID="hfUserNameConfirm" runat="server" />
                            </div>
                            <div class="modal-footer">
                                <a class="btn btn-primary" href="lst_post.aspx">Có</a>
                                <a class="btnConfirm btn btn-danger" href='<%if (Request["post_id"] != null) Response.Write("post.aspx?post_id=" + Request["post_id"]); else Response.Write("lst_post.aspx"); %>'>Không</a>
                            </div>
                        </div>
                    </div>
                </div>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="js" runat="server">
    <script src="js/ajax/post.js"></script>
    <script src="../ckfinder/ckfinder.js"></script>
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

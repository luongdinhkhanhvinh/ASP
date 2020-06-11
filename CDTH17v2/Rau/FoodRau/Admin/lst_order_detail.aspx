<%@ Page Title="" Language="C#" MasterPageFile="~/admin.Master" AutoEventWireup="true" CodeBehind="lst_order_detail.aspx.cs" Inherits="FoodRau.Admin.lst_order_detail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="css" runat="server">
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
                    </div>
                    <div class="card-header py-3">
                  
                        <div class="form-group col-md-4">
                            <input id="hfOrderId" type="hidden" value='<%if (Request["order_id"] != null) Response.Write(Request["order_id"]); %>' />
                            
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <table class="table table-bordered" id="dataTable1">
                                <thead>
                                    <tr>
                                        <th>STT</th>
                                        <th>Food_ID</th>
                                        <th>Số Lượng</th>
                                        <th>Đơn vị</th>
                                        <th>Giá</th>
                                        <th>Tổng giá</th>
                         
                                    </tr>
                                </thead>
                                <tfoot>
                                    <tr>
                                        <th>STT</th>
                                        <th>Food_ID</th>
                                        <th>Số Lượng</th>
                                        <th>Đơn vị</th>
                                        <th>Giá</th>
                                        <th>Tổng giá</th>
                               
                                    </tr>
                                </tfoot>
                                <tbody class="rptDS">
                                </tbody>
                            </table>
                          
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="js" runat="server">
    <script src="js/ajax/lst_order_detail.js"></script>
</asp:Content>

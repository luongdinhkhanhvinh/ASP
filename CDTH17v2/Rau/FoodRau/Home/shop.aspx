<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="shop.aspx.cs" Inherits="FoodRau.Home.shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">
    <div class="hero-wrap hero-bread" style="background-image: url('../Uploads/images/bg_1.jpg');">
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <p class="breadcrumbs"><span class="mr-2"><a href="index.html">Home</a></span> <span>Products</span></p>
                    <h1 class="mb-0 bread">Products</h1>
                </div>
            </div>
        </div>
    </div>

    <section class="ftco-section">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-10 mb-5 text-center">
                    <ul class="product-category">
                        <li><a href='shop.aspx' class='<%if (Request["type_id"] == null) Response.Write("active"); %>'>All</a></li>
                        <asp:Repeater ID="rptLoaiSP" runat="server">
                            <ItemTemplate>
                                <li><a href='?type_id=<%# Eval("Type_Id") %>' 
                                    class='<%#
                                        ((Request["type_id"] != null &&
                                           Convert.ToInt32(Request["type_id"]) ==Convert.ToInt32(Eval("type_id"))) ? "active" : "")
%>'
                                    ><%# Eval("Type_name") %></a></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
            <div class="row">
                <asp:Repeater ID="rptSanPham" runat="server">
                    <ItemTemplate>
                        <div class="col-md-6 col-lg-3 ftco-animate">
                            <div class="product" style="height:400px">
                                <a href="product-single.aspx?id=<%#Eval("Id") %>" class="img-prod">
                                    <img class="img-fluid" src='<%# "../Uploads/images/"+Eval("Thumb") %>' alt="Colorlib Template" style="width:100%;height:250px">
                                    <span class="status"><%# (int)(Convert.ToDecimal(Eval("percent_promo"))*100)+"%" %></span>
                                    <div class="overlay"></div>
                                </a>
                                <div class="text py-3 pb-4 px-3 text-center">
                                    <h3><a href="#"><%# Eval("name") %></a></h3>
                                    <div class="d-flex">
                                        <div class="pricing">
                                            <p class="price"><span class="mr-2 price-dc">$<%# Eval("price") %></span><span class="price-sale">$<%# Eval("price_promo") %></span></p>
                                        </div>
                                    </div>
                                    <div class="bottom-area d-flex px-3">
                                        <div class="m-auto d-flex">
                                            <a href="#" class="add-to-cart d-flex justify-content-center align-items-center text-center">
                                                <span><i class="ion-ios-menu"></i></span>
                                            </a>
                                            <a href="#" class="buy-now d-flex justify-content-center align-items-center mx-1">
                                                <span><i class="ion-ios-cart"></i></span>
                                            </a>
                                            <a href="#" class="heart d-flex justify-content-center align-items-center ">
                                                <span><i class="ion-ios-heart"></i></span>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
            <div class="row mt-5">
                <div class="col text-center">
                    <div class="block-27">
                        <ul>
                            <asp:Repeater ID="rptSoTrang" runat="server">
                                <ItemTemplate>
                                   <li class="<%#((Convert.ToInt32(Eval("active")) == 1) ? "active" : "")  %>"><a href='?page=<%#Eval("index") %>'
                                       >
                                       <%#Eval("index") %>
                                       </a></li> 
                                </ItemTemplate>
                            </asp:Repeater>

                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </section>


</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_js" runat="server"></asp:Content>

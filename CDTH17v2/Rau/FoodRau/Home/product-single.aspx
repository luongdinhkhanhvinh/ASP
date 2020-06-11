<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="product-single.aspx.cs" Inherits="FoodRau.Home.product_single" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">

    <div class="hero-wrap hero-bread" style="background-image: url('../Uploads/images/bg_1.jpg');">
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <p class="breadcrumbs"><span class="mr-2"><a href="index.html">Home</a></span> <span class="mr-2"><a href="index.aspx">Product</a></span> <span>Product Single</span></p>
                    <h1 class="mb-0 bread">Product Single</h1>
                </div>
            </div>
        </div>
    </div>

    <section class="ftco-section">
        <div class="container">
            <div class="row">
                <div class="col-lg-6 mb-5 ftco-animate">

                    <asp:HyperLink ID="hlZoom" runat="server" CssClass="image-popup" NavigateUrl="#">
                        <asp:Image ID="imgReview" runat="server" CssClass="img-fluid" />
                    </asp:HyperLink>


                </div>
                <div class="col-lg-6 product-details pl-md-5 ftco-animate">
                    <h3>
                        <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label></h3>
                    <div class="rating d-flex">
                        <p class="text-left mr-4">
                            <asp:Label ID="lblPoint" runat="server" Text="Label"></asp:Label>
                            <%--<a href="#" class="mr-2">5.0</a>--%>
                            <a href="#"><span class="ion-ios-star-outline"></span></a>
                            <a href="#"><span class="ion-ios-star-outline"></span></a>
                            <a href="#"><span class="ion-ios-star-outline"></span></a>
                            <a href="#"><span class="ion-ios-star-outline"></span></a>
                            <a href="#"><span class="ion-ios-star-outline"></span></a>
                        </p>
                        <p class="text-left mr-4">
                            <a href="#" class="mr-2" style="color: #000;">
                                <asp:Label ID="lblRating" runat="server" Text="Label"></asp:Label>
                                <span style="color: #bbb;">Rating</span></a>
                        </p>
                        <p class="text-left">
                            <a href="#" class="mr-2" style="color: #000;">
                                <asp:Label ID="lblSold" runat="server" Text="Label"></asp:Label>
                                <span style="color: #bbb;">Sold</span></a>
                        </p>
                    </div>

                    <p class="pricing">
                        <del><asp:Label CssClass="mr-2 price-dc" ID="lblPrice" runat="server" Text="Label"></asp:Label>VND</del>
                    </p>
                    <div class="price">
                       <asp:Label ID="lblPrice_promo" runat="server" Text="Label"></asp:Label>VND
                    </div>
                    <p>
                        <asp:Label ID="lblDescription" runat="server" Text="Label"></asp:Label>
                    </p>
                    <div class="row mt-4">
                        <div class="col-md-6">
                            <div class="form-group d-flex">
                                <div class="select-wrap">
                                    <div class="icon"><span class="ion-ios-arrow-down"></span></div>
                                    <asp:DropDownList ID="ddlUnit" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="-1">Select Unit</asp:ListItem>
                                        <asp:ListItem Value="1">KG</asp:ListItem>
                                        <asp:ListItem Value="2">Box</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="w-100"></div>
                        <div class="input-group col-md-6 d-flex mb-3">
                      
                            Quatity:
                            <br />
                            <asp:TextBox CssClass="form-control input-number" name="quantity" ID="quantity" runat="server" TextMode="Number" Text="1" min="1" max="100" placeholder="quatity"></asp:TextBox>
                     
                        </div>
                        <div class="w-100"></div>
                        <div class="col-md-12">
                            <p style="color: #000;">
                                9000
                                <asp:Label ID="lblUnit" runat="server" Text="Label"></asp:Label>
                                available
                            </p>
                        </div>
                    </div>
                    <p>
                        <asp:HiddenField ID="hf_ID" runat="server" />
                        <asp:HiddenField ID="hf_Img" runat="server" />
                        <asp:Button ID="btnAddToCart" CssClass="btn btn-black py-3 px-5" runat="server" Text="Add to Cart" OnClick="BtnAddToCart_Click" />
                      
                    </p>
                </div>
            </div>
        </div>
    </section>

    <section class="ftco-section">
        <div class="container">
            <div class="row justify-content-center mb-3 pb-3">
                <div class="col-md-12 heading-section text-center ftco-animate">
                    <span class="subheading">Products</span>
                    <h2 class="mb-4">Related Products</h2>
                    <p>Far far away, behind the word mountains, far from the countries Vokalia and Consonantia</p>
                </div>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <asp:Repeater ID="rptRelated" runat="server">
                    <ItemTemplate>
                        <div class="col-md-6 col-lg-3 ftco-animate">
                            <div class="product" style="height:400px">
                                <a href="product-single.aspx?id=<%#Eval("Id") %>" class="img-prod">
                                    <img class="img-fluid" src='<%# "../Uploads/images/"+Eval("Thumb") %>' alt="Colorlib Template" style="height:250px;width:100%;">
                                    <span class="status"><%# (int)(Convert.ToDecimal(Eval("percent_promo"))*100)+"%" %></span>
                                    <div class="overlay"></div>
                                </a>
                                <div class="text py-3 pb-4 px-3 text-center">
                                    <h3><a href="#"><%# Eval("name") %></a></h3>

                                    <div class="d-flex">
                                        <div class="pricing">
                                            <p class="price"><span class="mr-2 price-dc"><%# Eval("price") %>VND</span><span class="price-sale"><%# Eval("price_promo") %>VND</span></p>
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
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_js" runat="server">
 
</asp:Content>

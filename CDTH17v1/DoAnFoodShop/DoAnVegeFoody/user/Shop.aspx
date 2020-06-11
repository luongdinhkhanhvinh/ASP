<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="Shop.aspx.cs" Inherits="DoAnVegeFoody.user.Shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="home_section" runat="server">
    <div class="hero-wrap hero-bread" style="background-image: url('images/bg_1.jpg');">
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <p class="breadcrumbs"><span class="mr-2"><a href="index.html">Home</a></span> <span>Products</span></p>
                    <h1 class="mb-0 bread">Products</h1>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ftco_section" runat="server">
    <section class="ftco-section">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-md-10 mb-5 text-center">
                    <ul class="product-category">
                        <li><a href="#" class="active">All</a></li>
                        <li><a href="#">Vegetables</a></li>
                        <li><a href="#">Fruits</a></li>
                        <li><a href="#">Juice</a></li>
                        <li><a href="#">Dried</a></li>
                    </ul>
                </div>
            </div>
            <div class="row">
                <asp:Repeater ID="Repeater_Food" OnItemCommand="Repeater_Food_ItemCommand" runat="server">
                    <ItemTemplate>
                        <div class="col-md-6 col-lg-3 ftco-animate">
                            <div class="product">
                                <a href="#" class="img-prod">
                                    <img class="img-fluid" src="images/<%# Eval("img") %>" alt="Colorlib Template">
                                    <span class="status"><%# Eval("percent_promo") %>%</span>
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
                                            <asp:LinkButton ID="btn_add" CssClass="add-to-cart d-flex justify-content-center align-items-center text-center" CommandName="Add" OnClick="btn_add_Click" CausesValidation="true" runat="server">
                                                <i class="ion-ios-menu"></i>
                                            </asp:LinkButton>
                                            <a href="Cart.aspx" class="buy-now d-flex justify-content-center align-items-center mx-1">
                                                <span><i class="ion-ios-cart"></i></span>
                                            </a>
                                            <a href="#" class="heart d-flex justify-content-center align-items-center ">
                                                <span><i class="ion-ios-heart"></i></span>
                                            </a>
                                        </div>
                                    </div>
                                </div>
                                <asp:HiddenField ID="id" runat="server" Value='<%# Eval("id") %>' />
                                <asp:HiddenField ID="name" runat="server" Value='<%# Eval("name") %>' />
                                <asp:HiddenField ID="description" runat="server" Value='<%# Eval("description") %>' />
                                <asp:HiddenField ID="price" runat="server" Value='<%# Eval("price") %>' />
                                <asp:HiddenField ID="type" runat="server" Value='<%# Eval("type") %>' />
                                <asp:HiddenField ID="unit" runat="server" Value='<%# Eval("unit") %>' />
                                <asp:HiddenField ID="img" runat="server" Value='<%# Eval("img") %>' />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="row mt-5">
                <div class="col text-center">
                    <div class="block-27">
                        <ul>
                            <li><a href="#">&lt;</a></li>
                            <li class="active"><span>1</span></li>
                            <li><a href="#">2</a></li>
                            <li><a href="#">3</a></li>
                            <li><a href="#">4</a></li>
                            <li><a href="#">5</a></li>
                            <li><a href="#">&gt;</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ftco_section_ftco" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ftco_section2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ftco_section_img" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="ftco_section_testimony" runat="server">
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="ftco_section_ftco2" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="ftco_section_ftco_no" runat="server">
    <section class="ftco-section ftco-no-pt ftco-no-pb py-5 bg-light">
        <div class="container py-4">
            <div class="row d-flex justify-content-center py-5">
                <div class="col-md-6">
                    <h2 style="font-size: 22px;" class="mb-0">Subcribe to our Newsletter</h2>
                    <span>Get e-mail updates about our latest shops and special offers</span>
                </div>
                <div class="col-md-6 d-flex align-items-center">
                    <form action="#" class="subscribe-form">
                        <div class="form-group d-flex">
                            <input type="text" class="form-control" placeholder="Enter email address">
                            <input type="submit" value="Subscribe" class="submit px-3">
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

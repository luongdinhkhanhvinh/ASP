<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="FoodRau.Home.cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">

    <div class="hero-wrap hero-bread" style="background-image: url('../Uploads/images/bg_1.jpg');">
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <p class="breadcrumbs"><span class="mr-2"><a href="index.aspx">Home</a></span> <span>Cart</span></p>
                    <h1 class="mb-0 bread">My Cart</h1>
                </div>
            </div>
        </div>
    </div>

    <section class="ftco-section ftco-cart">
        <div class="container">
            <div class="row">
                <div class="col-md-12 ftco-animate">
                    <div class="cart-list">
                        <table class="table">
                            <thead class="thead-primary">
                                <tr class="text-center">
                                    <th>&nbsp;</th>
                                    <th>&nbsp;</th>
                                    <th>Product name</th>
                                    <th>Price</th>
                                    <th>Quantity</th>
                                    <th>Total</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptCart" runat="server">
                                    <ItemTemplate>
                                        <tr class="text-center">
                                            <td class="product-remove">
                                                
                                                <asp:Button ID="btnRemove" CssClass="btn btn-danger" runat="server" Text="Xóa" />
                                              <%--  <a href="#"><span class="ion-ios-close"></span></a>--%>
                                            </td>

                                            <td class="image-prod">
                                                <div class="img" style="background-image: url('../Uploads/images/<%#Eval("Img") %>');"></div>
                                            </td>

                                            <td class="product-name">
                                                <h3><%#Eval("Name") %></h3>
                                                <p><%#Eval("Description") %></p>
                                            </td>

                                            <td class="price"><%#Eval("Price") %>VND</td>

                                            <td class="quantity">
                                                <div class="input-group mb-3">
                                                  
                                                    <input type="number" name="quantity" class="quantity form-control input-number" value="<%# Eval("Quan") %>" min="1" max="100">
                                                </div>
                                            </td>

                                            <td class="total"><%#Eval("Price") %>VND</td>
                                        </tr>
                                        <!-- END TR-->
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <div class="row justify-content-end">
                <div class="col-lg-4 mt-5 cart-wrap ftco-animate">
                  
                </div>
                <div class="col-lg-4 mt-5 cart-wrap ftco-animate">
                    
                </div>
                <div class="col-lg-4 mt-5 cart-wrap ftco-animate">
                    <div class="cart-total mb-3">
                        <h3>Cart Totals</h3>
                        <p class="d-flex">
                            <span>Subtotal</span>
                            <span>$20.60</span>
                        </p>
                        <p class="d-flex">
                            <span>Delivery</span>
                            <span>$0.00</span>
                        </p>
                        <p class="d-flex">
                            <span>Discount</span>
                            <span>$3.00</span>
                        </p>
                        <hr>
                        <p class="d-flex total-price">
                            <span>Total</span>
                            <span>$17.60</span>
                        </p>
                    </div>
                    <p>
                      
                        <asp:Button ID="btnCheckOut" runat="server" CssClass="btn btn-primary py-3 px-4" Text="Proceed to Checkout" OnClick="BtnCheckOut_Click" />
                     </p>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_js" runat="server">
   <%-- <script>
        $(document).ready(function () {

            var quantitiy = 0;
            $('.quantity-right-plus').click(function (e) {

                // Stop acting like a button
                e.preventDefault();
                // Get the field name
                var quantity = parseInt($('#quantity').val());

                // If is not undefined

                $('#quantity').val(quantity + 1);


                // Increment

            });

            $('.quantity-left-minus').click(function (e) {
                // Stop acting like a button
                e.preventDefault();
                // Get the field name
                var quantity = parseInt($('#quantity').val());

                // If is not undefined

                // Increment
                if (quantity > 0) {
                    $('#quantity').val(quantity - 1);
                }
            });

        });
	</script>--%>
</asp:Content>

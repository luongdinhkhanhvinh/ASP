<%@ Page Title="" Language="C#" MasterPageFile="~/home.Master" AutoEventWireup="true" CodeBehind="blog.aspx.cs" Inherits="FoodRau.Home.blog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cph_css" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cph_content" runat="server">
    <div class="hero-wrap hero-bread" style="background-image: url('../Uploads/images/bg_1.jpg');">
        <div class="container">
            <div class="row no-gutters slider-text align-items-center justify-content-center">
                <div class="col-md-9 ftco-animate text-center">
                    <p class="breadcrumbs"><span class="mr-2"><a href="index.aspx">Home</a></span> <span>Blog</span></p>
                    <h1 class="mb-0 bread">Blog</h1>
                </div>
            </div>
        </div>
    </div>

    <section class="ftco-section ftco-degree-bg">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 ftco-animate">
                    <div class="row">
                        <asp:Repeater ID="rptPost" runat="server">
                            <ItemTemplate>
                                <div class="col-md-12 d-flex ftco-animate">
                                    <div class="blog-entry align-self-stretch d-md-flex">
                                        <a href="blog-single.aspx?post_id=<%#Eval("Post_id") %>" class="block-20" style="background-image: url('../Uploads/images/<%#Eval("Img") %>');"></a>
                                        <div class="text d-block pl-md-4">
                                            <div class="meta mb-3">
                                                <div><a href="#"><%#Eval("Created") %> </a></div>
                                                <div><a href="#"><%#Eval("Username") %></a></div>
                                                <div><a href="#" class="meta-chat"><span class="icon-chat"></span>3</a></div>
                                            </div>
                                            <h3 class="heading"><a href="blog-single.aspx?post_id=<%#Eval("Post_id") %>"><%#Eval("Title") %></a></h3>
                                            <p><%#Eval("Short") %></p>
                                            <p><a href="blog-single.aspx?post_id=<%#Eval("Post_id") %>" class="btn btn-primary py-2 px-3">Read more</a></p>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div class="row mt-5">
                            <div class="col text-center">
                                <div class="block-27">
                                    <ul>
                                        <asp:Repeater ID="rptSoTrang" runat="server">
                                            <ItemTemplate>
                                                <li class="<%#((Convert.ToInt32(Eval("active")) == 1) ? "active" : "")  %>"><a href='?page=<%#Eval("index") %><%if (Request["type"] != null) Response.Write("&type="+Request["type"]);   %>'>

                                                    <%#Eval("index") %>
                            
                                                </a></li>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- .col-md-8 -->
                <div class="col-lg-4 sidebar ftco-animate">
                    <div class="sidebar-box">
                        <div class="search-form">
                            <div class="form-group">
                                <span class="icon ion-ios-search"></span>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Search..."></asp:TextBox>
                               <%-- <asp:Button ID="btnSearch" runat="server" CssClass="form-control" placeholder="Search..." OnClick="BtnSearch_Click" />--%>
                               
                            </div>
                        </div>
                    </div>
                    <div class="sidebar-box ftco-animate">
                        <h3 class="heading">Categories</h3>
                        <ul class="categories">
                            <asp:Repeater ID="rptLSP" runat="server">
                                <ItemTemplate>
                                    <li><a href='?type=<%#Eval("Type") %>'><%#Eval("Type_name") %> <span>(<%#Eval("Count") %>)</span></a></li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>

                    <div class="sidebar-box ftco-animate">
                        <h3 class="heading">Recent Blog</h3>
                        <asp:Repeater ID="rptRecentBlog" runat="server">
                            <ItemTemplate>
                                <div class="block-21 mb-4 d-flex">
                            <a class="blog-img mr-4" style="background-image: url('../Uploads/images/<%#Eval("Img") %>');"></a>
                            <div class="text">
                                <h3 class="heading-1"><a href="blog-single.aspx?post_id=<%#Eval("Post_id") %>"><%#Eval("Title") %></a></h3>
                                <div class="meta">
                                    <div><a href="#"><span class="icon-calendar"></span>
                                        <%#Eval("Created") %> </a></div>
                                    <div><a href="#"><span class="icon-person"></span><%#Eval("Username") %></a></div>
                                    <div><a href="#"><span class="icon-chat"></span>19</a></div>
                                </div>
                            </div>
                        </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>

                    <div class="sidebar-box ftco-animate">
                        <h3 class="heading">Tag Cloud</h3>
                        <div class="tagcloud">
                            <a href="#" class="tag-cloud-link">fruits</a>
                            <a href="#" class="tag-cloud-link">tomatoe</a>
                            <a href="#" class="tag-cloud-link">mango</a>
                            <a href="#" class="tag-cloud-link">apple</a>
                            <a href="#" class="tag-cloud-link">carrots</a>
                            <a href="#" class="tag-cloud-link">orange</a>
                            <a href="#" class="tag-cloud-link">pepper</a>
                            <a href="#" class="tag-cloud-link">eggplant</a>
                        </div>
                    </div>

                    <div class="sidebar-box ftco-animate">
                        <h3 class="heading">Mô Tả Post</h3>
                        <p>Comming Soon!</p>
                    </div>
                </div>

            </div>
        </div>
    </section>
    <!-- .section -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cph_js" runat="server">
</asp:Content>

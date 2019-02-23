<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="homeAdmin.aspx.cs" Inherits="BillingSoftware.admin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/login.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-content">
        <div class="section__content section__content--p30">
            <h1 align="center">Products</h1>
            <br />
            <table class="table table-borderless table-striped table-earning">
                <thead>
                    <tr>
                        <th>OrderID</th>
                        <th>Product</th>
                        <th class="text-right">Price</th>                        
                    </tr>
                </thead>
                <tbody data-bind="foreach: productList">
                    <tr>
                        <td data-bind="text: orderId">100398</td>
                        <td data-bind="text: product">iPhone X 64Gb Grey</td>
                        <td class="text-right"><span>₹</span><span data-bind="text: price"></span></td>
                    </tr>
                </tbody>
            </table>
            </div>
        </div>

</asp:Content>

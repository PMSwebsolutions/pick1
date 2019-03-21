<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="homeAdmin.aspx.cs" Inherits="BillingSoftware.admin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/login.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-content">
        <form method="post">
                            <div class="form-group">
                                <label for="cc-payment" class="control-label mb-1" style="margin-left:25%;"  >Search</label>
                                <input type="text"  data-bind="textInput: search" style="margin:auto;width:50%;" class="form-control" aria-required="true" aria-invalid="false" placeholder="Search here">
                            </div>
            </form>
        <div class="section__content section__content--p30">
            <div class="section__content section__content--p30">
                <h1 align="center">Products</h1>
                <br />
                <table class="table table-borderless table-striped table-earning">
                    <thead>
                        <tr>
                            <th>OrderID</th>
                            <th>Product</th>
                            <th class="text-right">Price</th>
                            <th class="text-right">Delete</th>
                        </tr>
                    </thead>
                    <tbody data-bind="foreach: productList">
                        <tr>
                            <td data-bind="text: orderId">100398</td>
                            <td data-bind="text: product">iPhone X 64Gb Grey</td>
                            <td class="text-right"><span>₹</span><span data-bind="text: price"></span></td>
                            <td class="text-right" data-bind="click: cdelete"><i class="fas fa-trash-alt"></i></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

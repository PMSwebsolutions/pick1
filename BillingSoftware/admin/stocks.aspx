<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="stocks.aspx.cs" Inherits="BillingSoftware.admin.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/stockView.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="main-content" style="overflow:scroll;">
              <form method="post">
                            <div class="form-group">
                                <label for="cc-payment" class="control-label mb-1" style="margin-left:25%;"  >Search</label>
                                <input type="text" data-bind="textInput: search" style="margin:auto;width:50%;" class="form-control" aria-required="true" aria-invalid="false" placeholder="Search here">
                            </div>

              </form>
        <div class="section__content section__content--p30">
            <div class="section__content section__content--p30">
                <h1 align="center">Stocks</h1>
                <br />
                <table class="table table-borderless table-striped table-earning">
                    <thead>
                        <tr>
                            <th>OrderID</th>
                            <th>Product Name</th>
                            <th class="text-center">Quantity</th>
                            <th class="text-center">Description</th>
                            <th class="text-right">Price</th>
                            <th class="text-right">Delete</th>
                        </tr>
                    </thead>
                    <tbody data-bind="foreach: productList">
                        <tr>
                            <td data-bind="text: orderId">100398</td>
                            <td data-bind="text: product">iPhone X 64Gb Grey</td>
                            <td data-bind="text: quantity">12</td>
                            <td data-bind="text: description">This is an IPHONE dsfsdhf abd blah blah and blah blah blabh</td>
                            <td class="text-right"><span>₹</span><span data-bind="text: price">1234</span></td>
                            <td class="text-right" data-bind="click: cdelete"><i class="fas fa-trash-alt"></i></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</asp:Content>

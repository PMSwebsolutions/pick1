<%@ Page Title="" Language="C#" MasterPageFile="~/admin/admin.Master" AutoEventWireup="true" CodeBehind="homeAdmin.aspx.cs" Inherits="BillingSoftware.admin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/login.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-content">
        <div class="section__content section__content--p30">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-6">
                        <h1>Add Product</h1>
                        <br />
                        <form method="post">
                            <div class="form-group">
                                <label for="cc-payment" class="control-label mb-1">Product Name</label>
                                <input type="text" data-bind="textInput: addProductName" class="form-control" aria-required="true" aria-invalid="false" placeholder="Enter Product Name">
                            </div>
                            <div class="form-group has-success">
                                <label for="cc-name" class="control-label mb-1">Cost</label>
                                <input type="text" class="form-control cc-name valid" aria-required="true" aria-invalid="false" aria-describedby="cc-name-error" placeholder="Enter the cost" data-bind="textInput: addProductCost">
                                <span class="help-block field-validation-valid" data-valmsg-for="cc-name" data-valmsg-replace="true"></span>
                            </div>
                            
                            <div>
                                <button data-bind="click: addProduct" class="btn btn-lg btn-info btn-block">
                                    <i class="fa fa-plus fa-lg"></i>&nbsp;
                                                    <span id="payment-button-amount">Add Product</span>
                                    <span id="payment-button-sending" style="display: none;">Sending…</span>
                                </button>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
            <br /> <br />
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
                            <td class="text-right" data-bind="click: cdelete"><i class="fas fa-trash-alt" ></i></td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        </div>
</asp:Content>

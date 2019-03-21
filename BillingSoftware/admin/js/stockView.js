var mainVM;
$(document).ready(function () {
    mainVM = new StockViewModel();
    ko.applyBindings(mainVM);
});

function StockListViewModel(CP) {
    self.orderId = ko.observable('1234');
    self.product = ko.observable();
    self.quantity = ko.observable();
    self.description = ko.observable();
    self.price = ko.observable();
    this.id = ko.observable();
    if (CP) {
        self.product(CP.data.product);
        self.orderId(CP.data.id);
        self.price(CP.data.price);
        self.quantity(CP.data.quantity);
        self.description(CP.data.description);
        this.id(CP.data.id);
    };
    self.cdelete = function () {
        $.ajax({
            type: "POST",
            url: "addStock.aspx/deleteStock",
            data: "{'id':'" + this.id() + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
                location.reload();
            },
            error: function () {
                alert("Error")
            }
        });
    };

    /*  self.cedit = function () {
          window.location = "modifyName.aspx?id=" + this.id();
      };*/
}


function StockViewModel() {

    var self = this;
    self.productList = ko.observableArray([]);
    self.search = ko.observable();
    self.addStockProduct = ko.observable();
    self.addStockPrice = ko.observable();
    self.addStockId = ko.observable();
    self.addStockQuantity = ko.observable();
    self.addStockDescription = ko.observable();
    viewFun();
    self.addStockBtn = function () {
        $.ajax({
            type: "POST",
            url: "addStock.aspx/addStocks",
            data: "{'product':'" + self.addStockProduct() + "','description': '" + self.addStockDescription() + "','price': '" + self.addStockPrice() + "', 'quantity': '" + self.addStockQuantity() + "','id': '" + self.addStockId() + "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (datas) {
                if (datas.d == "success") {
                    location.replace("stocks.aspx");
                } else {
                    alert("Not updated");
                }
            },
            error: function () {
                alert("Error")
            }
        });
    }

    //viewFun();
    function viewFun() {    
        $.ajax({
            type: "POST",
            url: "stocks.aspx/getStocks",
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (datas) {
                for (var i = 0; i < datas.d.length; i++) {
                    self.productList.push(new StockListViewModel({ data: datas.d[i] }));
                };
            },
            error: function () {
                alert("Error")
            }
        });
    }
};

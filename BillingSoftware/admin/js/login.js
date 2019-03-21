var mainVM;
$(document).ready(function () {
    mainVM = new loginViewModel();
    ko.applyBindings(mainVM);
});

function NameListViewModel(CP) {
    self.orderId = ko.observable();
    self.product = ko.observable();
    self.price = ko.observable();
    self.search = ko.observable();
    this.id = ko.observable();
    if (CP) {
        self.product(CP.data.item);
        self.orderId(CP.data.id);
        self.price(CP.data.cost);
        this.id(CP.data.id);
    };
    self.cdelete = function () {
        $.ajax({
            type: "POST",
            url: "homeAdmin.aspx/deleteName",
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


function loginViewModel() {
    var self = this;
    self.productList = ko.observableArray([]);
    self.addProductName = ko.observable();
    self.addProductCost = ko.observable();
    self.search = ko.observable();
    viewFun();
    self.addProduct = function () {
        
        $.ajax({
            type: "POST",
            url: "homeAdmin.aspx/addProducts",
            data: "{'item':'" + self.addProductName() + "','cost': '" + self.addProductCost() +  "'}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (datas) {
                if (datas.d == "success") {
                    location.replace("homeAdmin.aspx");
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
            url: "homeAdmin.aspx/getProducts",
            data: "{}",
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (datas) {
                for (var i = 0; i < datas.d.length; i++) {
                    self.productList.push(new NameListViewModel({ data: datas.d[i] }));
                };
            },
            error: function () {
                alert("Error")
            }
        });
    }
};

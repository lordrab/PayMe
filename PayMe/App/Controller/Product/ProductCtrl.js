PayMe.controller("productCtrl", ['$scope', '$http', 'httpService', function (scope, http, HttpService) {

    scope.productList = [];
    scope.orderId = 0;
    scope.shoppingCart = [];

    var getModel = {
        url: '/Product/GetProductList',
        getFunction: function (data) {
            //console.log(data)
            scope.productList = data.data.ProductData;
            console.log(scope.productList)
        }
    }
    HttpService.getData(getModel, scope);

    
   
    scope.addOrderItem = function (itemId,index) {
        console.log(index)
        hashData = location.hash.split('='); 
        orderId = 0;
        if (hashData.length > 0) {
            orderId = hashData[1];
        } 
        
        console.log(orderId)
        var postModel = {
            url: '/Product/AddOrderItem',
            data: { OrderId: orderId, OrderItemId: itemId },
            getFunction: function (data) {
                console.log(data)
                if (data.data.Success) {
                    if (location.hash == "") {
                        location.hash = "orderId=" + data.data.OrderId;
                    }                    
                    scope.shoppingCart.push({ Id: data.data.Id, Price: data.data.Price, Qty: data.data.Qty, Description: scope.productList[index].Description });
                    console.log(scope.shoppingCart)
                }               
            }
        }
        console.log("here")
        HttpService.postData(postModel, scope);
    }

}]);
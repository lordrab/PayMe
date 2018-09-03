PayMe.controller("homeCtrl", ['$scope', '$http', 'httpService', function (scope, http, HttpService) {

    console.log("test")
    var getModel = {
        url: '/Product/GetProductList',
        getFunction: function (data) {
            console.log(data)
        }
    }
    HttpService.getData(getModel);
    
}]);
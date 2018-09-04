
PayMe.controller("navCtrl", ['$scope', function (scope) {

    scope.currentUrl = '';
    
    scope.menuLink = function (link) {
        scope.currentUrl = link;
        var hashData = location.hash;
        
        window.location.href = link + hashData;
    }
}]);
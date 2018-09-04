

PayMe.directive("subHeading", function () {
    return {
        scope: {
            heading: '@'
        },
        template: `<div class="dir-subheading">{{heading}}</div>`,
        controller: function subHeadingController($scope) {
            
        }
    }

})

PayMe.directive("shoppingCarAdd", function () {
    return {
        scope: {
            elementId: '@'
        },
        template: `<button id={{orderId}} class="btn shared-button glyphicon glyphicon-shopping-cart" data-toggle="popover" data-content='Qty
                    <input type="number"maxlength="3" value="1" class="shared-qtyinputbox"/>                    
                    <button class="btn shared-button-green glyphicon glyphicon-ok-circle"></button>
                    <button class="btn shared-button-red glyphicon glyphicon-remove-circle"></button>' ng-click="addItem(elementId)"> Add
                    </button>`,
        controller: function shoppingCtrl($scope, httpService) {

            $scope.addState = false;

            $(document).ready(function () {
                $('[data-toggle="popover"]').popover({ html: true }); 
            })
            $scope.addItem = function (index) {
                if ($scope.addState == false) {
                    console.log(index)
                    $scope.addState = true;
                }
                
                
            }
        }
    }
})
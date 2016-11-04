// create the controller and inject Angular's $scope
app.controller('dashCtrl', function ($scope, $interval, $http, btapi) {

    var getOrdersSuccess = function (response) {
        $scope.recentOrders = response.data;
    }

    btapi.orders.getOrdersByCode($scope.clientCode, getOrdersSuccess);

});
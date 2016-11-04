// create the controller and inject Angular's $scope
app.controller('mainController', function ($scope, $interval, $http, $location, btapi) {

    //$scope.clientCode = "";

    //$scope.init = function (clientCode) {
    //    $scope.clientCode = clientCode;
    //}

    $scope.pagename = "Main";
    //$scope.currentTime = Date();
    //$interval(function () { $scope.currentTime = Date() }, 1000);
    console.log($scope.clientCode);
   var getOrdersSuccess = function (response) {
        $scope.recentOrders = response.data;
    }

   btapi.orders.getOrdersByCode($scope.clientCode, getOrdersSuccess);

});

app.controller('createOrderController', function ($scope, $interval, $http, $routeParams) {

    console.log($scope.clientCode);

    $scope.filterName = $routeParams.category

    $scope.go = function (hash) {
        $location.path(hash);
    };

    $scope.order = {};
    
});


app.controller('configureOrderController', function ($scope, $interval, $http) {

});
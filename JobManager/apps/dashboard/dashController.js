// create the controller and inject Angular's $scope
app.controller('mainController', function ($scope, $interval, $http, sessionVariables, NgTableParams) {

    $scope.pagename = "Dashboard";
    $scope.currentClientShortCode = sessionVariables.current.clientShortCode;

    var ordersList;

    $http({
        method: 'GET',
        url: '/Umbraco/Api/OrdersApi/GetRecentOrders/'
    }).success(function (data) {
        $scope.ordersList = data;
        $scope.ordersTableParams = new NgTableParams({}, { dataset: $scope.ordersList });
    });

    

});
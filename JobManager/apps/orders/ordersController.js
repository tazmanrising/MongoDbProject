// create the controller and inject Angular's $scope
app.controller('mainController', function ($scope, $interval, $http, sessionVariables) {

    $scope.pagename = "Orders";
    $scope.currentClientShortCode = sessionVariables.current.clientShortCode;

    $scope.formData = {};
    $scope.formData.GenerateOrderId = true;
    $scope.formData.OrderId = "REALEX-123";
    $scope.formData.Title = "Online Order - 2 Items";
    $scope.formData.Status = "Submitted";

    var shortCode = sessionStorage.getItem('clientShortCode');
    
    $http({
        method: 'GET',
        url: '/Umbraco/Api/OrdersApi/GetOrders/' + shortCode
    }).success(function (data) {
        $scope.ordersList = data;
    });

});

app.controller('createOrderController', function ($scope, $interval, $http, $httpParamSerializer) {

    //$scope.currentTime = Date();
    //$interval(function () { $scope.currentTime = Date() }, 1000);
    $scope.formData = {};
    $scope.formData.GenerateOrderId = true;
    $scope.formData.Title = "None";
    $scope.formData.Status = "None";

    $scope.sayHello = function () {
        alert("hello!");
    };

    $scope.createOrder = function () {
        $http({
            method: 'POST',
            url: '/Umbraco/Api/OrdersApi/CreateFromAdmin',
            data: $httpParamSerializer($scope.formData),
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).success(function (data) {
            $scope.result = data;
        });
    };

    $scope.createOrderJSON = function () {
        $scope.formData.ClientId = sessionStorage.getItem('clientId');;
        $scope.formData.ClientName = sessionStorage.getItem('clientName');
        $scope.formData.ClientShortCode = sessionStorage.getItem('clientShortCode');

        $http({
            method: 'POST',
            url: '/Umbraco/Api/OrdersApi/CreateFromAdmin',
            data: $scope.formData
        }).success(function (data) {
            $scope.result = data;
        });
    };
});


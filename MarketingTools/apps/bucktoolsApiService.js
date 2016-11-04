app.service('btapi', function ($http) {
    
    var btApiUrl = "http://10.172.100.128/Umbraco/Api";

    this.orders = {
        test: function () {
            return internal;
        },

        getOrdersByCode: function (clientCode, successHandler, errorHandler) {
            $http({
                method: 'GET',
                url: btApiUrl + '/OrdersApi/GetOrders/' + clientCode
            }).then(successHandler, errorHandler);
        },

        getOrderById: null,


    }

});
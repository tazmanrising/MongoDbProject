app.service('orders', function ($http) {

    var btApiUrl = "http://localhost:49810/Umbraco/Api";
    var apiRoot = "/OrdersApi";

    this.currentOrder = {};

    this.orders = {
        test: function () {
            return internal;
        },

        getOrdersByCode: function (clientCode, successHandler, errorHandler) {
            $http({
                method: 'GET',
                url: btApiUrl + apiRoot + '/GetOrders/' + clientCode
            }).then(successHandler, errorHandler);
        },

        getOrderById: null,
    }
});

app.service('catalog', function ($http) {

    var btApiUrl = "/Umbraco/Api";
    var apiRoot = "/CatalogApi";

    this.currentOrder = {};

    this.catalog = {
        test: function () {
            return internal;
        },

        getCategories: function (nodeId, successHandler, errorHandler) {
            $http({
                method: 'GET',
                url: btApiUrl + apiRoot + '/GetCategories/' + nodeId
            }).then(successHandler, errorHandler);
        },

        getCatalogItem: function (nodeId, successHandler, errorHandler) {
            $http({
                method: 'GET',
                url: btApiUrl + apiRoot + '/GetCatalogItem/' + nodeId
            }).then(successHandler, errorHandler);
        }
    };
});
app.controller('catalogCtrl', function ($scope, $interval, $http, catalog) {
    console.log($scope.currentNodeId);

    var getCategories = function (response) {
        $scope.categories = response.data;
        console.log($scope.categories);
    }

    catalog.catalog.getCategories($scope.currentNodeId, getCategories);
});

// catalogItemCtrl
app.controller('catalogItemCtrl', function ($scope, $interval, $http) {

    $scope.pageTitle = "Catalog Item Detail";

    $scope.init = function ()
    { };

});
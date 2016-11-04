// create the controller and inject Angular's $scope
app.controller('projectsCtrl', function ($scope, $interval, $http, $location, $uibModal, btapi) {

    $scope.pagename = "Main";
    //$scope.currentTime = Date();
    //$interval(function () { $scope.currentTime = Date() }, 1000);

   var getOrdersSuccess = function (response) {
        $scope.recentOrders = response.data;
    }

    btapi.orders.getOrdersByCode($scope.clientCode, getOrdersSuccess);

    $scope.open = function (size) {
        var modalInstance = $uibModal.open({
            animation: true,
            ariaLabelledBy: 'modal-title',
            ariaDescribedBy: 'modal-body',
            templateUrl: '/apps/_templates/modals/sampleModal.html',
            controller: 'ModalInstanceCtrl',
            size: size
        });
    };

    // gallery images
    $scope.images = [
        {
            url: '/images/samples/ath/framingcommercial_914.jpg'
        },
        {
            url: '/images/samples/ath/l.jpg'
        },
        {
            url: '/images/samples/ath/New-Home-Construction-Steps3.jpg'
        },
        {
            url: '/images/samples/ath/Platform-frame.jpg'
        },
        {
            url: '/images/samples/ath/new-home-foundation-14090187.jpg'
        },
        {
            url: '/images/samples/ath/16724.jpg'
        },
        {
            url: '/images/samples/ath/custom-home-builder2.jpg'
        }
    ];

    // gallery methods
    $scope.methods = {};

    // so you will bind openGallery method to a button on page
    // to open this gallery like ng-click="openGallery();"
    $scope.openGallery = function () {
        $scope.methods.open();

        // You can also open gallery model with visible image index
        // Image at that index will be shown when gallery modal opens
        //scope.methods.open(index); 
    };

    // Similar to above function
    $scope.closeGallery = function () {
        $scope.methods.close();
    };

    $scope.nextImg = function () {
        $scope.methods.next();
    };

    $scope.prevImg = function () {
        $scope.methods.prev();
    };

});

app.controller('ModalInstanceCtrl', function ($scope, $uibModalInstance) {

    $scope.ok = function () {
        $uibModalInstance.close($ctrl.selected.item);
    };

    $scope.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});

app.controller('createOrderController', function ($scope, $interval, $http, $routeParams) {

    $scope.filterName = $routeParams.category

    $scope.go = function (hash) {
        $location.path(hash);
    };

    $scope.order = {};
    
});


app.controller('configureOrderController', function ($scope, $interval, $http) {

});
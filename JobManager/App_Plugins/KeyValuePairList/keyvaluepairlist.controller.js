angular.module("umbraco").controller("KeyValuePairList.KeyValuePairListController", function ($scope) {

    $scope.form = {};
    $scope.kvplist = null;
    //$scope.model.value = [];

    if ($scope.model.value == "")
    {
        $scope.model.value = [];
    }

    if ($scope.model.value instanceof Array && $scope.model.value.length > 0) $scope.kvplist = $scope.model.value[0];

    $scope.addpair = function (newItem) {
        $scope.model.value.push(newItem);
        $scope.kvplist = $scope.model.value[$scope.model.value.indexOf(newItem)]
        $scope.form = {};
    }

    //$scope.removepair = function (item) {
    //    alert("clicked");
    //    $scope.tableValue = "3" + item;
    //    var i = $scope.model.value.indexOf(item);
    //    if (i != -1) {
    //        $scope.model.value.splice(i, 1);
    //        if ($scope.model.value.length > 0) $scope.kvplist = $scope.model.value[0];
    //    }
    //}

    $scope.model.remove = function (index) {
        //alert("clicked " + index);
        //$scope.tableValue = index;
        if (index != -1) {
            $scope.model.value.splice(index, 1);
        }
    }
});
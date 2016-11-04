
// create the controller and inject Angular's $scope
app.controller('mainController', function ($scope, $interval, $http, $window, sessionVariables) {

    //$scope.currentTime = Date();
    //$interval(function () { $scope.currentTime = Date() }, 1000);

    $scope.currentClientShortCode = sessionVariables.current.clientShortCode;
    $scope.currentClientId = sessionVariables.current.clientId;
    $scope.currentClientName = sessionVariables.current.clientName;


      $http.get('/Umbraco/Api/ClientsApi/GetAllActiveClients').
      success(function (data, status, headers, config) {
          $scope.clientList = data;
      }).
      error(function (data, status, headers, config) {
          // log error
      });

      $scope.selectClient = function (clientId) {
          //alert(sessionVariables.current.clientId);
          sessionVariables.current.clientId = clientId;

          $http.put('/Umbraco/Api/ClientsApi/SelectClient/' + clientId)
              .success(function (data, status, headers) {
                  sessionVariables.current.clientId = data.Id;
                  sessionVariables.current.clientName = data.ClientName;
                  sessionVariables.current.clientShortCode = data.ClientCode;

                  $window.location.reload();
              });
          
      };

});

app.controller('detailController', function ($scope, $interval, $http, $routeParams, $window, sessionVariables, $httpParamSerializer, activityApi) {

    var clientId = $routeParams.id;
    //console.log(clientId);

  
    $http.get('/Umbraco/Api/ClientsApi/GetClient/' + clientId).
    success(function (data, status, headers, config) {
        console.log(data);
        
        $scope.client = data;
        $scope.getActivity(data);

    }).
    error(function (data, status, headers, config) {
        // log error
    });

    $scope.getActivity = function(data) {
        
        //GetActivityByClientShortCode  //getActivityById
        var getActivityByShortCode = activityApi.getActivityByShortCode(data.ClientCode);
        getActivityByShortCode.success(function (data) {
            $scope.activity = data;
            console.log(data);
        });
        
    };

 
    $scope.updateClient = function() {
        $http({
            method: 'POST',
            url: '/Umbraco/Api/ClientsApi/UpdateClient',
            data: $httpParamSerializer($scope.client),
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).success(function (data) {
            console.log(data);
            $scope.result = data;
        });
    };



    $scope.selectClient = function (clientId) {
        //alert(sessionVariables.current.clientId);
        sessionVariables.current.clientId = clientId;

        $http.put('/Umbraco/Api/ClientsApi/SelectClient/' + clientId)
            .success(function (data, status, headers) {
                sessionVariables.current.clientId = data.Id;
                sessionVariables.current.clientName = data.ClientName;
                sessionVariables.current.clientShortCode = data.ClientCode;

                $window.location.reload();
            });

    };
});

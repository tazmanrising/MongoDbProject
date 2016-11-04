app
  .service("activityApi", function ($http) {

        this.myFunc = function (x) {
          return x.toString(16);
        }

        this.GetActivityByOrderNumbers = function (memberId) {
            return $http({
                url: '/Umbraco/Api/ActivityApi/GetActivityByOrderNumbers/' + memberId,
                method: "GET"
            });
        };

        this.getActivity = function () {
            return $http({
                url: '/Umbraco/Api/ActivityApi/GetActivity',
                method: "GET"
            });
        };
        
        this.createActivity = function (activity) {
            return $http({
                url: '/Umbraco/Api/ActivityApi/CreateActivity/' + activity,
                method: "POST"
            });
        };

        this.updateActivity = function (activity) {
            return $http({
                url: '/Umbraco/Api/ActivityApi/UpdateActivity/' + activity,
                method: "POST"
            });
        };

        this.deleteActivity = function (id) {
            return $http({
                url: '/Umbraco/Api/ActivityApi/DeleteActivity/' + id,
                method: "POST"
            });
        };

        this.getActivityByShortCode = function(code) {
            return $http({
                url: '/Umbraco/Api/ActivityApi/GetActivityByClientShortCode/' + code,
                method: "GET"
            });
        };

        this.getActivityById = function(id) {


            return $http({
                url: '/Umbraco/Api/ActivityApi/GetActivityByMemberId/'+id,
                method: "GET"

            });




            //$http.get('/Umbraco/Api/ActivityApi/GetActivity').then(function(response) {
            //    console.log(response.data);
            //    return "44";
            //}).catch(function(error) {
            //  //log error
            //});


            //return "33";


        };


    });
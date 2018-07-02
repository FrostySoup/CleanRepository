app.controller('csvImportController', function ($scope, $http) {

  var formdata = new FormData();
  $scope.getTheFiles = function ($files) {
    angular.forEach($files, function (value, key) {
      formdata.append(key, value);
    });
  };
  
  $scope.uploadFiles = function () {

    var request = {
      method: 'POST',
      url: '/api/fileupload/',
      data: formdata,
      headers: {
        'Content-Type': undefined
      }
    };
    
    $http(request)
      .success(function (d) {
        alert(d);
      })
      .error(function () {
      });
  }
});
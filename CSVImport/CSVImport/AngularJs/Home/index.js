(function () {
  //Module 
  var app = angular.module('CSVImport', ['angularUtils.directives.dirPagination'])
    .directive('ngFiles', ['$parse', function ($parse) {
      function fn_link(scope, element, attrs) {
        var onChange = $parse(attrs.ngFiles);
        element.on('change', function (event) {
          onChange(scope, { $files: event.target.files });
        });
      };

      return {
        link: fn_link
      }
    }])
    .controller('csvImportController', function ($scope, $http) {
      var formdata = new FormData();

      $scope.showLoader = false;

      $scope.getTheFiles = function ($files) {
        angular.forEach($files, function (value, key) {
          formdata.append(key, value);
        });
      };
      
      $scope.uploadFiles = function () {
        $scope.showLoader = true;

        var request = {
          method: 'POST',
          url: '/api/fileupload/',
          data: formdata,
          headers: {
            'Content-Type': undefined
          }
        };
        
        $http(request).
          then(function (response) {
            $scope.showLoader = false;
            alert("Upload complete");           
          });
      }
    }).controller('companiesController', [
      '$scope', '$http', function ($scope, $http) {

        $scope.companies = [];


        $http.get('/api/companies/').
          then(function (response) {
            console.log(response);
            $scope.companies = response.data;
          });
      }
    ]);  
})();
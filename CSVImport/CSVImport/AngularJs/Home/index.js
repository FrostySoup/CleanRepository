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
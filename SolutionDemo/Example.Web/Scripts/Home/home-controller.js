indexModule.controller("HomeController", function ($scope, homeRepository) {
    $scope.categories = homeRepository.get();
});
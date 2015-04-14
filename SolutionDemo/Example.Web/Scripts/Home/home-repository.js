indexModule.factory('homeRepository', function($resource) {
    return {
        get: function () {
            return $resource('/api/Home').query();
        }
    };
});
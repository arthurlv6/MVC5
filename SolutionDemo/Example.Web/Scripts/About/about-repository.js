indexModule.factory('aboutRepository', function ($resource) {
    return {
        get: function() {
            return $resource('/api/About').query();
        }
    };
});
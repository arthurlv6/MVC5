'use strict';

indexModule.factory('contactRepository', function ($resource) {
    return {
        save: function (contact) {
            return $resource('/api/Contact').save(contact);
        }
    };
});
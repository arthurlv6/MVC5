(function () {
    "use strict";
    var app = angular.module("productManagement",
        ["common.services",
            "ui.router"]);

    app.config(["$stateProvider",
            "$urlRouterProvider",
            function ($stateProvider, $urlRouterProvider) {
                $urlRouterProvider.otherwise("/");

                $stateProvider
                    .state("home", {
                        url: "/",
                        templateUrl: "app/welcomeView.html"
                    })
                    // Products
                    .state("productList", {
                        url: "/products",
                        templateUrl: "app/products/productListView.html",
                        controller: "ProductListCtrl as vm"
                    })
                    .state("login", {
                        url: "/login",
                        templateUrl: "app/login.html",
                        controller: "ProductListCtrl as vm"
                    })
                    .state("productEdit", {
                        //abstract: true,
                        url: "/products/edit/:id",
                        templateUrl: "app/products/productEditView.html",
                        controller: "ProductEditCtrl as vm",
                        resolve: {
                            productResource: "productResource",

                            product: function (productResource, $stateParams) {
                                var id = $stateParams.id;
                                return productResource.get({ id: id }).$promise;
                            }
                        }
                    })
                    .state("productDetail", {
                        url: "/products/:productId",
                        templateUrl: "app/products/productDetailView.html",
                        controller: "ProductDetailCtrl as vm",
                        resolve: {
                            productResource: "productResource",

                            product: function (productResource, $stateParams) {
                                var productId = $stateParams.productId;
                                return productResource.get({ productId: productId }).$promise;
                            }
                        }
                    })

            }]
    );
}());
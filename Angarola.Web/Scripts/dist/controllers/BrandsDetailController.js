var BrandsDetailController = (function () {
    "use strict";

    BrandsDetailController.$inject = ["$scope", 'brandService']

    function BrandsDetailController($scope, brandService) {


        this.$scope = $scope;
        this.brandService = brandService;

        this.brand = {};

    }

    BrandsDetailController.prototype.getBrand = function (id) {
        this.brandService.getById(id, this.getBrandSuccess.bind(this), this.getBrandError);
    };

    BrandsDetailController.prototype.getBrandSuccess = function (response, status, xhr) {
        this.brand = response.data.item;
        console.log(this.brand);
    };

    BrandsDetailController.prototype.getBrandError = function (jqXhr, status, error) {
        console.log("get brand error")
    };

    return BrandsDetailController;
})();
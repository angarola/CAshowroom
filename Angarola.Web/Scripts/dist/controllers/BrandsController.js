var BrandsController = (function () {
    "use strict";

    BrandsController.$inject = ["$scope", "Upload", 'brandService', '$http']

    function BrandsController($scope, Upload, brandService, $http) {

        this.$scope = $scope;
        this.$http = $http;
        this.brandService = brandService;

        this.brand = {};
        this.brandList = {};


        this.render();

        this.masonryOptions = {
            columnWidth: '.grid-sizer',
            itemSelector: '.grid-item',
            percentPosition: true
        };
    }

    BrandsController.prototype.render = function () {
        this.brandService.getAllBrands(this.getAllSuccess.bind(this), this.getAllError)
    };

    BrandsController.prototype.submit = function (brand) {
        this.brandService.insertBrand(this.brand, this.insertSuccess, this.insertError)
    };

    BrandsController.prototype.update = function (brand, id) {
        this.brandService.updateBrand(this.brand, this.id, this.updateSuccess.bind(this), this.updateError)
    };

    BrandsController.prototype.getById = function (id) {
        this.brandService.getById(id, this.getByIdSuccess.bind(this), this.getByIdError)
    }

    BrandsController.prototype.delete = function (id) {
        this.brandService.deleteBrand(this.id, this.deleteSuccess, this.deleteError)
    }


    //AJAX SUCCESS
    BrandsController.prototype.insertSuccess = function (response, status, xhr) {
        console.log("success")
    };

    BrandsController.prototype.getByIdSuccess = function (response, status, xhr) {
        this.brand = response.data.item;
    };

    BrandsController.prototype.updateSuccess = function (response, status, xhr) {
        this.brand = response.data.item;
    }

    BrandsController.prototype.deleteSuccess = function (response, status, xhr) {
        console.log("delete successful")
    }

    BrandsController.prototype.getAllSuccess = function (response, status, xhr) {
        this.brandList = response.data.items;
        console.log(this.brandList);
    }

    //AJAX ERRORS
    BrandsController.prototype.insertError = function (jqXhr, status, error) {
        console.log("error")
    };

    BrandsController.prototype.getByIdError = function (jqXhr, status, error) {
        console.log("error")
    };

    BrandsController.prototype.updateError = function (jqXhr, status, error) {
        console.log("update error")
    };

    BrandsController.prototype.deleteError = function (jqXhr, status, error) {
        console.log("delete error")
    };

    BrandsController.prototype.getAllError = function (jqXhr, status, error) {
        console.log("delete error")
    };

    return BrandsController;
})();
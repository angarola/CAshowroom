var BrandsController = (function () {
    "use strict";

    BrandsController.$inject = ["$scope", "Upload", 'brandService']

    function BrandsController($scope, Upload, brandService) {

        this.$scope = $scope;
        this.brandService = brandService;

        this.brandName = '';
        this.brandDesc = '';
    }



    BrandsController.prototype.submit = function (brandName) {
        //this.brandService.createBrand(brand);
        console.log(this.brandName)
    };







    return BrandsController;
})();
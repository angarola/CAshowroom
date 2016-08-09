var BrandService = (function () {

    BrandService.$inject = ['$http'];
    function BrandService($http) {
        this.$http = $http;
    }


    BrandService.prototype.getBrand = function (id) {
        console.log('GET BRAND', id);
    }

    BrandService.prototype.createBrand = function (brand) {
        console.log('create brand', brand);
    };

    return BrandService;
})();
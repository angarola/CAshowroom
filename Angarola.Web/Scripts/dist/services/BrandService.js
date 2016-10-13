var BrandService = (function () {

    BrandService.$inject = ['$http'];
    function BrandService($http) {
        this.$http = $http;
    };

    BrandService.prototype.insertBrand = function (brand, success, error) {
        this.$http.post('/api/brands/', brand).then(success, error);

    };

    BrandService.prototype.updateBrand = function (brand, id, success, error) {
        this.$http.put('/api/brands/' + id, brand).then(success, error);
    };

    BrandService.prototype.getById = function (id, success, error) {
        this.$http.get('/api/brands/' + id).then(success, error);
    };

    BrandService.prototype.getAllBrands = function (success, error) {
        this.$http.get('/api/brands/').then(success, error);
    };

    BrandService.prototype.deleteBrand = function (id, success, error) {
        this.$http.delete('/api/brands/' + id).then(success, error);
    };

    return BrandService;
})();
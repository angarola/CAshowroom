(function () {
    "use strict";





    angular.module('casAPP', ['ngFileUpload'])
        .controller("brandsController", BrandsController)
        .service('brandService', BrandService);

})();
(function () {
    "use strict";

    angular.module('casAPP', ['ngFileUpload', 'slickCarousel'])
        .controller("brandsController", BrandsController)
        .controller("homeController", HomeController)
        .controller('calendarController', CalendarController)
        .controller('brandsDetailController', BrandsDetailController)
        .service('brandService', BrandService)
        .service('calendarService', CalendarService);

})();
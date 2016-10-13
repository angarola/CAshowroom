var HomeController = (function () {
    "use strict";

    HomeController.$inject = ["$scope", 'brandService']

    function HomeController($scope, brandService) {

        this.$scope = $scope;
        this.brandService = brandService; 

        this.brands = {};

        this.slickConfigLoaded = false;
        this.slickConfig = {
            dots: true,
            fade: true,
            arrows: true,
            autoplay: true,
            initialSlide: 0,
            infinite: true,
            mobileFirst: true,
            swipeToSlide: true,
            autoplaySpeed: 3000,
            event: {
                init: function (event, slick) {
                }
            }
        }

        this.render();
    }
    

    

    HomeController.prototype.render = function () {
        this.brandService.getAllBrands(this.getAllSuccess.bind(this), this.getAllError.bind(this));
    };

    HomeController.prototype.getAllSuccess = function (response, status, xhr){
        this.brands = response.data.items;

        console.log('GET ALL SUCCESS', this.brands);
        
        this.slickConfigLoaded = true;
    };

    HomeController.prototype.getAllError = function (jqXhr, status, error) {
        console.log("get all error");
    };


    return HomeController;
})();
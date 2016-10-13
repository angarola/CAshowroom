var CalendarController = (function () {
    "use strict";

    CalendarController.$inject = ["$scope", 'calendarService']

    function CalendarController($scope, calendarService) {

        this.$scope = $scope;
        this.calendarService = calendarService;
        this.eventList = {};
        this.newEvent = {};

        this.render();

    }

    CalendarController.prototype.render = function () {
        this.calendarService.getAllEvents(this.getAllSuccess.bind(this), this.getAllError)
    };

    CalendarController.prototype.submit = function (newEvent) {
        this.calendarService.insertEvent(this.newEvent, this.insertEventSuccess, this.insertEventError)
    }

    //AJAX SUCCESS
    CalendarController.prototype.getAllSuccess = function (response, status, xhr) {
        this.eventList = response.data.items;
        this.eventBool = true;
    };

    CalendarController.prototype.insertEventSuccess = function (response, status, xhr) {
        console.log("insert success")
    };

    //AJAX FAILS
    CalendarController.prototype.getAllError = function (jqXhr, status, error) {
        console.log("get all error")
    };

    CalendarController.prototype.insertEventError = function (jqXhr, status, error) {
        console.log("insert error")
    };

    return CalendarController;
})();
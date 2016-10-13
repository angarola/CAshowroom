var CalendarService = (function () {

    CalendarService.$inject = ['$http'];
    function CalendarService($http) {
        this.$http = $http;
    }

    CalendarService.prototype.insertEvent = function (event, success, error) {
        this.$http.post('/api/calendar/', event).then(success, error);
    };

    CalendarService.prototype.updateEvent = function (event, id, success, error) {
        this.$http.put('/api/calendar/' + id, event).then(success, error);
    }

    CalendarService.prototype.getEventById = function (id, success, error) {
        this.$http.get('/api/calendar/' + id).then(success, error);
    }

    CalendarService.prototype.getAllEvents = function (success, error) {
        this.$http.get('/api/calendar/').then(success, error);
    }

    CalendarService.prototype.deleteEvent = function (id, success, error) {
        this.$http.delete('/api/brands/' + id).then(success, error);
    }

    return CalendarService;
})();
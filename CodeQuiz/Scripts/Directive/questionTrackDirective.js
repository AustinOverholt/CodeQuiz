(function () {
    'use strict';
    angular
        .module('mainApp')
        .directive('questionTrackDirective', questionTrackDirective);

    function questionTrackDirective() {
        return {
            templateUrl: "/Scripts/Directive/questionTrack.html"
        }
    }

})();
(function () {

    var app = angular.module("GBLI", ["Network"]);

    app.controller("DashBoardController", ["$scope", "network_service", FOREST_CTRL]);

    function FOREST_CTRL(scope, ns) {
        scope.pagename = "Main Dash Board";
        scope.preloader = false;
    }
})();
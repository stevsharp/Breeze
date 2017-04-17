
function regionCtl($scope,breeze) {
    var vm = $scope;
    vm.test = 'hello';
    vm.regions = [];
    // crud
    vm.manger = new breeze.EntityManager('breeze/BreezeSample');

    // read
    vm.refresh = function() {
        // exec
        var query = breeze.EntityQuery.from('Region');
        vm.manger.executeQuery(query)
            .then(function(d) {
                vm.regions = d.results;
            });
    };

    // delete
    vm.delete = function(p) {
        p.entityAspect.setDeleted();
    };
    // add
    vm.add = function () {
        var initValues = { RegionID: 7777,RegionDescription:'RegionDescription1' };
        vm.manger.createEntity('Region', initValues);
        alert('add');
    };
    // save
    vm.save = function (a) {
        vm.manger.saveChanges();
        alert('save');
    };

    vm.refresh();
}

angular.module('regionApp', ['breeze.angular'])
    .controller('regionCtl', regionCtl)
    .run();
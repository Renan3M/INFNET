(function () {

    angular.module('MainModule').service('BlockService', blockService);

    function blockService() {

        var _blockId, _primaryArray, _secondaryArray;

        this.setBlockId = setBlockId;
        this.updateStateBlock = updateStateBlock;

        return this;

        function setConfigurations(options) {

            _blockId = options.blockId;
            _primaryArray = options.primaryArray;
            _secondaryArray = options.secondaryArray;

            if (_secondaryArray)
                _primaryArray = _primaryArray.concat(_secondaryArray);
        }

        function setBlockId(blockId) {
            _blockId = blockId;
        }

        function updateStateBlock(primaryArray, secondaryArray) {

            var count = 0;

            if (secondaryArray)
                primaryArray = primaryArray.concat(secondaryArray);

            primaryArray.forEach(function (element) {
                console.log(element);
                if (element) {
                    count++;

                    if (_primaryArray.length == count)
                        App.blocks(_blockId, 'state_normal');

                } else {

                    App.blocks(_blockId, 'state_loading');
                    return;
                }
            });
        }

    }

})();
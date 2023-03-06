// Feel free to change the namespaces
var Utility;
(function (Utility) {
    var Grid;
    (function (Grid) {
        // Register this event onRecordSelect of an Editable Grid.
        function onSelectOfRecord(context) {
            // When we select a line, lock its attributes to ensure no changes can be made.
            lockGridColumns(context);
            // Retrieve the record that was selected
            var selectedRecord = context.getFormContext().data.entity;
            // Open the selected record in a popup
            openRecordInPopup(selectedRecord);
            // We need to refresh the subgrid/parent grid to ensure we deselect the element to stop weird behaviours with the opening.
            Xrm.Utility.refreshParentGrid(selectedRecord.getEntityReference());
        }
        Grid.onSelectOfRecord = onSelectOfRecord;
        function openRecordInPopup(selectedRecord) {
            var Id = selectedRecord.getId().replace(/[{}]/g, "");
            var pageInput = {
                pageType: "custom",
                name: "cr7a3_detailview_dbc11",
                entityName: selectedRecord.getEntityName(),
                recordId: Id
            };
            var navigationOptions = {
                target: 1
            };
            Xrm.Navigation.navigateTo(pageInput, navigationOptions).then(function success() { }, function error() { });
        }
        function lockGridColumns(context) {
            context.getFormContext().data.entity.attributes.forEach(function (attr) {
                attr.controls.forEach(function (c) {
                    c.setDisabled(true);
                });
            });
        }
    })(Grid = Utility.Grid || (Utility.Grid = {}));
})(Utility || (Utility = {}));
function run(executionContext) {
    alert(1);
    var selectedRecord = executionContext.getFormContext().data.entity;
    var Id = selectedRecord.getId().replace(/[{}]/g, "");

    let pageInput = {
        pageType: "custom",
        name: "cr7a3_appcheckerpage_c92c6",
        recordId: Id
    };
    let navigationOptions = {
        target: 1
    };
    Xrm.Navigation.navigateTo(pageInput, navigationOptions)
        .then(
            function () {
                // Handle success
            }
        ).catch(
            function (error) {
                // Handle error
                showPopUp("Error opening custom page; Message - " + error.message, "Error");
            }
        );
}

function showPopUp(text, title) {
    var alertStrings = { confirmButtonLabel: "Yes", text: text, title: title };
    var alertOptions = { height: 120, width: 260 };
    Xrm.Navigation.openAlertDialog(alertStrings, alertOptions).then(
        function (success) {
            console.log("Alert dialog closed");
        },
        function (error) {
            console.log(error.message);
        }
    );
}
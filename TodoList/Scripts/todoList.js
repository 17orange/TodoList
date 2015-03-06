function ConfirmBegin(taskID) {
    // begin task
    if (confirm("Are you sure you want to begin this task?")) {
        $("form#begin" + taskID).submit();
    }
}

function ConfirmCompletion(taskID) {
    // complete task
    if (confirm("Are you sure you've completed this task?")) {
        $("form#complete" + taskID).submit();
    }
}

function SetShowOthers(showThem) {
    // set all of the tasks owned by others to this value
    if (showThem)
    {
        $(".notOwnedByMe").slideDown(250);
    }
    else
    {
        $(".notOwnedByMe").slideUp(250);
    }

    // flip the session variable
    $.post("/Home/SetSession", { key: "ShowOtherUsersTasks", value: (showThem ? "Y" : "N") });
}

function SetShowCompleted(showThem) {
    // set all of the completed tasks to this value
    if (showThem) {
        $(".complete").slideDown(250);
    }
    else {
        $(".complete").slideUp(250);
    }

    // flip the session variable
    $.post("/Home/SetSession", { key: "ShowCompletedTasks", value: (showThem ? "Y" : "N") });
}

// show the specified div
var shownDiv = null;
function ShowRow(div) {
    // keep track of this to avoid the crazy infinite loop
    if (shownDiv != null )
    {
        return;
    }
    shownDiv = div[0];

    // expand it
    div.find(".expansion").slideDown(250);
}

// hide the specified div
function HideRow(div) {
    // keep track of this to avoid the crazy infinite loop
    if (shownDiv != div[0]) {
        return;
    }

    // hide it
    div.find(".expansion").slideUp(250, function () { shownDiv = null; });
}

// add the proper hover function to all of the divs we can show/hide
$(".expandableDiv").hover(function () { ShowRow($(this)); }, function () { HideRow($(this)); });

$(document).ready(function () {
    var boxesVisible = true; // Default to true, assuming boxes are shown initially

    // Click event handler for closing button
    $("#pageContent").on("click", "#closeButton", function () {
        $("#boxContainer").show();
        $("#pageContent").hide();
        boxesVisible = true; // Set boxesVisible to true when closing the page
    });

    // Check if boxes were hidden before loading a page
    if (!ViewBag.ShowBoxes) {
        $("#boxContainer").hide();
        $("#pageContent").show();
        boxesVisible = false; // Set boxesVisible to false if boxes were hidden
    }

    // Function to show the boxes when navigating to a new page
    function showBoxes() {
        if (!boxesVisible) {
            $("#boxContainer").show();
            $("#pageContent").hide();
            boxesVisible = true;
        }
    }

    // Listen for clicks on box links to show the boxes
    $("#boxContainer").on("click", ".box-link", function (e) {
        e.preventDefault();
        var target = $(this).data("target");
        $("#pageContent").load("/Home/" + target, function () {
            showBoxes();
        });
    });
});
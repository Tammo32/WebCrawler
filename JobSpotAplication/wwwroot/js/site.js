// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('#JobSearch').on('click', function (e) {
    e.preventDefault();
    $.get(this.href, function (html) {
        $('#replace').html(html);
    });
});

/* Test for Active Menu Items
var sidebar = document.getElementById("sidebar-nav");
var options = document.getElementByClassName("sidebar-option");

for (var i = 0; i < options.length; i++) {
    options[i].addEventListener("click", function ()) {
        var current = document.getElementByClassName("active");
        current[0].className = current[0].className.replace("active", "");
        this.className += " active";
    });
}
*/
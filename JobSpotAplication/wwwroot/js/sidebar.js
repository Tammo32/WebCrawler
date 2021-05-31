let sidebar = document.querySelector(".sidebar");
let sidebarMenu = document.querySelector(".menu-button");

sidebarMenu.onclick = function () {
    sidebar.classList.toggle("active");
}
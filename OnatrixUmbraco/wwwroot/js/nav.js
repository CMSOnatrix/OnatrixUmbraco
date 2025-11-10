document.addEventListener("DOMContentLoaded", () => {
    const toggle = document.querySelector(".nav-toggle");
    const navList = document.querySelector(".nav-list");

    if (toggle && navList) {
        toggle.addEventListener("click", () => {
            navList.classList.toggle("open");
        });
    }
});
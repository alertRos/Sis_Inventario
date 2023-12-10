let sidebar = document.querySelector(".sidebar");
let closeBtn = document.querySelector("#btn");
let searchBtn = document.querySelector(".bx-search");
const modal = document.getElementsByClassName("show")
modal.style.display = `opacity:0;`;
closeBtn.addEventListener("click", () => {
  sidebar.classList.toggle("open");
  menuBtnChange();
});
searchBtn.addEventListener("click", () => {

  sidebar.classList.toggle("open");
  menuBtnChange(); 
});

function menuBtnChange() {
  if (sidebar.classList.contains("open")) {
    closeBtn.classList.replace("bx-menu", "bx-menu-alt-right"); 
  } else {
    closeBtn.classList.replace("bx-menu-alt-right", "bx-menu");
  }
}

let burger = document.querySelector(".containers");
let burger_menu = document.querySelector(".nav");
burger.addEventListener("click", () => {
  burger.classList.toggle("change");
  burger_menu.classList.toggle("active");
  if (burger_menu.classList.contains("active")) {
    document.body.style.overflow = "hidden";
  } else {
    document.body.style.overflow = "visible";
  }
});

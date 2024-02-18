let taba = document.querySelectorAll(".btn");
let tabs_info = document.querySelectorAll(".car");
for (let i = 0; i < taba.length; i++) {
  taba[i].addEventListener("click", () => {
    for (let i = 0; i < taba.length; i++) {
      tabs_info[i].classList.remove("active");
      taba[i].classList.remove("active");
    }
    tabs_info[i].classList.add("active");
    taba[i].classList.add("active");
  });
}
let Lexus = document.querySelector(".Lexus");
let Lexus_title = document.querySelector(".Lexus_title");
Lexus.addEventListener("click", () => {
  Lexus_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});
let Toyota = document.querySelector(".Toyota");
let Toyota_title = document.querySelector(".Tayota_title");
Toyota.addEventListener("click", () => {
  Toyota_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});

let Nissan = document.querySelector(".Nissan");
let Nissan_title = document.querySelector(".Nissan_title");
Nissan.addEventListener("click", () => {
  Nissan_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});

let BMW = document.querySelector(".BMW");
let BMW_title = document.querySelector(".BMW_title");
BMW.addEventListener("click", () => {
  BMW_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});
let Audi = document.querySelector(".Audi");
let Audi_title = document.querySelector(".Audi_title");
Audi.addEventListener("click", () => {
  Audi_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});
let Mercedes = document.querySelector(".Mercedes");
let Mercedes_title = document.querySelector(".Mersedes_title");
Mercedes.addEventListener("click", () => {
  Mercedes_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});
let Porsche = document.querySelector(".Porsche");
let Porsche_title = document.querySelector(".Porsche_title");
Porsche.addEventListener("click", () => {
  Porsche_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});
let Chevrolet = document.querySelector(".Chevrolet");
let Chevrolet_title = document.querySelector(".Chevrolet_title");
Chevrolet.addEventListener("click", () => {
  Chevrolet_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});
let volkswagen = document.querySelector(".Volkswagen");
let volkswagen_title = document.querySelector(".Volkswagen_title");
volkswagen.addEventListener("click", () => {
  volkswagen_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});
let jaguar = document.querySelector(".Jaguar");
let jaguar_title = document.querySelector(".Jaguar_title");
jaguar.addEventListener("click", () => {
  jaguar_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});
let honda = document.querySelector(".Honda");
let honda_title = document.querySelector(".Honda_title");
honda.addEventListener("click", () => {
  honda_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});
let Subaru = document.querySelector(".Subarus");

let Subaru_title = document.querySelector(".Subaru_title");
Subaru.addEventListener("click", () => {
  Subaru_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});
let Tesla = document.querySelector(".Tesla");
let Tesla_title = document.querySelector(".Tesla_title");
Tesla.addEventListener("click", () => {
  Tesla_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});

let Dodge = document.querySelector(".Dodge");
let Dodge_title = document.querySelector(".Dodge_title");
Dodge.addEventListener("click", () => {
  Dodge_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});
let Volvo = document.querySelector(".Volvo");
let Volvo_title = document.querySelector(".Volvo_title");
Volvo.addEventListener("click", () => {
  Volvo_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});
let windowScroll = window.pageYOffset;
let scroll = document.querySelector(".scroll");

window.addEventListener("scroll", () => {
  windowScroll = window.pageYOffset;
  if (windowScroll > 300) {
    scroll.classList.add("active");
  } else {
    scroll.classList.remove("active");
  }
});
scroll.addEventListener("click", () => {
  window.scrollTo({
    top: 0,
    behavior: "smooth",
  });
});
let Sedan = document.querySelector(".Sedan");
let Sedan_title = document.querySelector(".Sedan_title");
Sedan.addEventListener("click", () => {
  Sedan_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});
let Crosover = document.querySelector(".Crosover");
let Crosover_title = document.querySelector(".Crosover_title");
Crosover.addEventListener("click", () => {
  Crosover_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});

let Universal = document.querySelector(".Universal");
let Universal_title = document.querySelector(".Universal_title");
Universal.addEventListener("click", () => {
  Universal_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});
let Hachback = document.querySelector(".Hachback");
let Hachback_title = document.querySelector(".Hachback_title");
Hachback.addEventListener("click", () => {
  Hachback_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});
let Vnedoroznik = document.querySelector(".Vnedoroznik");
let Vnedoroznik_title = document.querySelector(".Vnedoroznik_title");
Vnedoroznik.addEventListener("click", () => {
  Vnedoroznik_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});
let Pickup = document.querySelector(".Pickup");
let Pickup_title = document.querySelector(".Pickup_title");
Pickup.addEventListener("click", () => {
  Pickup_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});

let Cupe = document.querySelector(".Cupe");
let Cupe_title = document.querySelector(".Cupe_title");
Cupe.addEventListener("click", () => {
  Cupe_title.scrollIntoView({
    behavior: "smooth",
    block: "start",
  });
});

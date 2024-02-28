function clu(){
 let tags=""; 
for(let i=0; i<document.all.length; i++) {
tags+=document.all[i].tagName+" имеет номер" + " "+ i+"<br\>" } 
document.write(tags);
} 
function cru(){
for(let i=0; i<document.body.childNodes.length; i++) {
    let tage=document.body.childNodes[i];
    alert(tage.tagName);
    }
}
function mbb(){
    for(let l=0; l<document.all.length; l++) {
        if (document.all[l].tagName === "SPAN"){
            alert (document.all[i].innerHTML);
            break;
        }
    }
}
function llu(){
    let span = document.body.getElementsByTagName("span");
      alert(span[0].innerHTML);
    
}
function trtr(){
    let spane=document.getElementById('1');
      alert(spane.innerHTML);
}
    function lala(){
    let srball=document.getElementById('2').innerHTML=document.getElementById('2').innerHTML+" "+"Средний балл: 7";
}

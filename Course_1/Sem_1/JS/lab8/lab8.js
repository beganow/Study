obj=document.getElementById("myColor");
obj.onmouseover=function()
{this.style.color='red'; };
obj.onmouseout=function()
{this.style.color='black'; };
rep1=document.getElementById('font');
rep1.onclick=function()
{this.style.fontSize='26px'}
function ruru()
{
document.getElementById('foto1').src ='js.jpg';
}
let text_image = document.getElementById('writl12');
text_image.onclick = () => {
  text_image.innerHTML = "<img src = 'js1.png' height='240px' width='500px'>";
}
function bigImg(x) {
    x.style.height = '300px';
    x.style.width = '500px';
  }
  function littImg(x) {
    x.style.height = '240px';
    x.style.width = '400px';
  }
  let border1 = document.getElementById('mountan');
  border1.ondblclick = () => {
    border1.style.border = "4px dotted blue";
  }



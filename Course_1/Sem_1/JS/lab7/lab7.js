function writing1(){
    let per=' ';
    for (let i=0;i<5;i++)
    {
     if (document.forms[0].space[i].checked)
        per+=('<li>'+document.forms[0].space[i].value+'</li>');
        }
    document.write('<center>'+document.forms[0].elements[1].value+'</center>' +'<br/>Студент'+ ' ' +document.forms[0].elements[2].value +' ' +'специальность' + ' ' + document.forms[0].elements[4].value + ' ' + document.forms[0].s.value + ' ' + 'курс должен сдавать следующие предметы:'+'<ul>'+per+'</ul>');
}
function nicetomet(){
    document.write('С вами было приятно познакомиться'+ ' ' + document.forms[1].elements[1].value +'!')
}

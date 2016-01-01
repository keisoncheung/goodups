var l=document.getElementById("mainleft").scrollHeight;
var r=document.getElementById("mainright").scrollHeight;
layoutHeight=Math.max(l,r);
document.getElementById("mainleft").style.height=layoutHeight+"px";
document.getElementById("mainright").style.height=layoutHeight+"px";
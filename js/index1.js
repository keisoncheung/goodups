function Roll2(room,m1,m2,height2,width2,speed2,type2)
    {
        var r=document.getElementById(room);
        var z1=document.getElementById(m1);
        var z2=document.getElementById(m2);
               
        type2=(type2=="")?"u":type2;//u:向上;d:向下;l:向左;r:向右        
        speed2=(speed2=="")?"50":speed2;
		z2.innerHTML=z1.innerHTML;
		with(r)
		{
		
		    noWrap=true; //这句表内容区不自动换行
		    style.width2=width2; //于是我们可以将它的宽度设为0，因为它会被撑大
		    if(height2!=0)
		    {
		        style.height2=height2;
		    }
		    style.overflowX="hidden"; //滚动条不可见			
		}
		
		function Marquee1()
		{			
		    switch(type2)
		    {
		        case "u":
			        if(z2.offsetHeight-r.scrollTop<=0)
			        {					
				        r.scrollTop-=z1.offsetHeight;
			        }
			        else
			        {					
				        r.scrollTop++;
			        }
			    break;
			    case "d":
			        if(r.scrollTop<=0)
			        {			            
				        r.scrollTop=z2.offsetHeight;				        
			        }
			        else
			        {					
				        r.scrollTop--;
			        }
			    break;
			    case "l":
			        if(z2.offsetWidth-r.scrollLeft<=4)
				    {
					    r.scrollLeft-=z1.offsetWidth
				    }
				    else
				    {
					    r.scrollLeft=r.scrollLeft+1;
				    }
			    break;
			    case "r":
			        if(z2.offsetWidth-r.scrollLeft<=4)
				    {
					    r.scrollLeft-=z1.offsetWidth
				    }
				    else
				    {
					    r.scrollLeft=r.scrollLeft+1;
				    }
			    break;			    
			}
		};
		
		var Time=setInterval(Marquee1,speed2);			
		r.onmouseover=function() 
		{	    
			clearInterval(Time);
		};
		r.onmouseout=function() 
		{
			Time=setInterval(Marquee1,speed2);
		};    
}
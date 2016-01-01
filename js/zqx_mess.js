 function setms(cans)
    {

        var can1, can2, can3, can4,can5,url;
    
    
    switch(cans)
    {
        case 1:
            can1 = "留言标题和内容不能为空!";
            can2 = "留言标题不能为空!";
            can3 = "留言内容不能为空!";
            can4 = "提交成功!";
            can5 = "请输入正确的电子邮件地址!";
            url = 'ms.aspx';
            break;
        case 2:
            can1 = "Message title and content can not be empty!";
            can2 = "Title can not be empty!";
            can3 = "Message content can not be empty!";
            can4 = "Success,thanks!";
            can5 = "Please enter the correct e-mail address!";
            url = '../ms.aspx';
            break;
    
    
    case 3:
    can1="Message title and content can not be empty!";
    can2="Title can not be empty!";
    can3="Message content can not be empty!";
    can4="Success,thanks!";
    url='../ms.aspx';
    
    case 4:
    can1="Message title and content can not be empty!";
    can2="Title can not be empty!";
    can3="Message content can not be empty!";
    can4="Success,thanks!";
    url='../ms.aspx';
    
    break;
    default:
    can1="留言标题和内容不能为空!";
    can2="留言标题不能为空!";
    can3="留言内容不能为空!";
    can4="提交成功!";
    url='ms.aspx';
    break;  
    }
//    if(cans==1)
//    {
//    can1="留言标题和内容不能为空!";
//    can2="留言标题不能为空!";
//    can3="留言内容不能为空!";
//    can4="提交成功!";
//    }
//    else 
//    {
//    can1="Message title and content can not be empty!";
//    can2="Title can not be empty!";
//    can3="Message content can not be empty!";
//    can4="Success,thanks!";
    //    }

//    if (!isValidEmail($('txtName'))) {
//        alert(can5);
//        $('txtName').focus();
//        return;
//    }
    
      if ($F('txtTitle') == "" && $F('txtContent')=="")
        {
            alert(can1);
        }
        else if($F('txtTitle')=="")
        {
        alert(can2);
        }
        else if($F('txtContent')=="")
        {
        alert(can3);
        }
        else
        {
        var inp=$('txtTitle','txtContent','company','addr','txtName','tel','mob');
        var pars='pars='+$F('txtTitle')+'-'+$F('txtContent')+'-'+$F('company')+'-'+$F('addr')+'-'+$F('txtName')+'-'+$F('tel')+'-'+$F('mob')+'-'+cans;
        var myAjax=new Ajax.Request(
        url,{method:'POST',
        parameters: pars,
        onComplete: showms
        });
        function showms(ms)
            {
                alert(can4);
                //循环数组清空
                inp.each(function(va){
                va.value="";
                }
                );
            }
        }  
    }


    //检测邮箱
    function isValidEmail(input) {
        var format = /^((\w|[\-\.])+)@((\w|[\-\.])+)\.([A-Za-z]+)$/;
        return isValidFormat(input, format);
    }

    function isValidFormat(input, format) {
        if (input.value.search(format) != -1) {
            return true; //올바?포맷 형식
        }
        return false;
    }
    
//图片现实功能
function Searchresult(id,pic)
{
var url="Ajax_product.aspx?v="+id+"&time="+(new Date()).getTime();
var pars='v='+id+'&time='+(new Date()).getTime();
var myAjax=new Ajax.Request(
        url,{method:'POST',
        parameters: pars,
        onComplete: showms
        });
        function showms(ms)
        {
        $('cpjj').innerHTML=ms.responseText;
        $('proimg').innerHTML="<a href='upfile/"+pic+ "' rel='lightbox[asd]'><img style='width: 320px; border:0px;' src='upfile/s"+pic+ "' />";
        }
 }

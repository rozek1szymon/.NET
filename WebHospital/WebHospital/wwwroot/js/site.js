document.getElementById('myform').addEventListener('submit', check); 

function check(e)
{



    var writedcode = document.getElementById("code").value;


        if (writedcode == activated)
        {
            alert("super");

        }
        else
        {
            alert("zle");
            e.preventDefault();
        }

    document.getElementById("myform").reset();
    // without it action will appear and didappear
   
    

}  

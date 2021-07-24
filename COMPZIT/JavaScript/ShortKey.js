
       $(document).ready(function () {
           var isAlt = false;
           $(document).keydown(function (event) {
               var key = event.keyCode || event.charCode || 0;
               if (key == 18) { //   check for Press of alt key
                   isAlt = true;
               }
                if (key == 78 && isAlt == true) { // Page Add Press N
                    eval($("[id$='lbtnAdd']").attr("href"));
                
               } else if (key == 76 && isAlt == true) { // Page List Press L                
                   eval($("[id$='lbtnList']").attr("href"));
                
               } else if (key == 73 && isAlt == true) { // For Button Add I
                   $("[id$='btnAdd']").trigger('click');
                   $("[id$='btnUpdate']").trigger('click');
               }
               else if (key == 82 && isAlt == true) { // For Button Cancel R
                   $("[id$='btnCancel']").trigger('click');
                 
               }            
              
           });
           $(document).keyup(function (event) {
               var key = event.keyCode || event.charCode || 0;
               if (key == 18)
               {
                   isAlt = false;
               }

           });
       });

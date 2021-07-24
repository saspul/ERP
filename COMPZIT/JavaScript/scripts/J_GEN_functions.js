// JScript File

    /*
        Function Name       :   getEditorValue
        Created By          :   Unni
        Creation Date       :   23-06-2006  
        Modified Date       :   
        Modified By         :   
        Input Parameters    :   editorInstance -> object -> FCKeditor instance.
        Output Parameters   :   oEditor.GetXHTML -> string -> editor contents.
        Description         :   To get the editor contents as XHTML. 
    
    */
    function getEditorValue( editorInstance ) 
    {  
      // Get the editor instance that we want to interact with.
      var oEditor = FCKeditorAPI.GetInstance( editorInstance ) ;
      
      // Get the editor contents as XHTML.
      return oEditor.GetXHTML( true ) ;  // "true" means you want it formatted.
    }


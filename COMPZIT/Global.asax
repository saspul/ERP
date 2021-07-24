<%@ Application Language="C#" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {

        WebControl.DisabledCssClass = "";
        // Code that runs on application startup

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        BL_Compzit.clsBusineesLayerException objBusinessLayerException = new BL_Compzit.clsBusineesLayerException();
        // Code that runs when an unhandled error occurs
        Exception Exc = Server.GetLastError() as HttpException;
        Exception exc = Server.GetLastError();

        if (exc is HttpUnhandledException)
        {
            if (exc.InnerException != null)
            {
                objBusinessLayerException.ExceptionHandling(Exc);
                exc = new Exception(exc.InnerException.Message);
                //Server.Transfer("Exception_Tracing/Custom_Error.aspx?handler=Application_Error%20-%20Global.asax",
                //    true);                
            }
        }   
    }


    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }
       
</script>

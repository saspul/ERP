﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TEST_Simle_tEst_test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            Label1.Text = "hi";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Label1.Text = "bye";
    }
}
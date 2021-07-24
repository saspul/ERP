using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System.Diagnostics;

public partial class TEST_PDF_DefaultPDF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        PdfDocument pdf = new PdfDocument();
        pdf.Info.Title = "My First PDF";
        PdfPage pdfPage = pdf.AddPage();
        XGraphics graph = XGraphics.FromPdfPage(pdfPage);
        XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
        graph.DrawString("This is my first PDF document", font, XBrushes.Black, new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.Center);
        string pdfFilename = "firstpage.pdf";
        pdf.Save(pdfFilename);
        Process.Start(pdfFilename);
    }
}
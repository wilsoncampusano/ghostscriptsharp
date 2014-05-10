using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GhostscriptSharpImpl;

namespace GhostscriptSharpImpl
{
    [Obsolete("Aplicacion de consola, favor utilizar otras clases")]
    class Run
    {
        public static void Main(string[] args)
        {
            string[] fileNames = {
@"pdf_name.pdf"};

            foreach (var item in fileNames)
            {
                GhostscriptSharpImplementation
                t = new GhostscriptSharpImplementation(@"C:\Users\wilson.campusano\Desktop\Boletines",
                item, @"C:\Users\wilson.campusano\Desktop\Boletines", ImageExtension.png);
                
                t.GenerateMultiplePageThumbnails(); 

            }
        }
    }

    public class PdfJsonMetaData
    {
        private static string JSON_NAME = "/pdf-meta-data.js";
        public string server_file { get; set; }
        public int page_numbers { get; set; }
        public string pdf_serie { get; set; }
        public string pdf_folder { get; set; }
        public DateTime upload_date { get; set; }


        public static void createJsonMeta(PdfJsonMetaData pdfMeta)
        {
            //string json = new JavaScriptSerializer().Serialize(pdfMeta);
           // System.IO.File.WriteAllText(@HttpContext.Current.Server.MapPath(pdfMeta.pdf_folder + JSON_NAME), json);
        }

    }
}
/*
 @"b32\Orientando_No_32.pdf",
@"b32\Orientando_No_32.pdf",
@"b32\Orientando_No_32.pdf",
@"b32\Orientando_No_32.pdf",
@"b32\Orientando_No_32.pdf",
@"b32\Orientando_No_32.pdf",
@"b32\Orientando_No_32.pdf",
@"b32\Orientando_No_32.pdf",
@"b32\Orientando_No_32.pdf",
@"b32\Orientando_No_32.pdf",
@"b32\Orientando_No_32.pdf",
@"b32\Orientando_No_32.pdf",
 
 
 
 */
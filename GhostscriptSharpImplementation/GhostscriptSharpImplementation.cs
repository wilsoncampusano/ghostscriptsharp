using System;
using GhostscriptSharp;
using System.IO;
using iTextSharp.text.pdf;

namespace GhostscriptSharpImpl
{

    public class GhostscriptSharpImplementation
    {
        private readonly string FILE_LOCATION;
        private string MULTIPLE_FILE_LOCATION;
        private int MULTIPLE_FILE_PAGE_COUNT;

        public string basePathToPdf { get; private set; }
        public string pdfFileName { get; private set; }
        public string basePathToSaveImages { get; private set; }
        public string urlToPdfFile { get; private set; }
        public string separator { get; private set; }
        public ImageExtension imageExtension { get; set; }

        public GhostscriptSharpImplementation(
            string basePathToPdf,
            string pdfFileName,
            string basePathToSaveImages,
            ImageExtension ie)
        {
            this.basePathToPdf = basePathToPdf;
            this.pdfFileName = pdfFileName;
            this.basePathToSaveImages = basePathToSaveImages;
            this.separator = System.IO.Path.DirectorySeparatorChar.ToString();
            this.imageExtension = ie;
            this.urlToPdfFile = basePathToPdf + this.separator + pdfFileName;
            this.FILE_LOCATION = urlToPdfFile;
        }


        private void GenerateSinglePageThumbnail()
        {
            //GhostscriptWrapper.GeneratePageThumb(FILE_LOCATION, SINGLE_FILE_LOCATION, 1, 100, 100,500,600);
        }

         public void GenerateMultiplePageThumbnails()
         {
             GenerateMultiplePageThumbnails(300,300, 300,440);
         }

        public void GenerateMultiplePageThumbnails(int width, int height)
        {

            GenerateMultiplePageThumbnails(300, 300, width, height);

        }


        public void GenerateMultiplePageThumbnails(int dpix, int dpiy, int width, int height)
        {
            string currentFolder = pdfFileName.Split('.')[0];

            string pathString = System.IO.Path.Combine(basePathToSaveImages, currentFolder);

            System.IO.Directory.CreateDirectory(pathString);

            String path_final_format = "{0}{1}{2}.{3}";
           
            string image_name = "%d";

            this.MULTIPLE_FILE_PAGE_COUNT = getPageCount();

            this.MULTIPLE_FILE_LOCATION = String.Format(path_final_format,
                pathString, separator, image_name, imageExtension);

            GhostscriptWrapper.GeneratePageThumbs(FILE_LOCATION, MULTIPLE_FILE_LOCATION, 1, MULTIPLE_FILE_PAGE_COUNT, dpix, dpiy, width, height);

        }

        private int getPageCount()
        {
            PdfReader reader = new PdfReader(FILE_LOCATION);
            return reader.NumberOfPages;
        }

    }
}

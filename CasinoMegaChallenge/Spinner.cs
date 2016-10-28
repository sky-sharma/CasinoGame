using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.IO;

namespace CasinoMegaChallenge
{
    [Serializable]
    public class Spinner
    {
        private int thisSpinnerIndex;
        public int spinnerIndex
        {
            get
            {
                return thisSpinnerIndex;
            }

            set
            {
                thisSpinnerIndex = value;
            }
        }

        private Image thisSpinnerImage;
        public System.Web.UI.WebControls.Image spinnerImage
        {
            get
            {
                return thisSpinnerImage;
            }

            set
            {
                thisSpinnerImage = value;
            }
        }

        private string thisImagesURL;
        public string imagesURL
        {
            get
            {
                return thisImagesURL;
            }

            set
            {
                thisImagesURL = value;
            }
        }

        private Random thisSpinnerRandom;
        private Random spinnerRandom
        {
            get
            {
                return thisSpinnerRandom;
            }

            set
            {
                thisSpinnerRandom = value;
            }
        }

        private string thisImageName;
        public string imageName
        {
            get
            {
                return thisImageName;
            }

            set
            {
                thisImageName = value;
            }
        }


        public Spinner(Random assignedSpinnerRandom, Image assignedSpinnerImage)
        {
            imagesURL = "~/Images";
            spinnerRandom = assignedSpinnerRandom;
            spinnerImage = assignedSpinnerImage;
            showNewImage();
        }

        public void showNewImage()
        {
              thisSpinnerImage.ImageUrl = loadNewImage();
        }

        private string loadNewImage()
        {
            string[] imageFiles;
            int imageIndex;
            string imageFileName;
            string workingDir = AppDomain.CurrentDomain.BaseDirectory;

            imageFiles = Directory.GetFiles(workingDir + "\\Images", "*.png");
            imageIndex = spinnerRandom.Next(0, imageFiles.Length - 1);
            imageFileName = Path.GetFileName(imageFiles[imageIndex]);
            imageName = Path.GetFileNameWithoutExtension(imageFileName);
            return (imagesURL + "/" + imageFileName);
        }

        public void spin()
        {
            showNewImage();
        }
    }
}
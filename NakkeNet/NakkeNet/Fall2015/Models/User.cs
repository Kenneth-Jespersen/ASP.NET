using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using NakkeNet.Helpers;

namespace NakkeNet.Models
{
    public class User
    {

        public int UserId { get; set; }

        public Competency competency = new Competency();
        public CompetencyHeader header = new CompetencyHeader(); 

        [Required]
        public String Firstname { get; set; }

        [Required]
        public String Lastname { get; set; }

        [Required]
        [EmailAddress]
        public String Email { get; set; }

        public String MobilePhone { get; set; }

        public String ProfileImagePath { get; set; }

        public ICollection<Competency> Competencies { get; set; }

        public String ApplicationUserId { get; set; }

        public void SaveImage(HttpPostedFileBase image, String serverPath, String pathToFile)
        {
            if (image == null) return;

            Guid filename = Guid.NewGuid();

            ImageModel.ResizeAndSave(serverPath + pathToFile, filename.ToString(), image.InputStream, 200);

            ProfileImagePath = pathToFile + filename.ToString() + ".jpg";
        }
    }
}
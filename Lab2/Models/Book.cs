using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Lab2.Models
{
    public class Book
    {
        private int id;
        private string title;
        private string author;
        private string image_cover;

        [Required(ErrorMessage = "Mã sách không được trống")]
        [Display(Name = "Mã sách")]
        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
        [Required(ErrorMessage = "Tiêu đề không được trống")]
        [StringLength(250, ErrorMessage = "Tiêu đề không được vượt quá 250 ký tự")]
        [Display(Name ="Tiêu đề")]
        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }
        [Display(Name = "Tác giả")]
        public string Author
        {
            get
            {
                return author;
            }

            set
            {
                author = value;
            }
        }
        [Display(Name = "Đường dẫn ảnh bìa")]
        public string Image_cover
        {
            get
            {
                return image_cover;
            }

            set
            {
                image_cover = value;
            }
        }

        public Book(
            int id,
            string title,
            string author,
            string image_cover)
        {
            this.Id = id;
            this.Title = title;
            this.Author = author;
            this.Image_cover = image_cover;
        }
        public Book ()
        {

        }
       
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NTDShop.Web.Models
{
    public class ProductCategoryViewModel
    {
        public int ID { set; get; }

        [Required(ErrorMessage = "phải nhập vào tên danh mục")]
        public string Name { set; get; }

        [Required(ErrorMessage ="phải nhập vào tiêu đề SEO")]
        public string Alias { set; get; }

        public string Description { set; get; }
        public int? ParentID { set; get; }
        public int? DisplayOrder { set; get; }

        public string Image { set; get; }

        public bool? HomeFlag { set; get; }

        public virtual IEnumerable<ProductViewModel> Products { set; get; }
        public DateTime? CreatedDate { set; get; }

     
        public string CreatedBy { set; get; }

        public DateTime? UpdatedDate { set; get; }

       
        public string UpdatedBy { set; get; }

      
        public string MetaKeyword { set; get; }

       
        public string MetaDescription { set; get; }

        [Required(ErrorMessage = "phải nhập vào status")]
        public bool Status { set; get; }
    }
}
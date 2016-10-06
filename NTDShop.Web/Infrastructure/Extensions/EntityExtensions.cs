using NTDShop.Model.Models;
using NTDShop.Web.Models;

namespace NTDShop.Web.Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdatePostCategory(this PostCategory postCategory, PostCategoryViewModel postVm)
        {
            postCategory.ID = postVm.ID;
            postCategory.Name = postVm.Name;
            postCategory.Description = postVm.Description;
            postCategory.Alias = postVm.Alias;
            postCategory.ParentID = postVm.ParentID;
            postCategory.DisplayOrder = postVm.DisplayOrder;
            postCategory.Image = postVm.Image;
            postCategory.HomeFlag = postVm.HomeFlag;

            postCategory.CreatedBy = postVm.CreatedBy;
            postCategory.UpdatedBy = postVm.UpdatedBy;
            postCategory.UpdatedDate = postVm.UpdatedDate;
            postCategory.MetaDescription = postVm.MetaDescription;
            postCategory.MetaKeyword = postVm.MetaKeyword;
            postCategory.CreatedBy = postVm.CreatedBy;
            postCategory.Status = postVm.Status;
        }

        public static void UpdateProductCategory(this ProductCategory ProductCategory, ProductCategoryViewModel ProductCategoryVm)
        {
            ProductCategory.ID = ProductCategoryVm.ID;
            ProductCategory.Name = ProductCategoryVm.Name;
            ProductCategory.Description = ProductCategoryVm.Description;
            ProductCategory.Alias = ProductCategoryVm.Alias;
            ProductCategory.ParentID = ProductCategoryVm.ParentID;
            ProductCategory.DisplayOrder = ProductCategoryVm.DisplayOrder;
            ProductCategory.Image = ProductCategoryVm.Image;
            ProductCategory.HomeFlag = ProductCategoryVm.HomeFlag;
            ProductCategory.CreatedDate = ProductCategoryVm.CreatedDate;
            ProductCategory.CreatedBy = ProductCategoryVm.CreatedBy;
            ProductCategory.UpdatedBy = ProductCategoryVm.UpdatedBy;
            ProductCategory.UpdatedDate = ProductCategoryVm.UpdatedDate;
            ProductCategory.MetaDescription = ProductCategoryVm.MetaDescription;
            ProductCategory.MetaKeyword = ProductCategoryVm.MetaKeyword;
            ProductCategory.CreatedBy = ProductCategoryVm.CreatedBy;
            ProductCategory.Status = ProductCategoryVm.Status;
        }

        public static void UpdatePost(this Post post, PostViewModel postVm)
        {
            post.ID = postVm.ID;
            post.Name = postVm.Name;
            post.Description = postVm.Description;
            post.Alias = postVm.Alias;
            post.CategoryID = postVm.CategoryID;

            post.Image = postVm.Image;
            post.HomeFlag = postVm.HomeFlag;

            post.Content = postVm.Content;
            post.ViewCount = postVm.ViewCount;
            post.HotFlag = postVm.HotFlag;

            post.CreatedBy = postVm.CreatedBy;
            post.UpdatedBy = postVm.UpdatedBy;
            post.UpdatedDate = postVm.UpdatedDate;
            post.MetaDescription = postVm.MetaDescription;
            post.MetaKeyword = postVm.MetaKeyword;
            post.CreatedBy = postVm.CreatedBy;
            post.Status = postVm.Status;
        }
    }
}
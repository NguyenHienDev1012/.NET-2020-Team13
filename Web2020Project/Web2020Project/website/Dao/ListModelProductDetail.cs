using System.Collections.Generic;
using Web2020Project.Model;

namespace Web2020Project.Website.Dao
{
    public class ListModelProductDetail
    {
        public ProductDetail listproductdetail;
        public List<Comment> comments;

        public ProductDetail Listproductdetail
        {
            get => listproductdetail;
            set => listproductdetail = value;
        }

        public List<Comment> Comments
        {
            get => comments;
            set => comments = value;
        }
    }
    
}
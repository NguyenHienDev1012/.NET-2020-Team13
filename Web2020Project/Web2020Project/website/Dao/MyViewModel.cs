﻿using System.Collections.Generic;
using Web2020Project.Model;

namespace Web2020Project.Website.Dao
{
    public class MyViewModel

    
    {
        public List<News> listNews ;
        public List<Product> listProduct_new;
        public List<Product> listProduct_hot;
        public List<Product> listProduct_sale;

        public List<News> ListNews
        {
            get => listNews;
            set => listNews = value;
        }

        public List<Product> ListProductNew
        {
            get => listProduct_new;
            set => listProduct_new = value;
        }

        public List<Product> ListProductHot
        {
            get => listProduct_hot;
            set => listProduct_hot = value;
        }

        public List<Product> ListProductSale
        {
            get => listProduct_sale;
            set => listProduct_sale = value;
        }
    }
    
}
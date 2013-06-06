// <copyright file="ProductOwner.cs" company="cognizant.com">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>CTS</author>
namespace Philips.DigitalServices.Eloqua.EloquaCloudProductConnector
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// It hold the product owned information
    /// </summary>
    public class ProductOwned
    {
        /// <summary>
        /// Initializes a new instance of the ProductOwner class
        /// </summary>
        /// <param name="emailID">email ID</param>
        /// <param name="productOwn1">product Owned1</param>
        /// <param name="productDetails1">product Details1</param>
        /// <param name="productImage1">product Image1</param>
        /// <param name="productOwn2">product Owned2</param>
        /// <param name="productDetails2">product Details2</param>
        /// <param name="productImage2">product Image2</param>
        /// <param name="productOwn3">product Owned3</param>
        /// <param name="productDetails3">product Details3</param>
        /// <param name="productImage3">product Image3</param>
        public ProductOwned(
            string emailID,
            string productOwn1,
            string productDetails1,
            string productImage1,
            string productOwn2,
            string productDetails2,
            string productImage2,
            string productOwn3,
            string productDetails3,
            string productImage3)
        {
            // TODO: Complete member initialization
            this.EmailID = emailID;
            this.ProductOwn1 = productOwn1;
            this.ProductDetails1 = productDetails1;
            this.ProductImage1 = productImage1;
            this.ProductOwn2 = productOwn2;
            this.ProductDetails2 = productDetails2;
            this.ProductImage2 = productImage2;
            this.ProductOwn3 = productOwn3;
            this.ProductDetails3 = productDetails3;
            this.ProductImage3 = productImage3;
        }

        /// <summary>
        /// Gets or sets the EmailID
        /// </summary>
        public string EmailID { get; set; }

        /// <summary>
        /// Gets or sets the First Product Owned
        /// </summary>
        public string ProductOwn1 { get; set; }

        /// <summary>
        /// Gets or sets the First Product Details
        /// </summary>
        public string ProductDetails1 { get; set; }

        /// <summary>
        /// Gets or sets the First Product Image Path
        /// </summary>
        public string ProductImage1 { get; set; }

        /// <summary>
        /// Gets or sets the Second Product Owned
        /// </summary>
        public string ProductOwn2 { get; set; }

        /// <summary>
        /// Gets or sets the Second Product Details
        /// </summary>
        public string ProductDetails2 { get; set; }

        /// <summary>
        /// Gets or sets the Second Product Image Path
        /// </summary>
        public string ProductImage2 { get; set; }

        /// <summary>
        /// Gets or sets the Third Product Owned
        /// </summary>
        public string ProductOwn3 { get; set; }

        /// <summary>
        /// Gets or sets the Third Product Details
        /// </summary>
        public string ProductDetails3 { get; set; }

        /// <summary>
        /// Gets or sets the Third Product Image Path
        /// </summary>
        public string ProductImage3 { get; set; }
    }
}
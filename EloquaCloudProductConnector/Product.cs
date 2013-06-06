// <copyright file="Product.cs" company="cognizant.com">
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
    /// It stores product information
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Initializes a new instance of the Product class.
        /// </summary>
        /// <param name="productID">product ID</param>
        /// <param name="productText">product Text</param>
        /// <param name="productHTMLLink">product HTMLLink</param>
        public Product(string productID, string productName, string productDesc, string productImgLink)
        {
            // TODO: Complete member initialization
            this.ProductID = productID;
            this.ProductName = productName;
            this.ProductDesc = productDesc;
            this.ProductImgLink = productImgLink;
        }

        /// <summary>
        /// Gets or sets the  ProductID
        /// </summary>
        public string ProductID { get; set; }

        /// <summary>
        /// Gets or sets the  ProductID
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// Gets or sets the Product Description
        /// </summary>
        public string ProductDesc { get; set; }

        /// <summary>
        /// Gets or sets the Product Image Link
        /// </summary>
        public string ProductImgLink { get; set; }
    }
}
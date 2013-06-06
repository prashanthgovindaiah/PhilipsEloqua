// <copyright file="ProductInterest.cs" company="cognizant.com">
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
    /// The entity class contains Product Interest details
    /// </summary>
    public class ProductInterest
    {
        /// <summary>
        /// Initializes a new instance of the ProductInterest class.
        /// </summary>
        /// <param name="emailID">email ID</param>
        /// <param name="productInt1">product Interest1</param>
        /// <param name="productDetails1">product Details1</param>
        /// <param name="productImage1">product Image1</param>
        /// <param name="productInt2">product Interest2</param>
        /// <param name="productDetails2">product Details2</param>
        /// <param name="productImage2">product Image2</param>
        /// <param name="productInt3">product Interest3</param>
        /// <param name="productDetails3">product Details3</param>
        /// <param name="productImage3">product Image3</param>
        public ProductInterest(
            string emailID,
            string product1ID,
            string product1Desc,
            string product1ImgLink,
            string product2ID,
            string product2Desc,
            string product2ImgLink,
            string product3ID,
            string product3Desc,
            string product3ImgLink,
            int contactID)
        {
            // TODO: Complete member initialization
            this.EmailID = emailID;
            this.Product1ID = product1ID;
            this.Product1Desc = product1Desc;
            this.Product1ImgLink = product1ImgLink;
            this.Product2ID = product2ID;
            this.Product2Desc = product2Desc;
            this.Product2ImgLink = product2ImgLink;
            this.Product3ID = product3ID;
            this.Product3Desc = product3Desc;
            this.Product3ImgLink = product3ImgLink;
            this.ContactId = contactID;
        }

        /// <summary>
        /// Gets or sets the Email ID
        /// </summary>
        public string EmailID { get; set; }

        /// <summary>
        /// Gets or sets the First Product Interest 
        /// </summary>
        public string Product1ID { get; set; }

        /// <summary>
        /// Gets or sets the First Product Details 
        /// </summary>
        public string Product1Desc { get; set; }

        /// <summary>
        /// Gets or sets the First Product Image 
        /// </summary>
        public string Product1ImgLink { get; set; }

        /// <summary>
        /// Gets or sets the Second Product Interest
        /// </summary>
        public string Product2ID { get; set; }

        /// <summary>
        /// Gets or sets the Second Product Details
        /// </summary>
        public string Product2Desc { get; set; }

        /// <summary>
        /// Gets or sets the Second Product Image
        /// </summary>
        public string Product2ImgLink { get; set; }

        /// <summary>
        /// Gets or sets the Third Product Interest
        /// </summary>
        public string Product3ID { get; set; }

        /// <summary>
        /// Gets or sets the Third Product Details
        /// </summary>
        public string Product3Desc { get; set; }

        /// <summary>
        /// Gets or sets the Third Product Image
        /// </summary>
        public string Product3ImgLink { get; set; }

        /// <summary>
        /// Gets or sets the Third Product Image
        /// </summary>
        public int ContactId { get; set; }

    }
}
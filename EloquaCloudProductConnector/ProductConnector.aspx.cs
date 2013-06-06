// <copyright file="ProductConnector.aspx.cs" company="cognizant.com">
//     MyCompany.com. All rights reserved.
// </copyright>
// <author>CTS</author>
namespace Philips.DigitalServices.Eloqua.EloquaCloudProductConnector
{
    #region using declaratives
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Xml.Linq;
    using System.IO;
    using System.Configuration;
    using Philips.DigitalServices.Eloqua.EloquaCloudProductConnector.ElqService;
    #endregion

    /// <summary>
    /// It has the logic to perform :
    /// 1. Read Product Purchase and Interest related Information from xml
    /// 2. Load the selected Contacts
    /// 3. Insert the customer interested/purchased product into CDO by mapping them with the contact
    /// </summary>
    public partial class ProductConnector : System.Web.UI.Page
    {

        #region Message Box
        /// <summary>
        /// Generic message box
        /// </summary>
        /// <param name="strMsg">String Message</param>
        public void MessageBox(string strMsg)
        {
            Controls.Add(new LiteralControl("<script language='javascript'> window.alert('" + strMsg.Replace("'", "\\'") + "')</script>"));
        }
        #endregion

        #region Main Button Click
        /// <summary>
        /// It invokes the methods of read product, read contact & insert the interesed product details into CDO datacards
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">e</param>
        protected void btnContactProduct_Click(object sender, EventArgs e)
        {
            List<Product> productCollection = new List<Product>();
            List<ProductInterest> productInt = new List<ProductInterest>(); 
            productCollection = this.ReadProducts();
            //Read the contacts and their product interest and product owned
            ReadContacts(productCollection, productInt);
            InsertDataCard(productInt);
            this.MessageBox("Generated Successfully!");
        }
        #endregion

        #region Reading Contacts based on the Modified Date
        /// <summary>
        /// It reads the contacts from contact entity using some filter
        /// </summary>
        private void ReadContacts(List<Product> productCollection, List<ProductInterest> productInt)
        {
            const string SearchQuery = "C_DateModified>2013-06-05";

            ElqService.EloquaServiceClient ServiceProxy = new ElqService.EloquaServiceClient();
            EloquaProgramService.ExternalActionServiceClient ProgramServiceProxy = new EloquaProgramService.ExternalActionServiceClient();
            
            List<ProductOwned> productOwns = new List<ProductOwned>();
            ////Perform the authentication
            this.SetEloquaServices(ServiceProxy, ProgramServiceProxy);

            EntityType contactEntityType = new EntityType
            {
                ID = 0,
                Name = "Contact",
                Type = "Base"
            };
            //// Create a new list containing the fields you want populated
            List<string> fieldList = new List<string>(); 

            // Define a container for the Query results
            DynamicEntityQueryResults queryResult;

            //// Set the page number and size for the results
            const int CurrentPage = 1;
            const int PageSize = 20;

            //// If the field list is empty - the request will return all Entity Fields
            //// Otherwise, only fields defined in the field list are returned
            if (fieldList.Count == 0)
            {
                //// Execute the request and return all of the Entity's fields
                queryResult = ServiceProxy.Query(contactEntityType, SearchQuery, null, CurrentPage, PageSize);
            }
            else
            {
                //// Execute the request and return only the selected fields
                queryResult = ServiceProxy.Query(contactEntityType, SearchQuery, fieldList.ToArray(), CurrentPage, PageSize);
            }

            if (queryResult.Entities.Length > 0)
            {
                //// Extract each Dynamic Entity in the result
                foreach (DynamicEntity dynamicEntity in queryResult.Entities)
                {
                    string[] arrContactValue = new string[4];

                    ////Extract the field name and value of each field in the collection
                    foreach (KeyValuePair<string, string> field in dynamicEntity.FieldValueCollection)
                    {
                        if (field.Key == "C_EmailAddress")
                        {
                            arrContactValue[0] = field.Value;
                        }

                        if (field.Key == "C_Interested_Product_Id11")
                        {
                            arrContactValue[1] = field.Value;
                        }

                        if (field.Key == "C_Interested_Product_Id21")
                        {
                            arrContactValue[2] = field.Value;
                        }

                        if (field.Key == "C_Interested_Product_Id31")
                        {
                            arrContactValue[3] = field.Value;
                        }
                    }

                    ////Validate if the product interest having some value
                    if (arrContactValue[0] != string.Empty && arrContactValue[1] != null)
                    {
                        productInt = this.ContactProductInterestDetails(arrContactValue[0], arrContactValue[1], arrContactValue[2], arrContactValue[3], dynamicEntity.Id, productCollection, productInt);
                    }
                }
            }
        }
        #endregion

        #region Contact Product Interest Collection
        /// <summary>
        /// Add into the Contact Product Interest Collection
        /// </summary>
        /// <param name="email">email I</param>
        /// <param name="prodInt1">product Interest1</param>
        /// <param name="prodInt2">product Interest2</param>
        /// <param name="prodInt3">product Interest3</param>
        private List<ProductInterest> ContactProductInterestDetails(string email, string prodInt1, string prodInt2, string prodInt3, int contactID, List<Product> productCollection, List<ProductInterest> productInt)
        {
            ////find a specific object
            Product objProd1 = productCollection.SingleOrDefault(s => s.ProductID == prodInt1);
            Product objProd2 = productCollection.SingleOrDefault(s => s.ProductID == prodInt2);
            Product objProd3 = productCollection.SingleOrDefault(s => s.ProductID == prodInt3);

            

            string product1ID = string.Empty;
            string product1Desc = string.Empty;
            string product1ImgLink = string.Empty;
            string product2ID = string.Empty;
            string product2Desc = string.Empty;
            string product2ImgLink = string.Empty;
            string product3ID = string.Empty;
            string product3Desc = string.Empty;
            string product3ImgLink = string.Empty;
            

            if (objProd1 != null)
            {
                product1ID = objProd1.ProductName;
                product1Desc= objProd1.ProductDesc;
                product1ImgLink = objProd1.ProductImgLink;
            }

            if (objProd2 != null)
            {
                product2ID = objProd2.ProductName;
                product2Desc = objProd2.ProductDesc;
                product2ImgLink = objProd2.ProductImgLink;
            }

            if (objProd3 != null)
            {
                product3ID = objProd3.ProductName;
                product3Desc = objProd3.ProductDesc;
                product3ImgLink = objProd3.ProductImgLink;
            }


            productInt.Add(
            new ProductInterest(
                email,
                product1ID,
                product1Desc,
                product1ImgLink,
                product2ID,
                product2Desc,
                product2ImgLink,
                product3ID,
                product3Desc,
                product3ImgLink,
                contactID));

            return productInt;
        }
        #endregion

        #region Setting Eloqua Credentials
        /// <summary>
        /// Connect to the instance and create proxy
        /// </summary>
        private void SetEloquaServices(ElqService.EloquaServiceClient serviceProxy, EloquaProgramService.ExternalActionServiceClient programServiceProxy)
        {
            string strInstanceName = "CSStuartOrmistonE10";
            string strUserID = "Prashanth.Govindaiah";
            string strUserPassword = "Infy1234";

            serviceProxy.ClientCredentials.UserName.UserName = strInstanceName + "\\" + strUserID;
            serviceProxy.ClientCredentials.UserName.Password = strUserPassword;

            programServiceProxy = new EloquaProgramService.ExternalActionServiceClient();
            programServiceProxy.ClientCredentials.UserName.UserName = strInstanceName + "\\" + strUserID;
            programServiceProxy.ClientCredentials.UserName.Password = strUserPassword;
        }
        #endregion

        #region Creation of CDO Entries for contacts
        /// <summary>
        /// It insert the customer product interest details into data card
        /// </summary>
        private void InsertDataCard(List<ProductInterest> productInt)
        {
            int dataCardId = 0;
            var dataCardIDs = new int[1];

            try
            {
                ElqService.EloquaServiceClient ServiceProxy = new ElqService.EloquaServiceClient();
                EloquaProgramService.ExternalActionServiceClient ProgramServiceProxy = new EloquaProgramService.ExternalActionServiceClient();

                ////Perform the authentication
                this.SetEloquaServices(ServiceProxy, ProgramServiceProxy);

                //// Build a DataCardSet Entity Type object - (the ID is the ID of an existing DataCardSet in Eloqua)
                EntityType entityType = new EntityType { ID = 13, Name = "ProductInterest", Type = "DataCardSet" };

                for(int counter=0; counter<productInt.Count; counter++)
                {

                //// Create an Array of Dynamic Entities
                DynamicEntity[] dynamicEntities = new DynamicEntity[1];

                //// Create a new Dynamic Entity and add it to the Array of Entities
                dynamicEntities[0] = new DynamicEntity();
                dynamicEntities[0].EntityType = entityType;

                //// Create a Dynamic Entity's Field Value Collection
                dynamicEntities[0].FieldValueCollection = new DynamicEntityFields();

                //// Add the DataCard's Email Address field to the Dynamic Entity’s field collection
                dynamicEntities[0].FieldValueCollection.Add("Email_Address1", productInt[counter].EmailID);
                dynamicEntities[0].FieldValueCollection.Add("P11", "<B>" + productInt[counter].Product1ID + "</B>");
                dynamicEntities[0].FieldValueCollection.Add("P21", "<B>" + productInt[counter].Product2ID + "</B>");
                dynamicEntities[0].FieldValueCollection.Add("P31", "<B>" + productInt[counter].Product3ID + "</B>");
                dynamicEntities[0].FieldValueCollection.Add("P1Desc1", productInt[counter].Product1Desc);
                dynamicEntities[0].FieldValueCollection.Add("P2Desc1", productInt[counter].Product2Desc);
                dynamicEntities[0].FieldValueCollection.Add("P3Desc1", productInt[counter].Product3Desc);
                dynamicEntities[0].FieldValueCollection.Add("P1Img1", "<" + productInt[counter].Product1ImgLink + "/>");
                dynamicEntities[0].FieldValueCollection.Add("P2Img1", "<" + productInt[counter].Product2ImgLink + "/>");
                dynamicEntities[0].FieldValueCollection.Add("P3Img1", "<" + productInt[counter].Product3ImgLink + "/>");
                dynamicEntities[0].FieldValueCollection.Add("MappedEntityType", "1");
                dynamicEntities[0].FieldValueCollection.Add("MappedEntityID", productInt[counter].ContactId.ToString());
                //// Execute the request
                var result = ServiceProxy.Create(dynamicEntities);

                //// Verify the status of each DataCard Create request in the results
                foreach (CreateResult t in result)
                {
                    //// Successfull requests return a positive integer value for ID
                    if (t.ID != -1)
                    {
                        dataCardId = t.ID;
                    }
                    else
                    {
                        // Extract the Error Message and Error Code for each failed Create request
                        foreach (Error createError in t.Errors)
                        {
                            Response.Write("Exception Message: " + createError.ErrorCode.ToString());
                        }
                    }
                }
                }
            }
            catch (System.ServiceModel.FaultException ex)
            {
                //// Catch Service Model Fault Exceptions
                this.MessageBox("Reson: " + ex.Reason.ToString());
                this.MessageBox("Fault Type: " + ex.GetType().ToString());
                this.MessageBox("Fault Code: " + ex.Code.Name.ToString());
            }
            catch (Exception ex)
            {
                //// Catch System Exceptions
                this.MessageBox("Exception Message: " + ex.Message.ToString());
            }
        }
        #endregion

        #region Product Reading
        /// <summary>
        /// It  reads the product under Product collection 
        /// </summary>
        /// <param name="path">xml path</param>
        /// <returns>list of product</returns>
        private static List<Product> Products(string path)
        {
            XDocument xd = XDocument.Load(path);
            List<Product> products = new List<Product>();

            ////  Method syntax (lambda expression)           
            var stds = xd.Element("Products").Elements("Product");
            try
            {
                Product prd = null;
                foreach (var s in stds)
                {
                    prd = new Product(s.Element("ProductID").Value, s.Element("ProductName").Value, s.Element("ProductDesc").Value, s.Element("ProductImageLink").Value);
                    products.Add(prd);
                }

                return products;
            }
            catch
            {
                throw new Exception("Products data file could not be parsed.");
            }
        }

        /// <summary>
        /// It reads product details from the external ProductXml
        /// </summary>
        private List<Product> ReadProducts()
        {
            // this.ProductCollection = new List<Product>();
            List<Product> productCollection = new List<Product>();
            productCollection = Products(ConfigurationManager.AppSettings["ProductXml"]);
            return productCollection;
        }
        #endregion

    }
}



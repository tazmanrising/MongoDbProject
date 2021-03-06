//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v3.0.2.93
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

namespace Umbraco.Web.PublishedContentModels
{
	/// <summary>Client</summary>
	[PublishedContentModel("clients")]
	public partial class Clients : PublishedContentModel
	{
#pragma warning disable 0109 // new is redundant
		public new const string ModelTypeAlias = "clients";
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
#pragma warning restore 0109

		public Clients(IPublishedContent content)
			: base(content)
		{ }

#pragma warning disable 0109 // new is redundant
		public new static PublishedContentType GetModelContentType()
		{
			return PublishedContentType.Get(ModelItemType, ModelTypeAlias);
		}
#pragma warning restore 0109

		public static PublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Clients, TValue>> selector)
		{
			return PublishedContentModelUtility.GetModelPropertyType(GetModelContentType(), selector);
		}

		///<summary>
		/// Client Short Code: The code used to prefix jobs and data for this client
		///</summary>
		[ImplementPropertyType("clientCode")]
		public string ClientCode
		{
			get { return this.GetPropertyValue<string>("clientCode"); }
		}

		///<summary>
		/// Client Logo
		///</summary>
		[ImplementPropertyType("clientLogo")]
		public Umbraco.Web.Models.ImageCropDataSet ClientLogo
		{
			get { return this.GetPropertyValue<Umbraco.Web.Models.ImageCropDataSet>("clientLogo"); }
		}

		///<summary>
		/// Contact Email Address
		///</summary>
		[ImplementPropertyType("contactEmailAddress")]
		public string ContactEmailAddress
		{
			get { return this.GetPropertyValue<string>("contactEmailAddress"); }
		}

		///<summary>
		/// Contact Name
		///</summary>
		[ImplementPropertyType("contactName")]
		public string ContactName
		{
			get { return this.GetPropertyValue<string>("contactName"); }
		}

		///<summary>
		/// Contact Phone Number
		///</summary>
		[ImplementPropertyType("contactPhoneNumber")]
		public string ContactPhoneNumber
		{
			get { return this.GetPropertyValue<string>("contactPhoneNumber"); }
		}

		///<summary>
		/// Is Sample Client: This client is only for testing purposes. Will not be used for production counts
		///</summary>
		[ImplementPropertyType("isSampleClient")]
		public bool IsSampleClient
		{
			get { return this.GetPropertyValue<bool>("isSampleClient"); }
		}

		///<summary>
		/// Next Job Number: The next job number to be issued to this client (Read Only)
		///</summary>
		[ImplementPropertyType("nextJobNumber")]
		public string NextJobNumber
		{
			get { return this.GetPropertyValue<string>("nextJobNumber"); }
		}
	}
}

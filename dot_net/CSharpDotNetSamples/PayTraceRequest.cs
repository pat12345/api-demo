﻿using System;


namespace AspNetClientEncryptionExample
{
    /// <summary>
    /// class that contains API username and password for requesting OAuthToken
    /// Replace the username and password with your assigned API user credentials.
    /// </summary>
    public class ApiAccessCredentials
    {
        public static string GrantType = "password";
        public static string UserName = "demo123";
        public static string Password = "demo123";

        public static string GetFormattedRequest()
        {
            return string.Format("grant_type={0}&username={1}&password={2}", GrantType, UserName,Password);
        }
    }
    
    /// <summary>
	/// Class contains base url and all request URLs 
	/// Please Refer PayTrace API Methods for the request url detail
    /// Add the new ones as you add new methods 
	/// </summary>
	public class ApiEndPointConfiguration
	{
		/// <summary>
		/// BaseUrl contains PayTrace API URL
		/// </summary>
		public const string BaseUrl = "https://api.paytrace.com"; //Production. 

		/// <summary>
		/// APIVersion contains Version of API 
		/// </summary>
		public const string ApiVersion = "/v1";

		/// <summary>
		/// Url for OAuth Token 
		/// </summary>
		public const string UrlOAuth = "/oauth/token";

		/// <summary>
		/// URL for Keyed Sale
		/// </summary>
		public const string UrlKeyedSale = ApiVersion + "/transactions/sale/keyed";

		/// <summary>
		/// URL for Swiped Sale
		/// </summary>
		public const string UrlSwipedSale = ApiVersion + "/transactions/sale/swiped";

		/// <summary>
		/// URL for Keyed Authorization
		/// </summary>
		public const string UrlKeyedAuthorization = ApiVersion + "/transactions/authorization/keyed";

		/// <summary>
		/// URL for Keyed Refund
		/// </summary>
		public const string UrlKeyedRefund = ApiVersion + "/transactions/refund/keyed";

		/// <summary>
		/// URL for Capture Transaction
		/// </summary>
		public const string UrlCapture= ApiVersion + "/transactions/authorization/capture";

		/// <summary>
		/// URL for Void Sale Transaction
		/// </summary>
		public const string UrlVoidTransaction = ApiVersion + "/transactions/void";

		/// <summary>
		/// URL for Vault Sale by CustomerId Method
		/// </summary>
		public const string UrlCreateCustomer = ApiVersion + "/customer/create";

		/// <summary>
		/// URL for Vault Sale by CustomerId Method
		/// </summary>
		public const string UrlVaultSaleByCustomerId = ApiVersion + "/transactions/sale/by_customer";

	}

    /// <summary>
    /// Class for credit card
    /// </summary>
    public class CreditCard  
	{
		
		// Declare 'encrypted_number' instead of 'number' in case of using PayTrace Client-Side Encryption JavaScript Library.
		public string number { get; set; } 
		public string expiration_month { get; set; }
		public string expiration_year { get; set; }
	}

    /// <summary>
    /// Class for billing address
    /// </summary>
    public class BillingAddress 
	{

		public string name { get; set; }
		public string street_address { get; set; }
		public string city { get; set; }
		public string state { get; set; }
		public string zip { get; set; }
	}
		

	public class KeyedSaleRequest 
	{
		/// <summary>
		/// Class for keyed sale request and Keyed Authorization.
		/// Please refer the account security page on PayTrace virtual Terminal to determine the property.
		/// </summary>
		public double amount { get; set; }
		public CreditCard credit_card { get; set; } 
		// Declare 'encrypted_csc' instead of 'csc' in case of using PayTrace Client-Side Encryption JavaScript Library.
		public string csc { get; set; } 
		public BillingAddress billing_address { get; set; }
	}

    /// <summary>
    /// Class for swiped Sale Request. 
    /// Please refer the account security page on PayTrace virtual Terminal to determine the property.
    /// </summary>
    public class SwipedSaleRequest
	{
		public double amount { get; set; }

		//declare 'encrypted_swipe' instead of 'swipe' in case of using PayTrace client side encryption
		//this will include both track1 and track2 data
		public string swipe { get; set; }  
	}

    /// <summary>
    /// This class holds properties for the KeyedRefund request.
    /// Please check the Account security settings before defining this class as there are some request fields are conditional and optional.
    /// This class uses Billing Address class.
    /// This class also uses Credit Card class.
    /// </summary>
    public class KeyedRefundRequest 
	{
		public double amount { get; set; }
		public CreditCard credit_card { get; set; } 
		// Declare 'encrypted_csc' instead of 'csc' in case of using PayTrace Client-Side Encryption JavaScript Library.
		public string csc { get; set; } 
		public BillingAddress billing_address { get; set; }
	}

	public class VoidTransactionRequest
    { 
		public long transaction_id { get; set; }

	}
    /// <summary>
    /// classr for Capture Transaction request - include other optional inputs from the PayTrace Capture page as needed.
    /// </summary>
    public class CaptureTransactionRequest
	{
		// uncomment amount if your requirement is to send the amount with capture and make relavant changes
		// public double amount {get; set; } 
		public long transaction_id { get; set; }

	}

    /// <summary>
    /// Class for Vault Sale by Customer ID request
    /// Include other optional inputs from the PayTrace Capture page as needed.
    /// </summary>
    public class VaultSaleByCustomerIdRequest
    { 
		public double amount {get; set; }
		public string customer_id { get; set; }

	}
    /// <summary>
    /// Class for Create Customer Profile request 
    /// Please refer the account security page on PayTrace virtual Terminal to determine the properties and Create Customer Profile Page.
    /// </summary>	
    public class CreateCustomerProfileRequest 
	{
	
		public string customer_id { get; set; }
		public CreditCard credit_card { get; set; } 
 		public BillingAddress billing_address { get; set; }
		
        /// <summary>
		/// This Discretionary_data object is optionl - declare it in case you have discretionary data requiered for the customer
		/// Those can be set from the PayTrace Virtual Terminal - Discretionary Data 
		/// </summary>
		//public CustomerDiscretionaryData discretionary_data { get; set; }

	}

	public class CustomerDiscretionaryData
	{
		/// <summary>
		/// This class holds properties for the Customer - Discretionary data 
		/// Properties name should be same as Discretionary Data field names - as selected from the PayTrace Virtual Terminals
		/// </summary>
		public string TestingField { get; set; }
		public string Testing_DisData { get; set; }

	}





}

//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TweakToolkit.MVVM.Model
{
    using System;
    using Microsoft.Practices.Prism.ViewModel;
    
    public partial class AddressTypeModel : NotificationObject
    {
        private short postalCode;
    	public short PostalCode 
    	{ 
    		get { return postalCode; } 
    		set { postalCode = value; RaisePropertyChanged(() => PostalCode); } 
    	} 
    
        private string street;
    	public string Street 
    	{ 
    		get { return street; } 
    		set { street = value; RaisePropertyChanged(() => Street); } 
    	} 
    
        private string streetNumber;
    	public string StreetNumber 
    	{ 
    		get { return streetNumber; } 
    		set { streetNumber = value; RaisePropertyChanged(() => StreetNumber); } 
    	} 
    
        private string city;
    	public string City 
    	{ 
    		get { return city; } 
    		set { city = value; RaisePropertyChanged(() => City); } 
    	} 
    
    }
}

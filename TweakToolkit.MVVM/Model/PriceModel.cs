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
    using System.Collections.Generic;
    using Microsoft.Practices.Prism.ViewModel;
    
    public partial class PriceModel : NotificationObject
    {
        private int id;
    	public int Id 
    	{ 
    		get { return id; } 
    		set { id = value; RaisePropertyChanged(() => Id); } 
    	} 
    
        private Nullable<decimal> bid;
    	public Nullable<decimal> Bid 
    	{ 
    		get { return bid; } 
    		set { bid = value; RaisePropertyChanged(() => Bid); } 
    	} 
    
        private Nullable<decimal> ask;
    	public Nullable<decimal> Ask 
    	{ 
    		get { return ask; } 
    		set { ask = value; RaisePropertyChanged(() => Ask); } 
    	} 
    
        private Nullable<System.DateTime> lastUpdate;
    	public Nullable<System.DateTime> LastUpdate 
    	{ 
    		get { return lastUpdate; } 
    		set { lastUpdate = value; RaisePropertyChanged(() => LastUpdate); } 
    	} 
    
    
        public virtual StockModel Stock { get; set; }
    }
}
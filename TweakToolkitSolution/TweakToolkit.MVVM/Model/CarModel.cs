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
    
    public partial class CarModel : NotificationObject
    {
        public CarModel()
        {
            this.Brand = "BMW";
            this.Tires = new HashSet<TireModel>();
        }
    
        private int id;
    	public int Id 
    	{ 
    		get { return id; } 
    		set { id = value; RaisePropertyChanged(() => Id); } 
    	} 
    
        private string brand;
    	public string Brand 
    	{ 
    		get { return brand; } 
    		set { brand = value; RaisePropertyChanged(() => Brand); } 
    	} 
    
        private int bhp;
    	public int Bhp 
    	{ 
    		get { return bhp; } 
    		set { bhp = value; RaisePropertyChanged(() => Bhp); } 
    	} 
    
    
        public virtual ICollection<TireModel> Tires { get; set; }
        public virtual PersonModel Owner { get; set; }
    }
}

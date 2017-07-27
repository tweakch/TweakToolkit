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
    
    public partial class RoomModel : NotificationObject
    {
        public RoomModel()
        {
            this.Door = new HashSet<DoorModel>();
        }
    
        private int id;
    	public int Id 
    	{ 
    		get { return id; } 
    		set { id = value; RaisePropertyChanged(() => Id); } 
    	} 
    
        private string size;
    	public string Size 
    	{ 
    		get { return size; } 
    		set { size = value; RaisePropertyChanged(() => Size); } 
    	} 
    
    
        public virtual HouseModel House { get; set; }
        public virtual ICollection<DoorModel> Door { get; set; }
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TweakToolkit.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class House
    {
        public House()
        {
            this.Room = new HashSet<Room>();
            this.Address = new AddressType();
        }
    
        public int Id { get; set; }
    
        public AddressType Address { get; set; }
    
        public virtual Door Door { get; set; }
        public virtual ICollection<Room> Room { get; set; }
        public virtual Person Owner { get; set; }
    }
}
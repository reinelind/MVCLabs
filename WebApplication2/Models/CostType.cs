//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CostType
    {
        public int Id { get; set; }
        public int CostId { get; set; }
        public int TypeId { get; set; }
    
        public virtual Cost Cost { get; set; }
        public virtual Type Type { get; set; }
    }
}

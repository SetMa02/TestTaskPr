//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TestTaskPr
{
    using System;
    using System.Collections.Generic;
    
    public partial class Books
    {
        public int id { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public Nullable<int> category { get; set; }
        public Nullable<int> tag { get; set; }
        public byte[] photo { get; set; }
        public Nullable<int> reader { get; set; }
        public Nullable<int> shielf { get; set; }
    
        public virtual Categoryes Categoryes { get; set; }
        public virtual Reader Reader1 { get; set; }
        public virtual Shielfs Shielfs { get; set; }
        public virtual Tags Tags { get; set; }
    }
}

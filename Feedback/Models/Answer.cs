//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Feedback.Models
{
    using System;
    using System.Collections.Generic;

    public partial class Answer
    {
        public int id { get; set; }
        public int questionId { get; set; }
        public string body { get; set; }
        public string userName { get; set; }
        public System.DateTime createDate { get; set; }
        public Nullable<System.DateTime> lastUpdateDate { get; set; }
    }
}

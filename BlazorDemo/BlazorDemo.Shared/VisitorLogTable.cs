using System;

namespace BlazorDemo.Shared
{
    public class VisitorLogTable
    {
        public int Id { get; set; }
        public string NameofVisitor { get; set; }
        public string Company { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
    }
}

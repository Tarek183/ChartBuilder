using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaaS__Chart__Builder__App.Models
{
    public class ViewModel
    {
        public string theId { get; set; }
        public Dashboard__Chart__Property chprop { get; set; }
        public string request { get; set; }
        public string lastString { get; set; }
        public string Selected { get; set; }
        public Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property Menu_Chart_Property { get; set; }
        public List<Dashboard__Chart____88____core__Menus____88____Dashboard__Chart__Property> Menu_Chart_Properties { get; set; }
        public Dashboard__Chart____88____core__Menus Chart_Menu { get; set; }
        public List<Dashboard__Chart____88____core__Menus> Chart_Menus { get; set; }
        public List<Dashboard__Chart__Property> Chart_Property { get; set; }
        public Dashboard__Chart__Property Chart_PropertyObject { get; set; }
        public List<string> titles { get;set; }
        public List<Dashboard__Chart__Property> selectedProerties { get;set; }
    }
}
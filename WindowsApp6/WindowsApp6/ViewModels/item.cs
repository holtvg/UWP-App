using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApp6.ViewModels
{
   // [DataContract]
    class item
    {
      //  [JsonProperty("id")]
       
        public int id { get; set; }
      //  [JsonProperty("name")]
        public string name { get; set; }
     //   [JsonProperty("category")]
        public string category { get; set; }
      //  [JsonProperty("price")]
        public decimal price { get; set; }

        //  public double price { get; set; }

        //public override bool Equals(object obj)
        //{
        //    // Check for null  
        //    if (ReferenceEquals(obj, null))
        //        return false;
        //    // Check for same reference  
        //    if (ReferenceEquals(this, obj))
        //        return true;
        //    var itm = (item)obj;
        //    return this.id == itm.id;
        //}


        //public override bool Equals(object obj)
        //{
        //    // Check for null  
        //    if (ReferenceEquals(obj, null))
        //        return false;
        //    // Check for same reference  
        //    if (ReferenceEquals(this, obj))
        //        return true;
        //    var itm = (item)obj;
        //    return this.category == itm.category;
        //}

        public override bool Equals(object obj)
        {
            // Check for null  
            if (ReferenceEquals(obj, null))
                return false;
            // Check for same reference  
            if (ReferenceEquals(this, obj))
                return true;
            var itm = (item)obj;
            //  if (obj.Equals(id))
            if (ReferenceEquals(obj, id))
            {
                return this.id == itm.id;
            }
            return this.category == itm.category;
        }

        public override int GetHashCode()
        {
            return id ^ 7;
        }

    }
}

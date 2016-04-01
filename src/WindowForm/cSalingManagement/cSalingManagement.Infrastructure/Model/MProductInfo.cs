using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSalingManagement.Infrastructure.Model
{
    public class MProductInfo
    {
        private string productID;

        public string ProductID
        {
            get { return productID; }
            set { productID = value; }
        }
        private string productName;

        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }
        private string quantity;

        public string Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
    }
}

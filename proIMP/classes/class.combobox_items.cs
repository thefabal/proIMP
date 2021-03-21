using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace proIMP {
    public class CategoryItem {
        private readonly string categoryID;
        private readonly string categoryName;

        public CategoryItem( string categoryID, string categoryName ) {
            this.categoryID = categoryID;
            this.categoryName = categoryName;
        }

        public string CategoryID {
            get {
                return categoryID;
            }
        }

        public string CategoryName {
            get {
                return CategoryName;
            }
        }

        public override string ToString() {
            return categoryName;
        }
    }

    public class SupplierItem {
        private readonly string supplierID;
        private readonly string supplierName;

        public SupplierItem( string supplierID, string supplierName ) {
            this.supplierID = supplierID;
            this.supplierName = supplierName;
        }

        public string SupplierID {
            get {
                return supplierID;
            }
        }

        public string SupplierName {
            get {
                return supplierName;
            }
        }

        public override string ToString() {
            return supplierName;
        }
    }

    public class WarehouseItem {
        private readonly string warehouseID;
        private readonly string warehouseName;

        public WarehouseItem( string WarehouseID, string WarehouseName ) {
            this.warehouseID = WarehouseID;
            this.warehouseName = WarehouseName;
        }

        public string WarehouseID {
            get {
                return warehouseID;
            }
        }

        public string WarehouseName {
            get {
                return warehouseName;
            }
        }

        public override string ToString() {
            return warehouseName;
        }
    }

    public class ProductItem {
        private readonly string productID;
        private readonly string productName;
        private readonly string productUnit;

        public ProductItem( string productID, string productName, string productUnit ) {
            this.productID = productID;
            this.productName = productName;
            this.productUnit = productUnit;
        }

        public string ProductID {
            get {
                return productID;
            }
        }

        public string ProductUnit {
            get {
                return productUnit;
            }
        }

        public string ProductName {
            get {
                return productName;
            }
        }

        public override string ToString() {
            return productName;
        }
    }
}

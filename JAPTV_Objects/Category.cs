﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAPTV_Objects
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }

        public Category()
        {
        }
        public Category(int categoryID, string name)
        {
            CategoryID = categoryID;
            Name = name;
        }

        public override string ToString()
        {
            return String.Format(Name);
        }
    }
}

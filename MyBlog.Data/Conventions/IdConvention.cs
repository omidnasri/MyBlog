﻿using System.Data.Entity.ModelConfiguration.Conventions;

namespace MyBlog.Data.Conventions
{
    internal class IdConvention : Convention
    {
        public IdConvention()
        {
            Properties<int>().Where(p => p.Name.Equals("Id")).Configure(p => p.IsKey().HasColumnOrder(0));
        }
    }
}
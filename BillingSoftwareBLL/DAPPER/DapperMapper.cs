using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using DapperExtensions.Mapper;
namespace BillingSoftwareBLL.DAPPER
{
    class loginClassMapper: ClassMapper<loginClass>
    {
        public loginClassMapper()
        {
            base.Table("log");
            Map(a => a.username).Column("username");
            Map(a => a.password).Column("password");
        }

        

    }

    class productDapperMapper : ClassMapper<productDapper>
    {
        public productDapperMapper()
        {
            base.Table("product_table");
            Map(a => a.username).Column("username");
            Map(a => a.cost).Column("cost");
            Map(a => a.item).Column("item");
            Map(a => a.id).Column("id");
        }



    }



}

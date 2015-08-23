using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Zelenjava.Model.Entities;

namespace Zelenjava.DAL.Mappings
{
    public class PhotoMap:ClassMap<Photo>
    {
        public PhotoMap()
        {
            Id(x => x.Id);

            Map(x => x.Description);
            Map(x => x.Content).CustomSqlType("varbinary(MAX)");

            Map(x => x.Type).CustomType(typeof (PhotoType));
            References(x => x.Article);
        }
    }
}

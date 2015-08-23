using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using Zelenjava.Model.Entities;

namespace Zelenjava.DAL.Mappings
{
    public class ArticleMap:ClassMap<Article>
    {
        public ArticleMap()
        {
            Id(x => x.Id);

            Map(x => x.TitleHr);
            Map(x => x.TitleEng);
            Map(x => x.ContentHr);
            Map(x => x.ContentEng);
            Map(x => x.SummaryHr);
            Map(x => x.SummaryEng);
            Map(x => x.CreationDate);
            Map(x => x.YouTubeCode);
            Map(x => x.PublicContent);
            Map(x => x.OnEnglish);
            Map(x => x.HasVideo);

            References(x => x.Category);
            References(x => x.Author);
            HasMany(x => x.Photos).Cascade.All();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Zelenjava.Model.Entities
{
    public class Article
    {
        public virtual int Id { get; private set; }

        public virtual string TitleHr { get; set; }

        public virtual string TitleEng { get; set; }

        public virtual string ContentHr { get; set; }

        public virtual string ContentEng { get; set; }

        public virtual string SummaryHr { get; set; }

        public virtual string SummaryEng { get; set; }

        public virtual DateTime CreationDate { get; set; }

        public virtual string YouTubeCode { get; set; }

        public virtual bool PublicContent { get; set; }

        public virtual bool OnEnglish { get; set;}

        public virtual bool HasVideo { get; set; }

        public virtual Category Category { get; set; }

        public virtual Author Author { get; set; }

        public virtual IList<Photo> Photos { get; set; }

        public Article(){}

        public Article(string titleHr, string titleEng, string contentHr, string contentEng, string summaryHr, string summaryEng, string youTubeCode, bool publicContent, bool onEnglish, bool hasVideo, Category category, Author author, List<Photo> photos)
        {
            TitleHr = titleHr;
            TitleEng = titleEng;
            ContentHr = contentHr;
            ContentEng = contentEng;
            SummaryHr = summaryHr;
            SummaryEng = summaryEng;
            YouTubeCode = youTubeCode;
            PublicContent = publicContent;
            OnEnglish = onEnglish;
            HasVideo = hasVideo;
            Category = category;
            Author = author;
            CreationDate = DateTime.Now;
            Photos = photos;
        }
    }
}
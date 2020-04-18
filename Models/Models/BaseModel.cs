using System;

namespace Models.Models
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }

        public virtual string Title { get; set; }

        public virtual string Subtitle { get; set; }

        public virtual string Text { get; set; }

        public virtual string TitleImagePath { get; set; }

        public virtual string MetaTitle { get; set; }

        public virtual string Description { get; set; }

        public virtual string Keywords { get; set; }

        public DateTime DateAdded { get; set; }
    }
}
